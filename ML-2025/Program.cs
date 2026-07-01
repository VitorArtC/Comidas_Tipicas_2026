using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using ML_2025.Data;
using ML_2025.Entidades;
using ML_2025.Models;
using ML_2025.Services;
using ML_2025.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// Registrar DataServices
builder.Services.AddScoped<IFeedBackDataService, FeedBackDataService>();
builder.Services.AddScoped<IPredictRequestDataService, PredictRequestDataService>();
builder.Services.AddScoped<ITreinamentoDataService, TreinamentoDataService>();
builder.Services.AddScoped<ILogDataService, LogDataService>();

// Registrar wrappers de negócio (dependem dos DataServices)
builder.Services.AddScoped<Feedback>();
builder.Services.AddScoped<Logs>();

var pastaModelos = Path.Combine(AppContext.BaseDirectory, "MLModels");
if (!File.Exists(Path.Combine(pastaModelos, "model.zip")))
    ModelBuilderML.Treinar(pastaModelos);

var mlContext = new MLContext();
var modelPath = Path.Combine(pastaModelos, "model.zip");
var model = mlContext.Model.Load(modelPath, out _);
var engine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);

builder.Services.AddSingleton(engine);

var app = builder.Build();

// Aplicar migrations e seed automaticamente na startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    // Seed da tabela Treinamentos a partir do CSV (sem duplicar)
    var csvPath = Path.Combine(pastaModelos, "sentiment.csv");
    if (File.Exists(csvPath) && !db.Treinamentos.Any())
    {
        var linhas = File.ReadAllLines(csvPath).Skip(1); // pula o cabeçalho
        int index = 0;
        foreach (var linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha)) continue;
            var primeiraVirgula = linha.IndexOf(',');
            if (primeiraVirgula <= 0) continue;

            var labelStr = linha.Substring(0, primeiraVirgula).Trim();
            var texto = linha.Substring(primeiraVirgula + 1).Trim('"', ' ');

            db.Treinamentos.Add(new TreinamentoData
            {
                Text = texto,
                Label = labelStr.Equals("true", StringComparison.OrdinalIgnoreCase),
                CreatAt = DateTime.Now.AddMilliseconds(index++),
                UpdateAt = DateTime.Now
            });
        }
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapPost("/predict", (PredictRequest request, PredictionEngine<SentimentData, SentimentPrediction> engine) =>
{
    var prediction = engine.Predict(new SentimentData { Text = request.Text });
    return Results.Ok(prediction);
});

app.Run();
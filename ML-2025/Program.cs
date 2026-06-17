using Microsoft.ML;
using ML_2025.Models;
using ML_2025.Services;
using ML_2025.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

var pastaModelos = Path.Combine(AppContext.BaseDirectory, "MLModels");
if (!File.Exists(Path.Combine(pastaModelos, "model.zip")))
    ModelBuilderML.Treinar(pastaModelos);

var mlContext = new MLContext();
var modelPath = Path.Combine(pastaModelos, "model.zip");
var model = mlContext.Model.Load(modelPath, out _);
var engine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);


builder.Services.AddSingleton(engine);

var app = builder.Build();

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
# Typic.AI - Classificador de Comidas Típicas 🍲

Bem-vindo ao repositório do **Typic.AI**, um projeto que une a cultura gastronômica brasileira com o poder do Machine Learning para classificação automatizada de alimentos.

## 📌 Sobre o Projeto

O **Typic.AI** é uma aplicação web desenvolvida em C# com ASP.NET Core Razor Pages e integrada com ML.NET. O objetivo do sistema é receber dados de uma comida (nome longo/curto e região, por exemplo) e utilizar um modelo de Inteligência Artificial para prever seu sabor ou categoria (Doce vs. Salgado), além de coletar o feedback do usuário para melhorar continuamente o modelo.

A aplicação conta com um design moderno (*Premium Theme*, *Dark Mode*, *Glassmorphism*), priorizando a experiência do usuário e fornecendo uma interface rica, responsiva e agradável.

## 🚀 Funcionalidades Principais

* **Validador de Pratos com IA:** Um classificador de machine learning integrado diretamente no sistema, que infere predições baseado na base de dados (`sentiment.csv` / `MLModels`).
* **Sistema de Feedback Inteligente:** Coleta das interações e reações dos usuários (Positivo, Neutro ou Negativo) em relação às respostas da IA, persistindo logs estruturados no arquivo `comentarios.log` para uso em retreinamento e auditoria.
* **Interface Moderna e Responsiva:** Estilização global avançada feita do zero com variáveis e CSS puro, oferecendo *dark mode* e cartões flutuantes.
* **Página de Integrantes Dinâmica:** Apresentação da equipe de desenvolvimento através de uma interface interativa e otimizável.

## 💻 Tecnologias Utilizadas

* **Back-end:** C#, .NET 8 / ASP.NET Core MVC (Razor Pages)
* **Inteligência Artificial:** ML.NET (Treinamento de Modelos em C#)
* **Front-end:** HTML5, CSS3 Avançado (Vanilla CSS) e JavaScript
* **Repositório de Dados:** CSV (`sentiment.csv`) para treinamento do modelo e sistema de Logs de gravação direta.

## 👥 Equipe de Desenvolvimento

* **Vitor Arthur** - ADS
* **Roberth Kennedy** - ADS
* **Arthur Oliveira** - ADS
* **Manu Kelry** - ADS

## 🔧 Como Executar o Projeto

Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

1. Clone ou baixe este repositório.
2. Abra o terminal e navegue até a pasta do projeto:
   ```bash
   cd "C:\Users\Vitor Arthur\Documents\Comidas_Tipicas_2026\ML-2025"
   ```
3. Restaure as dependências do projeto:
   ```bash
   dotnet restore
   ```
4. Execute e rode a aplicação:
   ```bash
   dotnet run
   ```
5. Abra o navegador e acesse a URL que aparecerá no console (geralmente `https://localhost:5001` ou `http://localhost:5000`).

## 📁 Estrutura do Projeto (Principais Pastas)

* `wwwroot/`: Arquivos estáticos servidos pelo site (*CSS*, *Imagens*, *JS*).
* `Pages/`: As visualizações e lógicas das telas Razor Pages (ex: `Index.cshtml`, `Privacy.cshtml`).
* `Services/`: Serviços de back-end (ex: `Feedback.cs` responsável pelo sistema de gravações).
* `Models/`: Modelos de dados utilizados no código (ex: `EnumTipoFeedback.cs`).
* `MLModels/`: Conjuntos de dados de treinamento em CSV usados para treinar o ML.NET.

---
*Desenvolvido com dedicação pela equipe de Análise e Desenvolvimento de Sistemas (ADS).*

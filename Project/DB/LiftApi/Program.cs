var builder = WebApplication.CreateBuilder(args);

// On ajoute les contrôleurs au cerveau du serveur
builder.Services.AddControllers();

var app = builder.Build();

// On branche les routes (les adresses web)
app.MapControllers();

app.Run();
// LES FAMEUX DICTIONNAIRES (L'équivalent de tes #include)
using Microsoft.AspNetCore.Mvc; // Pour ControllerBase, IActionResult, HttpPost...
using MongoDB.Driver;           // Pour MongoClient, IMongoCollection...
using LiftApi.Models;           // Pour que le contrôleur connaisse ta classe Workout
using System;                   // Pour Environment et Exception

// Le nom de famille de ton fichier
namespace LiftApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly IMongoCollection<Workout> _workoutsCollection;


    public WorkoutController(IConfiguration config) // <-- On injecte la configuration ici
    {
        // 1. Il cherche d'abord la variable d'environnement (pour la production)
        var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION");

        // 2. Si elle est vide, il lit le fichier appsettings.json (pour le dev local)
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = config.GetValue<string>("MongoDbConnectionString"); 
        }

        // 3. Si c'est TOUJOURS vide, on met une sécurité
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("CRASH PRÉVENTIF : Aucune clé MongoDB trouvée !");
        }

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("LiftDatabase");
        _workoutsCollection = database.GetCollection<Workout>("Workouts");
    }
    

    [HttpPost]
    public IActionResult SaveWorkout([FromBody] Workout newWorkout)
    {
        _workoutsCollection.InsertOne(newWorkout);
        return Ok(new { message = "Séance enregistrée dans le Cloud !", id = newWorkout.Id });
    }
}
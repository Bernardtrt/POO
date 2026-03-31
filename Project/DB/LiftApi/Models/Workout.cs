using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace LiftApi.Models;

public class Workout
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    // Le serveur utilise des Listes pures
    public List<Exercice> Exercices { get; set; } = new();
}

public class Exercice
{
    public string Name { get; set; } = string.Empty;
    
    // LA CORRECTION EST ICI : On remplace ObservableCollection par List
    public List<Set> Sets { get; set; } = new();
}

public class Set
{
    public int? Reps { get; set; }
    public double? Weight { get; set; }
}
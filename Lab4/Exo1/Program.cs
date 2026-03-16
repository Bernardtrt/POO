using System;
using System.Linq;
using Microsoft.EntityFrameworkCore; // <--- LA PIÈCE MANQUANTE !
using Lab4;

Console.WriteLine("Démarrage de l'application Sport...");

using (var db = new SportContext())
{
    db.Database.EnsureCreated();

    if (!db.Teams.Any())
    {
        Console.WriteLine("La base est vide, ajout des données de test...");

        var psg = new Team { Name = "Paris Saint-Germain" };

        var mbappe = new Player { Name = "Kylian Mbappé", Team = psg };
        var hakimi = new Player { Name = "Achraf Hakimi", Team = psg };

        db.Teams.Add(psg);
        db.Players.Add(mbappe);
        db.Players.Add(hakimi);

        db.SaveChanges();
        
        Console.WriteLine("Données sauvegardées avec succès !");
    }
    else
    {
        Console.WriteLine("Les données existent déjà dans la base.");
    }

    Console.WriteLine("\n--- Liste des équipes et leurs joueurs ---");
    
    var equipes = db.Teams.Include(t => t.Players).ToList();

    foreach (var equipe in equipes)
    {
        Console.WriteLine($"Équipe : {equipe.Name}");
        foreach (var joueur in equipe.Players)
        {
            Console.WriteLine($"  - {joueur.Name}");
        }
    }
}
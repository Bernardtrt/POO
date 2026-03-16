using System;
using System.Linq;
using Microsoft.EntityFrameworkCore; 
using Lab41;

Console.WriteLine("Game Starting...");

using (var db = new Games())
{
    // On force la création de la base de données SQLite
    db.Database.EnsureCreated();

    // On vérifie qu'on n'ajoute pas les mêmes données à chaque fois
    if (!db.CG.Any())
    {
        var newgame = new ComputerGame { Name = "Pacman" };

        // On utilise 'Id' maintenant
        var player1 = new Character { Id = 1, Name = "Bob", Position = "0, 0", CharacterImages = "" };

        // On ajoute le jeu à la base
        db.CG.Add(newgame);
        
        // Au lieu d'ajouter le personnage tout seul, le plus propre est de l'ajouter 
        // directement dans la liste du jeu ! C'est ça la puissance des objets.
        newgame.Characters.Add(player1);

        db.SaveChanges(); // On valide !
        
        Console.WriteLine("Pacman et Bob ajoutés à la base de données !");
    }
    else
    {
         Console.WriteLine("Les données existent déjà.");
    }
}
using System.Collections.Generic;

public class ComputerGame
{
    // 1. La clé primaire est maintenant standardisée
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty; 
    
    // J'ai renommé 'Players' en 'Characters' car c'est une liste d'objets Character
    public List<Character> Characters { get; set; } = new List<Character>();
}

public class Character
{
    // 1. Clé primaire standardisée
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Position { get; set; } = string.Empty; 
    
    // 2. La clé étrangère : EF Core s'attend à [NomDeLaClasse]Id
    public int ComputerGameId { get; set; }
    
    // 3. On ajoute = string.Empty pour faire taire l'avertissement jaune !
    public string CharacterImages {get; set;} = string.Empty;

    public ComputerGame? ComputerGame {get; set;}
}
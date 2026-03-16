using System.Collections.Generic;

namespace Lab4; 
public class Team
{
    public int TeamId { get; set; }
    
    public string Name { get; set; } = string.Empty; 
    
    public List<Player> Players { get; set; } = new List<Player>();
}

public class Player
{
    public int PlayerId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Position { get; set; } = string.Empty; 
    
    public int TeamId { get; set; }
    
    public Team? Team { get; set; } 
}
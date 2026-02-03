using System;
using System.Collections.Generic;

[cite_start]// 1. La classe de base (Le moule) [cite: 10, 14]
[cite_start]public abstract class Band : IComparable<Band> // IComparable sert au tri [cite: 12]
{
    public string BandName { get; set; }
    public int YearFormed { get; set; }
    public string Members { get; set; }
    
    [cite_start]// Une liste pour stocker les albums de ce groupe [cite: 19]
    public List<Album> Albums { get; set; } = new List<Album>();

    public Band(string name, int year, string members)
    {
        BandName = name;
        YearFormed = year;
        Members = members;
    }

    [cite_start]// Cette méthode sert à trier la liste automatiquement par nom [cite: 12]
    public int CompareTo(Band other)
    {
        return this.BandName.CompareTo(other.BandName);
    }

    [cite_start]// On change comment le groupe s'affiche en texte [cite: 16]
    public override string ToString()
    {
        // Affiche le nom et le type de groupe (Rock, Pop, etc.)
        return $"{BandName} - {this.GetType().Name}"; 
    }
}

[cite_start]// 2. Les sous-classes (Les types spécifiques) [cite: 15]
public class RockBand : Band
{
    public RockBand(string name, int year, string members) : base(name, year, members) {}
}

public class PopBand : Band
{
    public PopBand(string name, int year, string members) : base(name, year, members) {}
}

public class IndieBand : Band
{
    public IndieBand(string name, int year, string members) : base(name, year, members) {}
}

[cite_start]// 3. La classe Album [cite: 17, 21]
public class Album
{
    public string Name { get; set; }
    public DateTime Released { get; set; } // On utilise DateTime comme demandé
    public int Sales { get; set; }

    public string GetYearsSinceRelease()
    {
        // Petit calcul pour savoir ça fait combien d'années
        return $"{DateTime.Now.Year - Released.Year} years ago";
    }
}
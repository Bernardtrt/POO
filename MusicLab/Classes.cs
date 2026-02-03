using System;
using System.Collections.Generic;

namespace MusicLab
{
    // 1. La classe de base (Le moule)
    public abstract class Band : IComparable<Band>
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string Members { get; set; }
        
        // Une liste pour stocker les albums de ce groupe
        public List<Album> Albums { get; set; } = new List<Album>();

        public Band(string name, int year, string members)
        {
            BandName = name;
            YearFormed = year;
            Members = members;
        }

        // Tri automatique par nom
        public int CompareTo(Band other)
        {
            return this.BandName.CompareTo(other.BandName);
        }

        public override string ToString()
        {
            return $"{BandName} - {this.GetType().Name}"; 
        }
    }

    // 2. Les sous-classes
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

    // 3. La classe Album
    public class Album
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int Sales { get; set; }

        public string GetYearsSinceRelease()
        {
            return $"{DateTime.Now.Year - Released.Year} years ago";
        }
    }
}
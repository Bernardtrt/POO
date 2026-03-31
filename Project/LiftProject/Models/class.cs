using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 

namespace LiftProject;

public class Workout
{
    public string? Id { get; set; }
    public string Name { get; set; } = "My Workout";
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public TimeSpan Duration => EndTime - StartTime;
    public ObservableCollection<Exercice> Exercices { get; set; } = new();
    
    public double TotalVolume()
    {
        double total = 0;
        foreach(var exo in Exercices){
            foreach (var s in exo.Sets){
                total += (s.Weight ?? 0.0) * (s.Reps ?? 0);
            }
        }
        return total;

    }

    public void Start() { StartTime = DateTime.Now; }
    public void Finish() { EndTime = DateTime.Now; }
}

public class Exercice
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ObservableCollection<Set> Sets { get; set; } = new();
}

public class Set
{
    public string? Id { get; set; }
    public int? Reps { get; set; }
    public double? Weight { get; set; }

    public string WeightUI {
        get
        {
            return Weight?.ToString() ?? "";
        }
        set
        {
            if(string.IsNullOrWhiteSpace(value)) Weight = null;
            else if (double.TryParse(value, out double result)) Weight = result;
            
        }
    }

    public string RepsUI{
        get
        {
            return Reps?.ToString() ?? "";
        }
        set
        {
            if(string.IsNullOrWhiteSpace(value)) Reps = null;
            else if (int.TryParse(value, out int result)) Reps = result;
        }
    }


}

public enum Page {
    Acceuil,
    Workout,
    Profile
}
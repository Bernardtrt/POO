using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 

namespace LiftUI;

public class Workout
{
    public int Id { get; set; }
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
                total += s.Weight * s.Reps;
            }
        }
        return total;

    }

    public void Start() { StartTime = DateTime.Now; }
    public void Finish() { EndTime = DateTime.Now; }
}

public class Exercice
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ObservableCollection<Set> Sets { get; set; } = new();
}

public class Set
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; }
}
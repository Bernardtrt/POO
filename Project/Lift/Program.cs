using System;
using System.Collections.Generic;
class Programm
{
    static void Main()
    {
        Console.WriteLine("hello world !");
        var monEntrainement = new Workout{Name = "Push", Date = DateTime.Now};

        var dc = new Exercice { Name = "Développé couché" };
        dc.sets.Add(new Set { Reps = 10, Weight = 80 });
        dc.sets.Add(new Set { Reps = 8, Weight = 85 });

        monEntrainement.Exercices.Add(dc);

        Console.WriteLine($"Séance : {monEntrainement.Name}");
        Console.WriteLine($"Volume Total : {monEntrainement.TotalVolume()} kg");
    }

}


class User
{
    public string username {get; set;} = string.Empty;
    public List<Workout> History {get; set;} = new();
}

class Workout{
    public string Name {get; set;} = "New workout";
    public DateTime Date { get; set; }
    public List<Exercice> Exercices {get; set;} = new();


    public double TotalVolume()
    {
        double total = 0;
        foreach(var exo in Exercices){
            foreach (var s in exo.sets){
                total += s.Weight * s.Reps;
            }
        }
        return total;

    }

}

class Exercice{
    public string Name {get; set;} = string.Empty;
    public List<Set> sets {get; set;} = new();
}

class Set{
    public int Reps {get; set;}
    public double Weight {get; set;}

}
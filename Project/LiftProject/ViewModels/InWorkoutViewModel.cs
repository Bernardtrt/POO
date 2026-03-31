using CommunityToolkit.Mvvm.ComponentModel; 
using CommunityToolkit.Mvvm.Input; 
using LiftProject;

//pour l'api 
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//
using System;

namespace LiftProject.ViewModels;

public partial class InWorkoutViewModel : ViewModelBase
{
    [ObservableProperty]
    private Workout _currentWorkout;
    private readonly Action<ViewModelBase> _nav;

    public InWorkoutViewModel(Action<ViewModelBase> nav, Workout workout){
        _nav = nav;
        _currentWorkout = workout;
    }


    public Exercice[] Exercices {get;} = new Exercice[] 
    {
        new Exercice { Id = "", Name = "Bench Press" },
        new Exercice { Id = "", Name = "Squat" }
        
    };

    [ObservableProperty]
    public Exercice? _selectedExercice;


    [RelayCommand]
    public void AddExo(){
        if (SelectedExercice != null) 
        {
            CurrentWorkout.Exercices.Add(new Exercice { Name = SelectedExercice.Name });
        }

        }

    [RelayCommand]
    public void AddSets(Exercice targetExo) 
    {
        if (targetExo != null)
        {
            targetExo.Sets.Add(new Set { Weight = 0, Reps = 0 });
        }
    }
    [RelayCommand]
    public async Task EndWorkout(){
        CurrentWorkout.Finish();
        var Temps = CurrentWorkout.Duration.TotalMinutes;

        string jsonWorkout = JsonSerializer.Serialize(CurrentWorkout);
        var content = new StringContent(jsonWorkout, Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        try 
        {
            HttpResponseMessage response = await client.PostAsync("http://localhost:5026/api/workout", content);
            if (response.IsSuccessStatusCode) 
            {
                Console.WriteLine("VICTOIRE : Séance sauvegardée dans MongoDB !");
                _nav(new AcceuilViewModel());
            }
            else 
            {
                Console.WriteLine($"Aïe, le serveur a refusé : {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Impossible de joindre l'API (est-elle allumée ?) : {ex.Message}");
        }           
    }

}
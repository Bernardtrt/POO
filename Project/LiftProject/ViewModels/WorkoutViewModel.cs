using CommunityToolkit.Mvvm.ComponentModel; 
using CommunityToolkit.Mvvm.Input; 
using LiftProject;
using System;
namespace LiftProject.ViewModels;

public partial class WorkoutViewModel : ViewModelBase
{


    private Workout? _currentWorkout;
    private Action<ViewModelBase> _demanderChangementDePage;

    public WorkoutViewModel(Action<ViewModelBase> methodeDeNavigation){
        _demanderChangementDePage = methodeDeNavigation;
    }

    [RelayCommand]
    public void StartWorkout(){
        _currentWorkout = new Workout{Name = "Seance du jour"};
        
        _currentWorkout.Start();

        var nextPage = new InWorkoutViewModel(_demanderChangementDePage, _currentWorkout);
        _demanderChangementDePage(nextPage);
    }
}
/*
dont even try to understand what's happenin ghtere,
 it's just an awfull, long and hard manipulation of memory
i even started to cry blood over this, dont try to change anything and 
if u do anyway, update this counter to warn other people
Total hour wasted here : 0
*/

using CommunityToolkit.Mvvm.ComponentModel; 
using CommunityToolkit.Mvvm.Input; 
using LiftProject;
namespace LiftProject.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;

    public MainWindowViewModel(){
        _currentPage = new AcceuilViewModel();

    }


    [RelayCommand]
    public void GoTo(Page destination){
        switch (destination)
        {
            case Page.Acceuil:
                CurrentPage = new AcceuilViewModel();
                break;
            case Page.Workout:
                CurrentPage = new WorkoutViewModel(ChangerPageInterne);
                break;
            case Page.Profile:
                CurrentPage = new ProfileViewModel();
                break;  
            
        }
    }
    private void ChangerPageInterne(ViewModelBase nouvellePage){
        CurrentPage = nouvellePage;
    }

}

using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using Avalonia.Media.Imaging; // Pour l'objet Bitmap
using Avalonia.Platform;      // Pour l'AssetLoader (le chargeur interne)
namespace Lab5.Views;



public class Exercice{
    public int ID {get; set;}
    public string Name {get; set;} = "";
    public string Description  {get; set;} = "";
    public Bitmap? Image  {get; set;}
}

public partial class MainWindow : Window
{
    public Exercice[] Exercices {get;} = new Exercice[] 
    {
        new Exercice {ID = 0, Name ="Bench Press", 
                Description ="Flat Bench Press (Barbell or Dumbbell): Lie flat on the bench, feet firmly on the floor. Lower the weight (barbell or dumbbells) to your mid-chest, then press back up until arms are fully extended. This builds overall chest mass, specifically the pectoralis major.", 
                Image = new Bitmap(AssetLoader.Open(new Uri("avares://Lab5/Assets/benchpress.png")))},
        new Exercice {ID = 1, Name ="Squat", 
                Description ="A squat is a fundamental lower-body compound exercise that builds strength in the quads, glutes, hamstrings, and core by simulating a sitting-and-standing motion. Proper form requires feet shoulder-width apart, lowering hips back and down while keeping the chest up and back straight, ensuring knees track over toes, and driving through the heels", 
                Image = new Bitmap(AssetLoader.Open(new Uri("avares://Lab5/Assets/benchpress.png")))},
        new Exercice {ID = 2, Name ="Deadlift", 
                Description ="Deadlift - Instructions, Information & Alternatives The deadlift is a foundational compound exercise that builds maximum strength by lifting a weighted barbell from the floor to hip level. It primarily targets the posterior chain—glutes, hamstrings, and back—along with the core, promoting spinal stability and overall functional power. Key techniques include a neutral spine, hip-hinge movement, and driving through the feet. ", 
                Image = new Bitmap(AssetLoader.Open(new Uri("avares://Lab5/Assets/benchpress.png")))},
                
        new Exercice {ID = 3, Name ="PullUps", 
                Description ="A pull-up is a fundamental upper-body compound exercise where you hang from a bar with an overhand, shoulder-width grip and lift your body until your chin clears the bar. It primarily strengthens the latissimus dorsi (back), biceps, shoulders, and core, requiring full extension at the bottom and controlled descent", 
                Image = new Bitmap(AssetLoader.Open(new Uri("avares://Lab5/Assets/benchpress.png")))},
                
        new Exercice {ID = 4, Name ="Curls", 
                Description ="Bicep curls are foundational strength exercises targeting the biceps brachii, brachialis, and brachioradialis by flexing the elbow. Key forms include standing dumbbell/barbell curls (palms up), hammer curls (neutral grip), and preacher curls, focusing on controlled motion—lifting to shoulder height and lowering slowly—without using momentum or swinging the torso", 
                Image = new Bitmap(AssetLoader.Open(new Uri("avares://Lab5/Assets/benchpress.png"))),}
    };
    public Exercice? SelectedExercice { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        
        
        DataContext = this;
        
    }

    public void SeeExercicebtn_Click(object? sender, RoutedEventArgs e)
    {
        var nomExercice = ExercicesSelector.SelectedItem;
        
        if(nomExercice is Exercice ExoChoisi)
        {
            Console.WriteLine("exercice ajouté : " + ExoChoisi.Name);
            var fenetreDetails = new ExerciceDetailWindow(ExoChoisi);
    
            fenetreDetails.Show();
            
        }


    }
}
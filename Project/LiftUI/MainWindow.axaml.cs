using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace LiftUI;

public partial class MainWindow : Window {
    private Workout? currentWorkout;

    private readonly string[] catalogueExercices = {
        "Développé Couché", "Squat", "Soulevé de terre", "Traction",
        "Curl Biceps"
    };

    public MainWindow() {
        InitializeComponent();
        ExerciceSelector.ItemsSource = catalogueExercices;
    }

    // L'événement déclenché par ton clic
    private void StartWorkoutBtn_Click(object sender, RoutedEventArgs e) {
        currentWorkout = new Workout { Name = "" };
        currentWorkout.Start();
        ExercicesList.ItemsSource = currentWorkout.Exercices;
        LiveWorkoutTitle.Text =
            $"{currentWorkout.Name} started at {currentWorkout.StartTime.ToShortTimeString()}";
        StatusText.Foreground = Brushes.LightGreen;

        Acceuil.IsVisible = false;
        inWorkout.IsVisible = true;
    }

    private void AddExercicebtn_Click(object sender, RoutedEventArgs e) {
        // 1. On vérifie que la séance existe bien et qu'un exercice a été
        // sélectionné
        if (currentWorkout != null && ExerciceSelector.SelectedItem != null) {
            // 2. On récupère le nom de l'exercice choisi (ex: "Squat")
            string nomExercice = ExerciceSelector.SelectedItem.ToString()!;

            // 3. On crée la coquille de l'exercice en mémoire
            var nouvelExercice = new Exercice { Name = nomExercice };

            // 4. On l'ajoute à la liste de ta séance !
            currentWorkout.Exercices.Add(nouvelExercice);

            // Petit retour visuel dans la console pour te prouver que ça marche
            Console.WriteLine(
                $"[LIFT] Ajout de l'exercice : {nomExercice}. Total des exercices : {currentWorkout.Exercices.Count}");

            ExerciceSelector.SelectedIndex = -1;
        }
    }

    private void AddSetBtn_Click(object sender, RoutedEventArgs e) {
        var btn = sender as Button;

        var exercice = btn?.DataContext as Exercice;

        if (exercice != null) {
            exercice.Sets.Add(new Set { Weight = 0, Reps = 0 });

            Console.WriteLine(
                $"[LIFT] Série ajoutée pour l'exercice : {exercice.Name}");
        }
    }
    private void Endworkoutbtn_Click(object sender, RoutedEventArgs e) {
        inWorkout.IsVisible = false;
        EndWorkout.IsVisible = true;

        currentWorkout.Finish();

        var minutes = currentWorkout.Duration.TotalMinutes;

        end_of_workout_txt.Text = $"End of workout !\n" +
                              $"Duration : {minutes:F0} minutes\n" +
                              $"Total Volume : {currentWorkout.TotalVolume()} kg";
        

        /*using (var db = new LiftContext())
    {
        db.Workouts.Add(currentWorkout);
        db.SaveChanges();
    }*/
    }
}
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Lab5.Views;

public partial class ExerciceDetailWindow : Window
{
    public ExerciceDetailWindow()
    {
        InitializeComponent();
    }

    public ExerciceDetailWindow(Exercice exoRecu)
    {
        InitializeComponent();
        
        DataContext = exoRecu;
    }

    public void GetBackHome_Click(object? sender, RoutedEventArgs e){
        this.Close();
    }
}

using System;
using System.Collections.Generic;
using System.IO; // Pour écrire dans le fichier
using System.Linq; // Pour le filtrage facile
using System.Windows;
using System.Windows.Controls;

namespace MusicLab
{
    public partial class MainWindow : Window
    {
        // On garde une liste principale de tous les groupes
        List<Band> allBands = new List<Band>();

        public MainWindow()
        {
            InitializeComponent();
            LoadData(); // On crée les fausses données au démarrage
        }

        private void LoadData()
        {
            [cite_start]// Création des 6 groupes demandés [cite: 11]
            RockBand b1 = new RockBand("The Rockers", 1990, "Tom, Brad, Mike");
            PopBand b2 = new PopBand("Spice Gals", 1996, "Emma, Mel, Vic");
            IndieBand b3 = new IndieBand("Arctic Monkeys", 2002, "Alex, Jamie");
            RockBand b4 = new RockBand("Nirvana", 1987, "Kurt, Dave, Krist");
            PopBand b5 = new PopBand("ABBA", 1972, "Agnetha, Bjorn");
            IndieBand b6 = new IndieBand("Tame Impala", 2010, "Kevin Parker");

            // On ajoute tout à la liste
            allBands.Add(b1); allBands.Add(b2); allBands.Add(b3);
            allBands.Add(b4); allBands.Add(b5); allBands.Add(b6);

            [cite_start]// On trie la liste (grâce à IComparable qu'on a fait avant) 
            allBands.Sort();

            [cite_start]// Génération d'albums aléatoires [cite: 18]
            Random r = new Random();
            foreach(var band in allBands)
            {
                // On crée 2 albums bidons pour chaque groupe
                band.Albums.Add(new Album { Name = "Greatest Hits", Sales = r.Next(1000, 500000), Released = new DateTime(r.Next(1980, 2020), 1, 1) });
                band.Albums.Add(new Album { Name = "Live", Sales = r.Next(1000, 500000), Released = new DateTime(r.Next(1980, 2020), 1, 1) });
            }

            [cite_start]// On remplit la ComboBox des genres [cite: 20]
            cbGenre.ItemsSource = new string[] { "All", "RockBand", "PopBand", "IndieBand" };

            // On affiche tout dans la liste
            UpdateBandList(allBands);
        }

        // Méthode pour mettre à jour l'affichage de la liste
        private void UpdateBandList(List<Band> bandsToShow)
        {
            lbBands.ItemsSource = null; // Reset
            lbBands.ItemsSource = bandsToShow;
        }

        [cite_start]// Quand on clique sur un groupe [cite: 19]
        private void lbBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selected = lbBands.SelectedItem as Band;
            if (selected != null)
            {
                txtFormed.Text = $"Formed: {selected.YearFormed}";
                txtMembers.Text = $"Members: {selected.Members}";
                
                // Afficher les albums avec l'année calculée
                [cite_start]// Ici on fait une petite liste de strings pour l'affichage propre [cite: 21]
                List<string> albumDisplay = new List<string>();
                foreach(var alb in selected.Albums)
                {
                    albumDisplay.Add($"{alb.Name} - {alb.GetYearsSinceRelease()}");
                }
                lbAlbums.ItemsSource = albumDisplay;
            }
        }

        [cite_start]// Quand on filtre par genre [cite: 20]
        private void cbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string genre = cbGenre.SelectedItem as string;
            if (genre == "All" || genre == null)
            {
                UpdateBandList(allBands);
            }
            else
            {
                // On utilise LINQ ici pour filtrer. 
                // Ça dit : "Prends les groupes où le Type est égal au genre choisi"
                var filtered = allBands.Where(b => b.GetType().Name == genre).ToList();
                UpdateBandList(filtered);
            }
        }

        [cite_start]// Sauvegarder dans un fichier [cite: 22]
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("bands_info.txt"))
            {
                foreach(var band in allBands)
                {
                    sw.WriteLine($"{band.BandName} - {band.GetType().Name}");
                    sw.WriteLine($"Members: {band.Members}");
                    sw.WriteLine("Albums:");
                    foreach(var alb in band.Albums)
                    {
                        sw.WriteLine($" - {alb.Name} ({alb.Sales} sales)");
                    }
                    sw.WriteLine("----------------");
                }
            }
            MessageBox.Show("Saved!");
        }
    }
}
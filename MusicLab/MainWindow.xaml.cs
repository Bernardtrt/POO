using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq; 
using System.Windows;
using System.Windows.Controls;

namespace MusicLab
{
    public partial class MainWindow : Window
    {
        List<Band> allBands = new List<Band>();

        public MainWindow()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void LoadData()
        {
            // Création des groupes
            RockBand b1 = new RockBand("The Rockers", 1990, "Tom, Brad, Mike");
            PopBand b2 = new PopBand("Spice Gals", 1996, "Emma, Mel, Vic");
            IndieBand b3 = new IndieBand("Arctic Monkeys", 2002, "Alex, Jamie");
            RockBand b4 = new RockBand("Nirvana", 1987, "Kurt, Dave, Krist");
            PopBand b5 = new PopBand("ABBA", 1972, "Agnetha, Bjorn");
            IndieBand b6 = new IndieBand("Tame Impala", 2010, "Kevin Parker");

            allBands.Add(b1); allBands.Add(b2); allBands.Add(b3);
            allBands.Add(b4); allBands.Add(b5); allBands.Add(b6);

            allBands.Sort();

            Random r = new Random();
            foreach(var band in allBands)
            {
                band.Albums.Add(new Album { Name = "Greatest Hits", Sales = r.Next(1000, 500000), Released = new DateTime(r.Next(1980, 2020), 1, 1) });
                band.Albums.Add(new Album { Name = "Live", Sales = r.Next(1000, 500000), Released = new DateTime(r.Next(1980, 2020), 1, 1) });
            }

            cbGenre.ItemsSource = new string[] { "All", "RockBand", "PopBand", "IndieBand" };

            UpdateBandList(allBands);
        }

        private void UpdateBandList(List<Band> bandsToShow)
        {
            lbBands.ItemsSource = null; 
            lbBands.ItemsSource = bandsToShow;
        }

        private void lbBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selected = lbBands.SelectedItem as Band;
            if (selected != null)
            {
                txtFormed.Text = $"Formed: {selected.YearFormed}";
                txtMembers.Text = $"Members: {selected.Members}";
                
                List<string> albumDisplay = new List<string>();
                foreach(var alb in selected.Albums)
                {
                    albumDisplay.Add($"{alb.Name} - {alb.GetYearsSinceRelease()}");
                }
                lbAlbums.ItemsSource = albumDisplay;
            }
        }

        private void cbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string genre = cbGenre.SelectedItem as string;
            if (genre == "All" || genre == null)
            {
                UpdateBandList(allBands);
            }
            else
            {
                var filtered = allBands.Where(b => b.GetType().Name == genre).ToList();
                UpdateBandList(filtered);
            }
        }

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
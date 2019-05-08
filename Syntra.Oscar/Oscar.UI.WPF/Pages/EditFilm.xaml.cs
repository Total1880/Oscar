﻿using Oscar.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oscar.UI.WPF
{
    /// <summary>
    /// Interaction logic for EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Page
    {
        public EditFilm()
        {
            InitializeComponent();
        }

        private void BtnAddFilm_Click(object sender, RoutedEventArgs e)
        {
            // Create new instance of Films.
            Films film = new Films();

            // Load all the text into this instance.
            film.FilmId = Guid.NewGuid();
            film.FilmTitle = txtFilmTitle.Text;
            film.ReleaseYear = Convert.ToInt32(txtReleaseYear.Text);
            film.FilmLengthInMinutes = Convert.ToInt32(txtDuration.Text);
            film.FilmPlot = txtPlot.Text;
            // Genre still needs some attention.
            //film.FilmGenre = txtGenre.Text;

            // Insert the new film into the database.
            DatabaseManager.Instance.FilmRepository.InsertFilm(film);

            // Navigate back to the AdminFilmsManagement page.
            NavigationService.Navigate(new Pages.AdminFilmsManagement());            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AdminFilmsManagement());
        }

        //////////////////////////////////
        // Functions.

        // This function clears out all the text boxes.
        private void ClearTextBoxes()
        {
            txtFilmTitle.Text = string.Empty;
            txtReleaseYear.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtPlot.Text = string.Empty;
            txtGenre.Text = string.Empty;
        }

        // This function fills in the text boxes with the properties inside the singleton object.
        private void FillTextBoxes()
        {
            txtFilmTitle.Text = SingletonClasses.SingletonFilms.OnlyInstanceOfFilms.FilmTitle;
            txtReleaseYear.Text = Convert.ToString(SingletonClasses.SingletonFilms.OnlyInstanceOfFilms.ReleaseYear);
            txtDuration.Text = Convert.ToString(SingletonClasses.SingletonFilms.OnlyInstanceOfFilms.FilmLengthInMinutes);
            txtPlot.Text = SingletonClasses.SingletonFilms.OnlyInstanceOfFilms.FilmPlot;
            txtGenre.Text = Convert.ToString(SingletonClasses.SingletonFilms.OnlyInstanceOfFilms.FilmGenre);
        }        

        //////////////////////////////////
        // Loaded event.
        private void LoadedEditFilm(object sender, RoutedEventArgs e)
        {
            if (SingletonClasses.SingletonFilms.OnlyInstanceOfFilms.FilmTitle != string.Empty)
            {
                // Disable the add button and enable the Edit button.
                btnAddFilm.IsEnabled = false;
                btnEditFilm.IsEnabled = true;

                // Fill the text boxes with the properties inside the singleton object.
                FillTextBoxes();                
            }
            else
            {
                // Enable the add button and disable the Edit button.
                btnAddFilm.IsEnabled = true;
                btnEditFilm.IsEnabled = false;

                // Clear the text boxes.
                ClearTextBoxes();
            }
        }

        private void BtnEditFilm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
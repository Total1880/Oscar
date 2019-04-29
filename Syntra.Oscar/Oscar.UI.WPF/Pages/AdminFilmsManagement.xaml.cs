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

namespace Oscar.UI.WPF.Pages
{
    /// <summary>
    /// Interaction logic for AdminFilmsManagement.xaml
    /// </summary>
    public partial class AdminFilmsManagement : Page
    {
        // List to hold all the Films objects.
        List<Films> filmsList = new List<Films>();

        public AdminFilmsManagement()
        {
            InitializeComponent();
        }

        private void BtnLoadFilms_Click(object sender, RoutedEventArgs e)
        {
            ShowFilms();
        }

        private void ShowFilms()
        {
            filmsList = DatabaseManager.Instance.FilmRepository.GetFilms().ToList();
            LstFilms.Items.Clear();

            foreach (Films film in filmsList)
            {
                ListViewItem item = new ListViewItem();

                item.Tag = film;
                item.Content = film.FilmTitle;

                LstFilms.Items.Add(item);
            }
        }

        private void LoadFilms(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListViewItem item = ((ListViewItem)LstFilms.SelectedItem);
                Films film = (Films)item.Tag;

                txtFilmTitle.Text = Convert.ToString(film.FilmTitle);
                txtFilmReleaseYear.Text = Convert.ToString(film.ReleaseYear);

                //txtActorId.Text = Convert.ToString(actor.ActorId);
                //txtActorFirstName.Text = actor.FirstName;
                //txtActorLastName.Text = actor.LastName;
            }
            catch (Exception)
            {

            }
        }
    }
}
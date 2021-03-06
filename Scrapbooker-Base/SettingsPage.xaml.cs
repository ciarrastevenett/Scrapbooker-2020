﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace Scrapbooker_Base
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    //Reference to work with databases https://youtu.be/ZMXgJ3AhqRA
    public partial class SettingsPage : Page
    {
        private int albumSelected;
        private int tagSelected;
        public SettingsPage()
        {
            InitializeComponent();
            this.loadAbums();
            this.loadTags();

        }

        private void addAalbum_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            Album albumObject = new Album()
            {
                albumName = album_name.Text,
            };

            db.Albums.Add(albumObject);
            db.SaveChanges();
            this.loadAbums();
           
        }

        private void addTag_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            Tag tagObject = new Tag()
            {
                tagName = tag_name.Text,
            };

            db.Tags.Add(tagObject);
            db.SaveChanges();
            this.loadTags();
        }

        private void loadAbums()
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            this.album_list.ItemsSource = db.Albums.ToList();
        }

        private void loadTags()
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            this.tag_list.ItemsSource = db.Tags.ToList();
        }

        private void album_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Album album = (Album)album_list.SelectedItem;
            if (album is object)
            {
                albumSelected = album.id;
            };
        }

        private void deleteAlbum_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var selectedItem = from el in db.Albums
                               where el.id == this.albumSelected
                               select el;

            Album albumToDelete = selectedItem.SingleOrDefault();

            if(albumToDelete != null)
            {
                db.Albums.Remove(albumToDelete);
                db.SaveChanges();
            }
            this.loadAbums();
        }

        private void tag_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tag tag = (Tag)tag_list.SelectedItem;
            if (tag is object)
            {
                tagSelected = tag.id;
            };
        }

        private void deleteTag_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var selectedItem = from el in db.Tags
                               where el.id == this.tagSelected
                               select el;

            Tag tagToDelete = selectedItem.SingleOrDefault();

            if (tagToDelete != null)
            {
                db.Tags.Remove(tagToDelete);
                db.SaveChanges();
            }
            this.loadTags();
        }
    }
}

using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using HabitTracker.App.ViewModels;
using HabitTracker.Data;

namespace HabitTracker.App.Views
{
    public partial class HabitDaysListView : UserControl
    {
        public HabitDaysListView()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var viewModel = (HabitDaysListViewModel)this.DataContext!;
            var checkBox = (CheckBox)sender;
            DateTime.TryParse((string)checkBox.Content, out DateTime date);
            if (date > DateTime.Today) checkBox.IsChecked = false;

            using (var db = new HabitDbContext())
            {
                var d = db.HabitChecks.SingleOrDefault(b => b.Date == date);
                if (d is not null && checkBox.IsChecked == true)
                {
                    d.Date = date;
                    d.IsChecked = true;
                    db.SaveChanges();
                }
                var h = db.Habits.SingleOrDefault(h => h.Id == 1);
                if (h is not null &&
                ((date == viewModel.EndDate && checkBox.IsChecked == true) || (viewModel.EndDate < DateTime.Today)))
                {
                    h.IsFinished = true;
                    db.SaveChanges();
                    viewModel.mwvm.Content = new CongratulationsViewModel(viewModel.Items, viewModel.Motivation);
                    // File.Delete("../HabitTracker.Data/habits.db");
                    // File.Delete("../HabitTracker.Data/habits.db-shm");
                    // File.Delete("../HabitTracker.Data/habits.db-wal");
                }
            }
        }
    }
}

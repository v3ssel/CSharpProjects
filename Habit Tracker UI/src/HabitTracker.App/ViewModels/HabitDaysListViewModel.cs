using System;
using System.Collections.Generic;
using HabitTracker.Data;

namespace HabitTracker.App.ViewModels
{
    public class HabitDaysListViewModel : ViewModelBase
    {
        public MainWindowViewModel mwvm { get; set; }
        public DateTime EndDate { get; set; }
        public string Motivation { get; set; }
        public List<HabitCheck> Items { get; }

        public HabitDaysListViewModel(IEnumerable<HabitCheck> items, MainWindowViewModel main, string motivation, DateTime end)
        {
            mwvm = main;
            Motivation = motivation;
            EndDate = end;
            Items = new List<HabitCheck>(items);
        }

        public void ChangeContent(ViewModelBase vmb)
        {
            mwvm.Content = vmb;
        }
    }
}

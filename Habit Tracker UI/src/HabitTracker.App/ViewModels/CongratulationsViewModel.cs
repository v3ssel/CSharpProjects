using System.Linq;
using System.Collections.Generic;
using ReactiveUI;
using HabitTracker.Data;

namespace HabitTracker.App.ViewModels
{
    public class CongratulationsViewModel : ViewModelBase
    {
        private string? _totalDays;

        public string? TotalDays
        {
            get => _totalDays;
            set => this.RaiseAndSetIfChanged(ref _totalDays, value);
        }

        public CongratulationsViewModel(IEnumerable<HabitCheck> items, string Motivation)
        {
            TotalDays = $"Congratulations!\n{items.Count(x => x.IsChecked == true) + 1}/{items.Count()} days checked.\nFinally: {Motivation}\n\nP.S. Please delete database files)";
        }
    }
}

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HabitTracker.App.ViewModels;
using HabitTracker.App.Views;
using HabitTracker.Data;

namespace HabitTracker.App
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            using (var context = new HabitDbContext())
            {
                context.Database.EnsureCreated();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}

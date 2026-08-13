using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MiniPaintingApp.Services;
using MiniPaintingApp.ViewModels;
using MiniPaintingApp.Views;

namespace MiniPaintingApp;

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
                DataContext = new MainViewModel(
                    new ImageViewModel(
                        new ImageManipulationService()
                        )
                    ),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniPaintingApp.Models;

namespace MiniPaintingApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    /// Opens the file picker in which the user can pick a locally saved image.
    /// </summary>
    [ObservableProperty]
    public partial ImageViewModel ImageView { get; set; } = new ImageViewModel();
    
    [RelayCommand]
    private async Task LoadImage()
    {
        var topLevel = TopLevel.GetTopLevel(Application.Current?.ApplicationLifetime
        is IClassicDesktopStyleApplicationLifetime 
        desktopLifetime ? desktopLifetime.MainWindow : null);
        if (topLevel is null) return;
        Console.WriteLine("Top Level: " + topLevel);

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select an image file",
                FileTypeFilter = new[]
                {
                    FilePickerFileTypes.ImageAll
                }
            });
        if (files.Count > 0)
        {
            await using var stream = await files[0].OpenReadAsync();
            ImageView = new ImageViewModel() {ImagePath =  files[0].Path.AbsolutePath};
            ImageView.Image = new Bitmap(stream);
        }
    }
}

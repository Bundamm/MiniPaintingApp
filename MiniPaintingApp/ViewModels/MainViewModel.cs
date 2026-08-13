using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MiniPaintingApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    /// Main view model constructor
    /// </summary>
    /// <param name="imageViewModel"></param>
    public MainViewModel(ImageViewModel imageViewModel)
    {
        ImageView = imageViewModel;
    }
    
    /// <summary>
    /// Observable property of the ImageViewModel
    /// </summary>
    [ObservableProperty]
    public partial ImageViewModel ImageView { get; set; }
    
    
    /// <summary>
    /// Loads the chosen image on to the image Control
    /// </summary>
    [RelayCommand]
    private async Task LoadImage()
    {
        var topLevel = TopLevel.GetTopLevel(Application.Current?.ApplicationLifetime
        is IClassicDesktopStyleApplicationLifetime 
        desktopLifetime ? desktopLifetime.MainWindow : null);
        if (topLevel is null) return;


        var files = await topLevel.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select an image file",
                FileTypeFilter =
                [
                    FilePickerFileTypes.ImageAll
                ]
            });
        if (files.Count > 0)
        {
            await using var stream = await files[0].OpenReadAsync();
            ImageView.ImagePath = files[0].Path.AbsolutePath;
            ImageView.WriteableImage = WriteableBitmap.Decode(stream);
            Console.WriteLine(ImageView.WriteableImage.PixelSize);
        }
    }
    
    
    
}

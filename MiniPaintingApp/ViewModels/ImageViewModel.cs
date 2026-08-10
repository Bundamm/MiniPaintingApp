using System;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniPaintingApp.Models;

namespace MiniPaintingApp.ViewModels;

public partial class ImageViewModel : ViewModelBase
{
    /// <summary>
    /// Gets or sets the content of the Image.
    /// </summary>
    [ObservableProperty]
    public partial Bitmap? Image { get; set; }
    [ObservableProperty]
    public partial string? ImagePath { get; set; }
    
    public ImageViewModel()
    {
        //empty
    }

    public ImageModel ToImageModel()
    {
        return new ImageModel()
        {
            ImagePath = this.ImagePath,
            Image = this.Image
        };
    }
}

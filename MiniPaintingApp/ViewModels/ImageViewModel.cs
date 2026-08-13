using System;
using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniPaintingApp.Interfaces;
using MiniPaintingApp.Models;


namespace MiniPaintingApp.ViewModels;

public partial class ImageViewModel(IImageManipulationService imageManipulationService) : ViewModelBase
{
    /// <summary>
    /// Gets or sets the content of the Image.
    /// </summary>
    [ObservableProperty]
    public partial WriteableBitmap? WriteableImage { get; set; }
    
    /// <summary>
    /// Gets or sets the path of the Image.
    /// </summary>
    [ObservableProperty]
    public partial string? ImagePath { get; set; }
    
    /// <summary>
    /// Converts data from ImageViewModel into an ImageModel and returns it.
    /// </summary>
    /// <returns>ImageModel</returns>
    public ImageModel ToImageModel()
    {
        return new ImageModel()
        {
            ImagePath = this.ImagePath,
            Image = this.WriteableImage
        };
    }

    /// <summary>
    /// Returns the WriteableBitmap property.
    /// </summary>
    /// <returns></returns>
    public WriteableBitmap? GetImage()
    {
        return this.WriteableImage;
    }

    /// <summary>
    /// Uses the coordinates data from the MainWindowView and passes it on to ImageManipulationService which calculates the exact coordinates on the loaded image.
    /// </summary>
    /// <param name="cursorPoint"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void ConvertPointCoordinatesToActualImagePixels(Point cursorPoint)
    {
        if (this.WriteableImage is null)
        {
            throw new InvalidOperationException("Image is null");
        }
        Point imagePoint = imageManipulationService.ConvertCursorLocationToPixelLocation(cursorPoint, this.WriteableImage);
    }
    
}

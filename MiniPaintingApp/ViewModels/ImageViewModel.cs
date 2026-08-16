using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniPaintingApp.Interfaces;
using MiniPaintingApp.Models;


namespace MiniPaintingApp.ViewModels;

public partial class ImageViewModel(IImageInformationExtractionService imageInformationExtractionService) : ViewModelBase
{

    [ObservableProperty]
    public partial WriteableBitmap? WriteableImage { get; set; }
    
    [ObservableProperty]
    public partial bool DropperIsEnabled { get; set; }
    
    [ObservableProperty]
    public partial Color ColorValue {get; set;}
    
    [ObservableProperty]
    public partial IBrush ColoredBrush {get; set;}
    
    [ObservableProperty]
    public partial Point OriginalPoint { get; set; }

    [ObservableProperty]
    public partial string? ImagePath { get; set; }
    
    public ImageModel ToImageModel()
    {
        return new ImageModel()
        {
            ImagePath = this.ImagePath,
            Image = this.WriteableImage
        };
    }
    
    public WriteableBitmap? GetImage()
    {
        return this.WriteableImage;
    }
    
    public Point ConvertPointCoordinatesToActualImagePixels(Point cursorPoint, Point imageSize)
    {
        if (this.WriteableImage is null)
        {
            throw new InvalidOperationException("Image is null");
        }
        Point imagePoint = imageInformationExtractionService.ConvertCursorLocationToPixelLocation(cursorPoint, imageSize, this.WriteableImage);
        Console.WriteLine($"Location on original image: {imagePoint.X}, {imagePoint.Y}");
        OriginalPoint = imagePoint;
        SetColorValue(OriginalPoint);
        return imagePoint;
    }
    
    public void SetColorValue(Point actualPoint)
    {
        if (this.WriteableImage is null)
        {
            throw new InvalidOperationException("Image is null");
        }
        Color color = imageInformationExtractionService.ExtractColorFromBitmap(WriteableImage, actualPoint);
        ColorValue = color;
        ColoredBrush = imageInformationExtractionService.ConvertColorToBrush(color);
        Console.WriteLine($"Color value: {color.R}, {color.G}, {color.B}");
        
    }
}

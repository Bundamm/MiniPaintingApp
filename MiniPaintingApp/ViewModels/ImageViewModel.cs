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
    public partial ValueTuple<int,int> OriginalPoint { get; set; }

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
    
    public ValueTuple<int,int> ConvertCoordinatesToActualImagePixels(Point cursorPoint, Point imageSize)
    {
        if (this.WriteableImage is null)
        {
            throw new InvalidOperationException("Image is null");
        }
        ValueTuple<int,int> imagePoint = imageInformationExtractionService.ConvertCursorLocationToPixelLocation(cursorPoint, imageSize, this.WriteableImage);
        Console.WriteLine($"Location on original image: {imagePoint.Item1}, {imagePoint.Item2}");
        OriginalPoint = imagePoint;
        SetColorValue(OriginalPoint);
        return imagePoint;
    }
    
    public void SetColorValue(ValueTuple<int,int> actualCoordinates)
    {
        if (this.WriteableImage is null)
        {
            throw new InvalidOperationException("Image is null");
        }
        Color color = imageInformationExtractionService.ExtractColorFromBitmapUnsafe(WriteableImage, actualCoordinates);
        ColorValue = color;
        ColoredBrush = imageInformationExtractionService.ConvertColorToBrush(color);
        
    }
}

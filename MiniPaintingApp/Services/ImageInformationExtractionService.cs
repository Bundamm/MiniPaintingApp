using System;
using System.IO;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;

using MiniPaintingApp.Interfaces;
using SkiaSharp;

namespace MiniPaintingApp.Services;

public class ImageInformationExtractionService : IImageInformationExtractionService {

    public Point ConvertCursorLocationToPixelLocation(Point locationPoint, Point currentImageSize, WriteableBitmap bitmap)
    {
        var bitmapWidth = bitmap.Size.Width;
        var bitmapHeight = bitmap.Size.Height;

        var currentImageWidth = currentImageSize.X;
        var currentImageHeight = currentImageSize.Y;

        var scaleWidth = bitmapWidth / currentImageWidth;
        var scaleHeight = bitmapHeight / currentImageHeight;
        Console.WriteLine($"X Scale: {scaleWidth}, Y Scale: {scaleHeight}, Bitmap Width: {bitmapWidth}, Bitmap Height: {bitmapHeight} Current Image Width: {currentImageWidth}, Current Image Height: {currentImageHeight}");
        var originalBitmapPoint = new Point(Math.Round(locationPoint.X * scaleWidth), Math.Round(locationPoint.Y * scaleHeight));
        
        return originalBitmapPoint;
    }
    
    public Color ExtractColorFromBitmap(WriteableBitmap bitmap, Point exactPointOnImage)
    {
        MemoryStream stream = new MemoryStream();
        bitmap.Save(stream, options: new PngBitmapEncoderOptions());
        stream.Position = 0;
        SKBitmap skBitmap = SKBitmap.Decode(stream);
        SKColor colorAtPosition = skBitmap.GetPixel((int)exactPointOnImage.X, (int)exactPointOnImage.Y);
        byte red = colorAtPosition.Red;
        byte green = colorAtPosition.Green;
        byte blue = colorAtPosition.Blue;
        byte alpha = colorAtPosition.Alpha;
        return new Color(alpha, red, green, blue);
    }
    
    public IBrush ConvertColorToBrush(Color color)
    {
        return new SolidColorBrush(color);
    }
}

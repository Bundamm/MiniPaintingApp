using System;
using System.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Media.Immutable;
using MiniPaintingApp.Interfaces;
using SkiaSharp;

namespace MiniPaintingApp.Services;

public class ImageInformationExtractionService : IImageInformationExtractionService {
    /// <summary>
    /// Transforms the cursor coordinates into the exact coordinates on the loaded image.
    /// </summary>
    /// <param name="locationPoint"></param>
    /// <param name="currentImageSize"></param>
    /// <param name="bitmap"></param>
    /// <returns></returns>
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
        
        SKColor colorAtPixel = ExtractColorFromBitmap(bitmap, originalBitmapPoint); 
        Console.WriteLine($"Color at pixel: {colorAtPixel}");
        return originalBitmapPoint;
    }

    public SKColor ExtractColorFromBitmap(Bitmap bitmap, Point exactPointOnImage)
    {
        MemoryStream stream = new MemoryStream();
        bitmap.Save(stream, options: new PngBitmapEncoderOptions());
        stream.Position = 0;
        SKBitmap skBitmap = SKBitmap.Decode(stream);
        SKColor colorAtPosition = skBitmap.GetPixel((int)exactPointOnImage.X, (int)exactPointOnImage.Y);
        return colorAtPosition;
    }
}

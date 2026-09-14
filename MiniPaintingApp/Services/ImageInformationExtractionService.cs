using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using MiniPaintingApp.Interfaces;

namespace MiniPaintingApp.Services;

public class ImageInformationExtractionService : IImageInformationExtractionService {

    public ValueTuple<int,int> ConvertCursorLocationToPixelLocation(Point locationPoint, Point currentImageSize, WriteableBitmap bitmap)
    {
        var bitmapWidth = bitmap.Size.Width;
        var bitmapHeight = bitmap.Size.Height;

        var currentImageWidth = currentImageSize.X;
        var currentImageHeight = currentImageSize.Y;

        var scaleWidth = bitmapWidth / currentImageWidth;
        var scaleHeight = bitmapHeight / currentImageHeight;
        
        var originalBitmapPoint = new ValueTuple<int,int>((int)Math.Round(locationPoint.X * scaleWidth), (int)Math.Round(locationPoint.Y * scaleHeight));
        
        return originalBitmapPoint;
    }

    public unsafe Color ExtractColorFromBitmapUnsafe(WriteableBitmap bitmap, ValueTuple<int,int> exactPointOnImage)
    {
        int pixelStride = 4;
        int channels = 4;
        using ILockedFramebuffer locked = bitmap.Lock();
        nint channelAddress = locked.Address + exactPointOnImage.Item2 * locked.RowBytes + exactPointOnImage.Item1 * pixelStride;
        byte*[] channelPointers = new byte*[channels];
        for (int i = 0; i < channels; i++)
        {
            channelPointers[i] = (byte*)channelAddress.ToPointer() + i;
        }
        //TODO: ADD OS CHECKING FOR PROPER FORMAT RECOGNITION
        Color resultColor = new Color(a: *channelPointers[3], r: *channelPointers[2], g: *channelPointers[1],
            b: *channelPointers[0]);
        Console.WriteLine($"Color Result: {resultColor.R}, {resultColor.G}, {resultColor.B}");
        return resultColor;
    }
    
    public IBrush ConvertColorToBrush(Color color)
    {
        return new SolidColorBrush(color);
    }
} 

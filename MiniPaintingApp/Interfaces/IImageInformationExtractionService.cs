using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace MiniPaintingApp.Interfaces;

public interface IImageInformationExtractionService
{
    public ValueTuple<int,int> ConvertCursorLocationToPixelLocation(Point locationPoint, Point currentImageSize, WriteableBitmap bitmap);
    public Color ExtractColorFromBitmapUnsafe(WriteableBitmap bitmap, ValueTuple<int,int> originalLocation);
    public IBrush ConvertColorToBrush(Color color);
}
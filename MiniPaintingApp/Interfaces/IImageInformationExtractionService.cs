using Avalonia;
using Avalonia.Media.Imaging;

namespace MiniPaintingApp.Interfaces;

public interface IImageInformationExtractionService
{
    public Point ConvertCursorLocationToPixelLocation(Point locationPoint, WriteableBitmap bitmap);
}
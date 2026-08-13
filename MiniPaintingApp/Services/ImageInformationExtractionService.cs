using Avalonia;
using Avalonia.Media.Imaging;
using MiniPaintingApp.Interfaces;

namespace MiniPaintingApp.Services;

public class ImageInformationExtractionService : IImageInformationExtractionService
{
    /// <summary>
    /// Transforms the cursor coordinates into the exact coordinates on the loaded image.
    /// </summary>
    /// <param name="locationPoint"></param>
    /// <param name="bitmap"></param>
    /// <returns></returns>
    public Point ConvertCursorLocationToPixelLocation(Point locationPoint, WriteableBitmap bitmap)
    {
        return new Point(locationPoint.X, locationPoint.Y);
    }
}
using Avalonia;
using Avalonia.Media.Imaging;

namespace MiniPaintingApp.Interfaces;

public interface IImageManipulationService
{
    public Point ConvertCursorLocationToPixelLocation(Point locationPoint, WriteableBitmap bitmap);
}
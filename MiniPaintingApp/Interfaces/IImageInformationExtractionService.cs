using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace MiniPaintingApp.Interfaces;

public interface IImageInformationExtractionService
{
    public Point ConvertCursorLocationToPixelLocation(Point locationPoint, Point currentImageSize, WriteableBitmap bitmap);
    public Color ExtractColorFromBitmap(WriteableBitmap bitmap, Point originalLocation);
    public IBrush ConvertColorToBrush(Color color);
}
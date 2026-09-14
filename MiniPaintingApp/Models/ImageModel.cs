using Avalonia.Media.Imaging;

namespace MiniPaintingApp.Models;

public class ImageModel
{
    // Path to the image
    public string? ImagePath { get; set; }
    
    // In app name of the image
    public string? ImageName { get; set; }
    
    // Bitmap of the image
    public WriteableBitmap? Image { get; set; }
}
using Avalonia.Media.Imaging;

namespace MiniPaintingApp.Models;

public class ImageModel
{
    // Path to the image
    public string? ImagePath { get; set; }
    
    // Bitmap of the image
    public Bitmap? Image { get; set; }
}
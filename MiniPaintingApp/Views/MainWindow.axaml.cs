using System;
using Avalonia;
using MiniPaintingApp.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;


namespace MiniPaintingApp.Views;

public partial class MainWindow : Window
{
    
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void PointerPressedHandler(object sender, PointerPressedEventArgs args)
    {
        var point = args.GetCurrentPoint(sender as Control);
        var x = point.Position.X;
        var y = point.Position.Y;
        
        if (point.Properties.IsLeftButtonPressed)
        {
            if (sender is Image image)
            {
                double width = image.Bounds.Width;
                double height = image.Bounds.Height;
                Console.WriteLine($"Cursor Location: {x}, {y}, Image Size: {Math.Round(image.Bounds.Width, 2)}, {Math.Round(image.Bounds.Height, 2)}");

                if (DataContext is MainViewModel mainView)
                {
                    var pixelLocation = mainView.ImageView.ConvertPointCoordinatesToActualImagePixels(new Point(x, y), new Point(width, height));
                    Console.WriteLine($"Pixel Location: {pixelLocation.X}, {pixelLocation.Y}");
                }
            }
        }
    }
}

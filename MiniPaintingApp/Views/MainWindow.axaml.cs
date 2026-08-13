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
            Console.WriteLine($"Cursor Location: {x}, {y}");
            
            // imageViewModel.ConvertPointCoordinatesToActualImagePixels(new Point(x, y));
            if (DataContext is MainViewModel mainView)
            {
                mainView.ImageView.ConvertPointCoordinatesToActualImagePixels(new Point(x, y));
            }
        }
    }
}

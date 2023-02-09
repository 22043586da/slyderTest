using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace slyder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private double _scrollPosition;
        //private System.Windows.Point _mouseDownPosition;
        private List<BitmapImage> _images;
        private int _currentPosition;

        private int _defaultImageWidth = 1024;
        private int _defaultImageHeight = 512;
        public MainWindow()
        {
            InitializeComponent();

            List<string> pictureNames = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" };

            List<BitmapImage> images = new List<BitmapImage>();

            foreach (var pictureName in pictureNames)
            {
                try
                {
                    images.Add(new BitmapImage { UriSource = new Uri($@"pack://application:,,,/Resources/{pictureName}"), DecodePixelWidth = 512, DecodePixelHeight = 314 });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Файл не найден {pictureName}\n{ex.Message}");
                }
            }

            _images = images;
            addImageInGR(_images[0]);

            //if (images.Count > 0) 
            //{
            //    CombinedImage = GetCombinedImage(images).;
            //}

            //int index = 0;
            //foreach (Image image in canvas.Children)
            //{
            //    BitmapImage bitmap = new BitmapImage(new Uri(image.Source.ToString()));
            //    image.Width = bitmap.PixelWidth;
            //    image.Height = bitmap.PixelHeight;
            //    Canvas.SetLeft(image, index * bitmap.PixelWidth);
            //    index++;
            //}

            ////canvas.PreviewMouseWheel += Canvas_PreviewMouseWheel;
            //canvas.PreviewMouseLeftButtonDown += Canvas_PreviewMouseLeftButtonDown;
            //canvas.PreviewMouseLeftButtonUp += Canvas_PreviewMouseLeftButtonUp;
            //canvas.PreviewMouseMove += Canvas_PreviewMouseMove;
        }

        private void addImageInGR(BitmapImage bitmapImage)
        {
            ScrollBG.Children.Add(new Image { Source = bitmapImage as ImageSource, Width = _defaultImageWidth, Height = _defaultImageHeight, Stretch = Stretch.Fill});
        }

        private void leftbtn_Click(object sender, RoutedEventArgs e)
        {
            _currentPosition -= 1;
            if (_currentPosition < 0)
                _currentPosition = _images.Count;

        }

        private void rightbtn_Click(object sender, RoutedEventArgs e)
        {
            _currentPosition += 1;
            if (_currentPosition > _images.Count)
                _currentPosition = 0;

        }

        //private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    _mouseDownPosition = e.GetPosition(canvas);
        //    canvas.CaptureMouse();
        //}

        //private void Canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    canvas.ReleaseMouseCapture();
        //}

        //private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (canvas.IsMouseCaptured)
        //    {
        //        System.Windows.Point mouseMovePosition = e.GetPosition(canvas);
        //        double delta = mouseMovePosition.X - _mouseDownPosition.X;
        //        _scrollPosition -= delta;
        //        _scrollPosition = Math.Max(0, Math.Min(_scrollPosition, canvas.Width - ActualWidth));

        //        foreach (Image image in canvas.Children)
        //        {
        //            Canvas.SetLeft(image, Canvas.GetLeft(image) + delta);
        //        }

        //        _mouseDownPosition = mouseMovePosition;
        //    }
        //}

        //private void Canvas_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    _scrollPosition -= e.Delta * 0.001;
        //    _scrollPosition = Math.Max(0, Math.Min(_scrollPosition, canvas.Width - ActualWidth));

        //    foreach (Image image in canvas.Children)
        //    {
        //        Canvas.SetLeft(image, Canvas.GetLeft(image) + _scrollPosition);
        //    }
        //}

        //private static RenderTargetBitmap GetCombinedImage(IEnumerable<BitmapImage> images)
        //{
        //    // Get total width of all images
        //    int totalWidthOfAllImages = images.Sum(p => (int)p.Width);
        //    // Get max height of all images
        //    int maxHeightOfAllImages = images.Max(p => (int)p.Height);

        //    DrawingVisual drawingVisual = new DrawingVisual();
        //    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
        //    {
        //        double xPos = 0;
        //        foreach (BitmapImage image in images)
        //        {
        //            drawingContext.DrawImage(image, new Rect(xPos, 0, image.Width, image.Height));
        //            xPos += image.Width;
        //        }
        //    }

        //    RenderTargetBitmap bmp = new RenderTargetBitmap(totalWidthOfAllImages, maxHeightOfAllImages, 96, 96, PixelFormats.Default);
        //    bmp.Render(drawingVisual);

        //    return bmp;
        //}

        //public ImageSource CombinedImage { get; private set; }

        //private void rightbtn_Click(object sender, RoutedEventArgs e)
        //{
        //    SkyrimBG.Viewport = new Rect(-500, 0, 1024, 768);
        //}


    }
}

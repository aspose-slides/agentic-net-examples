using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Output presentation path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ZoomFramesDemo.pptx");
        // Custom image file name
        string logoFileName = "logo.png";
        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), logoFileName);

        // Verify that the custom image exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add two empty slides based on the first slide layout
        ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Set background colors for the new slides
        slide2.Background.Type = BackgroundType.OwnBackground;
        slide2.Background.FillFormat.FillType = FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

        slide3.Background.Type = BackgroundType.OwnBackground;
        slide3.Background.FillFormat.FillType = FillType.Solid;
        slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

        // Add a zoom frame linking to slide2 without a custom image
        IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(50, 50, 100, 100, slide2);
        zoomFrame1.ShowBackground = false;

        // Load custom image into the presentation
        IPPImage image = presentation.Images.AddImage(Images.FromFile(imagePath));

        // Add a zoom frame linking to slide3 with the custom image
        IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(200, 50, 100, 100, slide3, image);
        zoomFrame2.LineFormat.Width = 5;
        zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
        zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
        zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();

        Console.WriteLine("Presentation saved to " + outputPath);
    }
}
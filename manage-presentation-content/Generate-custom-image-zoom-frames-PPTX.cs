using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ZoomFramesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output PPTX path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ZoomFramesDemo.pptx");

            // Define custom image file name and full path
            string imageFileName = "logo.png";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), imageFileName);

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add two empty slides that will be the targets of the zoom frames
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Set background for the first target slide
            slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

            // Set background for the second target slide
            slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

            // Add a zoom frame without a custom image linking to slide2
            Aspose.Slides.IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(150, 20, 50, 50, slide2);
            zoomFrame1.ShowBackground = true;

            // Load the custom image
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath));

            // Add a zoom frame with the custom image linking to slide3
            Aspose.Slides.IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(250, 20, 50, 50, slide3, image);
            zoomFrame2.LineFormat.Width = 5;
            zoomFrame2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
            zoomFrame2.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Ensure there are enough slides for zoom targets
        if (presentation.Slides.Count < 2)
        {
            Console.WriteLine("Presentation must contain at least two slides.");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            return;
        }

        // Add two new slides with custom backgrounds
        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide2.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Cyan;

        slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide3.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkKhaki;

        // Add first zoom frame (no image)
        Aspose.Slides.IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(50, 50, 100, 100, slide2);
        zoomFrame1.ShowBackground = true;
        zoomFrame1.TransitionDuration = 2.0f;

        // Prepare image for second zoom frame
        string logoFileName = "logo.png";
        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), logoFileName);
        Aspose.Slides.IPPImage image = null;
        if (File.Exists(imagePath))
        {
            image = presentation.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath));
        }

        // Add second zoom frame with image
        Aspose.Slides.IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(200, 50, 100, 100, slide3, image);
        zoomFrame2.LineFormat.Width = 5;
        zoomFrame2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.HotPink;
        zoomFrame2.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
        zoomFrame2.ShowBackground = false;
        zoomFrame2.TransitionDuration = 3.5f;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
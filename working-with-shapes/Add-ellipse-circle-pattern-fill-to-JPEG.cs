using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        string outputDir = "Output";
        if (!System.IO.Directory.Exists(outputDir))
        {
            System.IO.Directory.CreateDirectory(outputDir);
        }

        // Define file paths
        string presentationPath = System.IO.Path.Combine(outputDir, "EllipsePattern.pptx");
        string jpegPath = System.IO.Path.Combine(outputDir, "Slide1.jpg");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        Aspose.Slides.IShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

        // Apply a pattern fill (small circles) to the ellipse
        ellipse.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        ellipse.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.SmallConfetti;
        ellipse.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.White;
        ellipse.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.Black;

        // Save the presentation
        presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the slide as a JPEG image
        using (Aspose.Slides.IImage slideImage = slide.GetImage(1f, 1f))
        {
            slideImage.Save(jpegPath, Aspose.Slides.ImageFormat.Jpeg);
        }

        // Clean up resources
        presentation.Dispose();
    }
}
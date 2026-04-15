using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Output directory
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Apply radial gradient fill to each node's shape
        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
            {
                shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;
                shape.FillFormat.GradientFormat.GradientStops.Add(0f, Aspose.Slides.PresetColor.Purple);
                shape.FillFormat.GradientFormat.GradientStops.Add(1f, Aspose.Slides.PresetColor.Red);
            }
        }

        // Save the presentation
        string presentationPath = Path.Combine(outputDir, "SmartArtGradient.pptx");
        try
        {
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Export the slide as JPEG
        int scaleX = 1;
        int scaleY = 1;
        using (Aspose.Slides.IImage slideImage = slide.GetImage(scaleX, scaleY))
        {
            string jpegPath = Path.Combine(outputDir, "Slide1.jpg");
            slideImage.Save(jpegPath, Aspose.Slides.ImageFormat.Jpeg);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
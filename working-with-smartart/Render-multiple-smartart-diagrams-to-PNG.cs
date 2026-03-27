using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory for SmartArt images
        string outputDirectory = "SmartArtImages";
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add multiple SmartArt diagrams with different layouts
        Aspose.Slides.SmartArt.ISmartArt smartArtBlock = slide.Shapes.AddSmartArt(50f, 50f, 400f, 300f, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
        Aspose.Slides.SmartArt.ISmartArt smartArtProcess = slide.Shapes.AddSmartArt(500f, 50f, 400f, 300f, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess);

        // Export each SmartArt diagram to a high‑resolution PNG file named by its layout type
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                string layoutName = smartArt.Layout.ToString();

                // Use high scaling factors for high‑resolution output
                using (Aspose.Slides.IImage image = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 2f, 2f))
                {
                    string imagePath = Path.Combine(outputDirectory, layoutName + ".png");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                }
            }
        }

        // Save the presentation before exiting
        presentation.Save("SmartArtPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
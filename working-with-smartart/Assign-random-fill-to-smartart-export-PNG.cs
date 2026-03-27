using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

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
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                50, 50, 400, 300,
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Random color generator
            Random random = new Random();

            // Assign a random fill color to each shape in each node
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    int r = random.Next(256);
                    int g = random.Next(256);
                    int b = random.Next(256);
                    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(r, g, b);
                }
            }

            // Save the presentation (required before exit)
            string pptxPath = Path.Combine(outputDir, "result.pptx");
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export the slide as PNG
            Aspose.Slides.IImage slideImage = slide.GetImage();
            string pngPath = Path.Combine(outputDir, "slide.png");
            slideImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
        }
    }
}
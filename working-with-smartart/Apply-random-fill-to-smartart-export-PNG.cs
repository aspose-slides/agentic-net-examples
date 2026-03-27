using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram to the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

        // Random number generator for colors
        System.Random random = new System.Random();

        // Add several nodes and assign random fill colors to each shape in the node
        for (int i = 0; i < 5; i++)
        {
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
            node.TextFrame.Text = "Node " + i;

            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
            {
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            }
        }

        // Save the presentation (optional)
        presentation.Save("SmartArtRandomColors.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the slide as a high‑resolution PNG (2x scaling)
        float scaleX = 2f;
        float scaleY = 2f;
        using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save("SlideHighRes.png", Aspose.Slides.ImageFormat.Png);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
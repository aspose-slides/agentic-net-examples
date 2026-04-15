using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtRandomFill
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram of type ClosedChevronProcess
            Aspose.Slides.SmartArt.ISmartArt chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

            // Add several nodes with sample text
            for (int i = 0; i < 5; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = chevron.AllNodes.AddNode();
                node.TextFrame.Text = "Node " + (i + 1).ToString();
            }

            // Random number generator for colors
            System.Random random = new System.Random();

            // Assign a random solid fill color to each shape within each node
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in chevron.AllNodes)
            {
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    // Generate random RGB values
                    int r = random.Next(0, 256);
                    int g = random.Next(0, 256);
                    int b = random.Next(0, 256);
                    shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(r, g, b);
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("SmartArtRandomFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Export the slide as a high‑resolution PNG (2x scaling)
            try
            {
                Aspose.Slides.IImage slideImage = slide.GetImage(2f, 2f);
                slideImage.Save("SmartArtRandomFill.png", Aspose.Slides.ImageFormat.Png);
            }
            catch (NotSupportedException)
            {
                // Image format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
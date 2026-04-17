using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtRandomFillExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            string outputPptxPath = "SmartArtRandomFill.pptx";
            string outputPngPath = "Slide.png";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10,    // X position
                10,    // Y position
                800,   // Width
                60,    // Height
                Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

            // Add a few nodes with sample text
            for (int i = 0; i < 3; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
                node.TextFrame.Text = "Node " + i;
            }

            // Random number generator for colors
            System.Random random = new System.Random();

            // Assign a random solid fill color to each shape in each node
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    System.Drawing.Color randomColor = System.Drawing.Color.FromArgb(
                        255,
                        random.Next(256),
                        random.Next(256),
                        random.Next(256));
                    shape.FillFormat.SolidFillColor.Color = randomColor;
                }
            }

            // Save the presentation
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export the slide as a PNG image
            using (Aspose.Slides.IImage slideImage = slide.GetImage())
            {
                slideImage.Save(outputPngPath, Aspose.Slides.ImageFormat.Png);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
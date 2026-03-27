using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtRandomColorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            string pptxPath = "SmartArtRandomColors.pptx";
            string pngPath = "SmartArtSlide.png";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 200, SmartArtLayoutType.ClosedChevronProcess);

            // Add sample nodes (optional, for demonstration)
            ISmartArtNode node1 = smartArt.AllNodes.AddNode();
            node1.TextFrame.Text = "Node 1";
            ISmartArtNode node2 = smartArt.AllNodes.AddNode();
            node2.TextFrame.Text = "Node 2";

            // Random color generator
            Random random = new Random();

            // Assign a random solid fill color to each shape in every node
            foreach (ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = FillType.Solid;
                    Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    shape.FillFormat.SolidFillColor.Color = randomColor;
                }
            }

            // Save the presentation (required before exit)
            presentation.Save(pptxPath, SaveFormat.Pptx);

            // Export the slide as a PNG image
            using (IImage image = slide.GetImage())
            {
                image.Save(pngPath, ImageFormat.Png);
            }

            // Clean up resources
            presentation.Dispose();
        }
    }
}
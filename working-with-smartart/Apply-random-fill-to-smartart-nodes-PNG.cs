using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtRandomFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Initialize random number generator for colors
                Random rnd = new Random();

                // Iterate through all nodes in the SmartArt diagram
                ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                for (int i = 0; i < allNodes.Count; i++)
                {
                    ISmartArtNode node = allNodes[i];

                    // Each node can contain multiple shapes; apply color to each shape
                    ISmartArtShapeCollection shapes = node.Shapes;
                    for (int j = 0; j < shapes.Count; j++)
                    {
                        ISmartArtShape shape = shapes[j];
                        // Set solid fill type
                        shape.FillFormat.FillType = FillType.Solid;
                        // Assign a random color
                        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    }
                }

                // Export the slide containing the SmartArt as a PNG image
                using (IImage image = slide.GetImage())
                {
                    image.Save("SmartArt.png", ImageFormat.Png);
                }

                // Save the presentation to a PPTX file
                try
                {
                    pres.Save("SmartArtPresentation.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
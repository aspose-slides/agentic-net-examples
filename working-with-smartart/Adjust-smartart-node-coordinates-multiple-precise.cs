using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtCustomPosition
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Add SmartArt diagram (Organization Chart) to the first slide
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

            // Adjust positions for child nodes
            ISmartArtNode node;
            ISmartArtShape shape;

            // Node 1
            node = smartArt.AllNodes[1];
            shape = node.Shapes[1];
            shape.X += (shape.Width * 2);
            shape.Y -= (shape.Height / 2);

            // Node 2
            node = smartArt.AllNodes[2];
            shape = node.Shapes[1];
            shape.Width += (shape.Width / 2);

            // Node 3
            node = smartArt.AllNodes[3];
            shape = node.Shapes[1];
            shape.Height += (shape.Height / 2);

            // Node 4
            node = smartArt.AllNodes[4];
            shape = node.Shapes[1];
            shape.Rotation = 90;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a SmartArt diagram of OrganizationChart layout
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

            // Adjust the first node's shape position
            ISmartArtNode node = smartArt.AllNodes[1];
            ISmartArtShape shape = node.Shapes[1];
            shape.X += (shape.Width * 2);
            shape.Y -= (shape.Height / 2);

            // Adjust the second node's shape width
            node = smartArt.AllNodes[2];
            shape = node.Shapes[1];
            shape.Width += (shape.Width / 2);

            // Adjust the third node's shape height
            node = smartArt.AllNodes[3];
            shape = node.Shapes[1];
            shape.Height += (shape.Height / 2);

            // Rotate the fourth node's shape
            node = smartArt.AllNodes[4];
            shape = node.Shapes[1];
            shape.Rotation = 90;

            // Save the presentation
            string outputPath = "CustomSmartArt.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            // Input file not found
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
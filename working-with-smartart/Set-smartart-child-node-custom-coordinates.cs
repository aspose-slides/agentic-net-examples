// -----------------------------------------------------------------------------
// Example: Set smartart child node custom coordinates using C#
//
// Description:
// Demonstrates how to set custom coordinates, size, and rotation for individual
// SmartArt child nodes in a PowerPoint presentation using Aspose.Slides for .NET.
// The example creates an Organization Chart SmartArt, modifies the position,
// dimensions, and rotation of specific child node shapes, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Child Node, Custom Coordinates,
// Position, Size, Rotation, Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust layout of SmartArt elements programmatically.
// - Build tools to fine‑tune SmartArt node appearance in PPTX files.
// - Automate presentation styling tasks in .NET applications.
// - Validate and test SmartArt modifications before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[1];
            Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[1];
            shape.X += (shape.Width * 2);
            shape.Y -= (shape.Height / 2);

            node = smartArt.AllNodes[2];
            shape = node.Shapes[1];
            shape.Width += (shape.Width / 2);

            node = smartArt.AllNodes[3];
            shape = node.Shapes[1];
            shape.Height += (shape.Height / 2);

            node = smartArt.AllNodes[4];
            shape = node.Shapes[1];
            shape.Rotation = 90;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

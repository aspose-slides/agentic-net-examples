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
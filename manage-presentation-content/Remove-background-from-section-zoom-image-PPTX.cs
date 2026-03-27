using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Locate the first Section Zoom Frame on the first slide
        ISectionZoomFrame sectionZoom = null;
        foreach (IShape shape in pres.Slides[0].Shapes)
        {
            sectionZoom = shape as ISectionZoomFrame;
            if (sectionZoom != null)
                break;
        }

        // If a Section Zoom Frame is found, strip its background
        if (sectionZoom != null)
        {
            // ShowBackground property controls whether the zoom uses the destination slide's background
            sectionZoom.ShowBackground = false;
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
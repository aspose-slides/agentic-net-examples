using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Locate the first Ink shape on the slide
        Aspose.Slides.Ink.Ink inkShape = null;
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.Ink.Ink)
            {
                inkShape = (Aspose.Slides.Ink.Ink)shape;
                break;
            }
        }

        // If no Ink shape is found, exit
        if (inkShape == null)
        {
            Console.WriteLine("No Ink shape found on the slide.");
            presentation.Dispose();
            return;
        }

        // Adjust the height of the Ink shape (value in points)
        inkShape.Height = 200f;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
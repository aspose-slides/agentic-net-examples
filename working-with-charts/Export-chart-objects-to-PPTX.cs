using System;
using System.IO;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output files
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found: " + inputFile);
            return;
        }

        // Load the presentation containing charts
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
        {
            // Iterate through all slides and shapes to locate chart objects
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    if (shape is Aspose.Slides.Charts.IChart)
                    {
                        // Chart found – additional processing can be added here if needed
                    }
                }
            }

            // Save the presentation (which includes all chart objects) to a new PPTX file
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
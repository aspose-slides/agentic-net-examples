using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideZoomAdjuster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_zoom.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set zoom levels for slide view and notes view (percentage)
            presentation.ViewProperties.SlideViewProperties.Scale = 150; // 150% zoom for slides
            presentation.ViewProperties.NotesViewProperties.Scale = 150; // 150% zoom for notes

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            Console.WriteLine("Presentation saved with updated zoom levels to: " + outputPath);
        }
    }
}
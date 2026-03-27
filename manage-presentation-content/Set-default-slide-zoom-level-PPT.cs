using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation from the input file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set default zoom level for slide view and notes view (percentage)
            presentation.ViewProperties.SlideViewProperties.Scale = 150; // 150% zoom for slides
            presentation.ViewProperties.NotesViewProperties.Scale = 150; // 150% zoom for notes

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
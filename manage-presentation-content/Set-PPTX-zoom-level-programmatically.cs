using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_zoomed.pptx";

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set zoom level (percentage)
                    int zoomPercentage = 150; // Example: 150% zoom
                    presentation.ViewProperties.SlideViewProperties.Scale = zoomPercentage;
                    presentation.ViewProperties.NotesViewProperties.Scale = zoomPercentage;

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
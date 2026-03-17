using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation from a file
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Example processing: display the number of slides
                    int slideCount = presentation.Slides.Count;
                    Console.WriteLine("Number of slides: " + slideCount);

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during loading or saving
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation from the input file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Remove the slide at zero‑based index 0
                presentation.Slides.RemoveAt(0);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
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

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Remove the first slide using reference
                Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                pres.Slides.Remove(firstSlide);

                // Reset the first slide number to maintain correct numbering sequence
                pres.FirstSlideNumber = 2;

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported: {ex.Message}
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
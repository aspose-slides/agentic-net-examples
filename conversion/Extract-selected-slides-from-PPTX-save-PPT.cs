using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "selected_slides.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Define the slide numbers to extract (1‑based indexing)
                int[] slideIndices = new int[] { 2, 4, 5 }; // example slide numbers

                // Save only the selected slides to a new PPTX file
                pres.Save(outputPath, slideIndices, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported for saving.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
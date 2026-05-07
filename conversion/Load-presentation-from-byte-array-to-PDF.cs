using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation file path (to be read into a byte array)
        string inputPath = "input.pptx";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation file into a byte array
            byte[] presentationData = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            using (MemoryStream presentationStream = new MemoryStream(presentationData))
            {
                // Load the presentation from the memory stream
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationStream))
                {
                    // Save the presentation as PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                }
            }
        }
        catch (NotSupportedException)
        {
            // Comment: format not supported
            Console.WriteLine("The presentation format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
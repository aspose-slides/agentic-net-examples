using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source PPTX file
            string inputPath = "largePresentation.pptx";
            // Path where the presentation will be saved after processing
            string outputPath = "outputPresentation.pptx";

            // Load the presentation file into a byte array (binary BLOB)
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            // Create a memory stream from the byte array for efficient handling
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                // Load the presentation from the memory stream
                using (Presentation presentation = new Presentation(memoryStream))
                {
                    // Save the presentation to the specified output path
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
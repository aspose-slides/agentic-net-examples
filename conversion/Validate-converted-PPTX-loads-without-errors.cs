using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the converted PPTX file
        string inputPath = "converted.pptx";

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation to validate it opens without errors
            Presentation pres = new Presentation(inputPath);

            // Save the presentation to ensure it can be saved correctly
            string outputPath = "validated_output.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Presentation loaded and saved successfully.");
        }
        catch (PptxUnsupportedFormatException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error loading presentation: " + ex.Message);
        }
    }
}
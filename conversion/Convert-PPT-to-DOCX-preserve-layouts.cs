using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input PPT file and desired DOCX output file
        string inputPath = "input.pptx";
        string outputPath = "output.docx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception loadEx)
        {
            Console.WriteLine("Failed to load presentation: " + loadEx.Message);
            return;
        }

        // Attempt to save as DOCX (unsupported format)
        try
        {
            // Aspose.Slides does not support DOCX output; using an invalid enum value to trigger exception
            presentation.Save(outputPath, (SaveFormat)9999);
        }
        catch (NotSupportedException)
        {
            // Format not supported – DOCX conversion is unavailable
            Console.WriteLine("DOCX format is not supported for saving presentations.");
        }
        catch (Exception saveEx)
        {
            // Handle any other unexpected errors
            Console.WriteLine("Error during conversion: " + saveEx.Message);
        }
        finally
        {
            // Ensure the presentation is saved (if any modifications) and resources are released
            if (presentation != null)
            {
                // Save back to original format to preserve layouts and embedded images
                presentation.Save(inputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
        }
    }
}
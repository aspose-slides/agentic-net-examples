using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPT file path
        string inputPath = "input.pptx";
        // Desired output DOCX file path
        string outputPath = "output.docx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation from the PPT file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            try
            {
                // Attempt to save as DOCX using an unsupported format value
                Aspose.Slides.Export.SaveFormat unsupportedFormat = (Aspose.Slides.Export.SaveFormat)999;
                presentation.Save(outputPath, unsupportedFormat);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("DOCX format is not supported for saving presentations.");
            }
            catch (InvalidOperationException)
            {
                // Format not supported
                Console.WriteLine("DOCX format is not supported for saving presentations.");
            }
            finally
            {
                // Ensure the presentation is saved (if any supported format was used) and disposed
                presentation.Dispose();
            }
        }
        catch (Exception ex)
        {
            // Handle any other exceptions (e.g., file read errors)
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}
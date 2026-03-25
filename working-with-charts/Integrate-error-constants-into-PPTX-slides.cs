using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define file paths and error messages
        const string inputPath = "input.pptx";
        const string outputPath = "output.pptx";
        const string errorFileNotFound = "Input file not found.";
        const string errorReading = "Error reading presentation.";
        const string errorSaving = "Error saving presentation.";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine(errorFileNotFound);
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Aspose.Slides.PptxReadException readEx)
        {
            // Handle read exceptions
            Console.WriteLine(errorReading + " " + readEx.Message);
            return;
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine(errorReading + " " + ex.Message);
            return;
        }

        // Example operation: set slide size with EnsureFit scaling
        presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        try
        {
            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Aspose.Slides.PptxEditException editEx)
        {
            // Handle edit exceptions
            Console.WriteLine(errorSaving + " " + editEx.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions during save
            Console.WriteLine(errorSaving + " " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
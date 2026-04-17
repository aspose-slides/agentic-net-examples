using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

class Program
{
    static void Main()
    {
        // Define input and output file names
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        // Build full input path and verify existence
        string inputPath = Path.Combine(Environment.CurrentDirectory, inputFile);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Remove all unused layout slides
        try
        {
            Compress.RemoveUnusedLayoutSlides(pres);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during layout slide compression: " + ex.Message);
        }

        // Save the modified presentation
        try
        {
            pres.Save(outputFile, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
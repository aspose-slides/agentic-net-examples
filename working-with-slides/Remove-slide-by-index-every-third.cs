using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation pres = null;
        try
        {
            // Load the presentation
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported or other loading error
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Remove every third slide (indices 2,5,8,...) iterating backwards
        for (int i = pres.Slides.Count - 1; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0)
            {
                try
                {
                    pres.Slides.RemoveAt(i);
                }
                catch (Exception)
                {
                    // Handle removal exception if needed
                }
            }
        }

        // Save the modified presentation
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (pres != null)
                pres.Dispose();
        }
    }
}
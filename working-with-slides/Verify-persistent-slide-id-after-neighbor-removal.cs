using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Store original slide IDs
        long[] originalIds = new long[pres.Slides.Count];
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            originalIds[i] = pres.Slides[i].SlideId;
        }

        // Remove a neighboring slide (e.g., the slide at index 1)
        if (pres.Slides.Count > 1)
        {
            Aspose.Slides.ISlide slideToRemove = pres.Slides[1];
            pres.Slides.Remove(slideToRemove);
        }

        // Verify that remaining slide IDs are unchanged
        bool idsUnchanged = true;
        int minCount = Math.Min(originalIds.Length - 1, pres.Slides.Count);
        for (int i = 0; i < minCount; i++)
        {
            int originalIndex = (i >= 1) ? i + 1 : i;
            if (pres.Slides[i].SlideId != originalIds[originalIndex])
            {
                idsUnchanged = false;
                break;
            }
        }

        Console.WriteLine("Slide IDs unchanged: " + idsUnchanged);

        // Save the modified presentation
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
            pres.Dispose();
        }
    }
}
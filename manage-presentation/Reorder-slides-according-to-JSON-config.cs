using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the source presentation, JSON configuration, and output file
        string inputPath = "input.pptx";
        string configPath = "order.json";
        string outputPath = "output.pptx";

        // Verify that the source presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Verify that the JSON configuration file exists
        if (!File.Exists(configPath))
        {
            Console.WriteLine($"Configuration file not found: {configPath}");
            return;
        }

        // Load the custom slide order from the JSON file (expects an array of zero‑based indices)
        int[] newOrder;
        try
        {
            string json = File.ReadAllText(configPath);
            newOrder = JsonSerializer.Deserialize<int[]>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read configuration: {ex.Message}");
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }
        catch (PptUnsupportedFormatException)
        {
            Console.WriteLine("The file format is not supported.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load presentation: {ex.Message}");
            return;
        }

        // Validate the configuration length matches the number of slides
        if (newOrder == null || newOrder.Length != presentation.Slides.Count)
        {
            Console.WriteLine("Invalid slide order configuration.");
            presentation.Dispose();
            return;
        }

        // Preserve original slide references
        ISlide[] originalSlides = new ISlide[presentation.Slides.Count];
        for (int i = 0; i < originalSlides.Length; i++)
        {
            originalSlides[i] = presentation.Slides[i];
        }

        // Reorder slides according to the new order
        for (int targetIndex = 0; targetIndex < newOrder.Length; targetIndex++)
        {
            int sourceIndex = newOrder[targetIndex];
            ISlide slideToMove = originalSlides[sourceIndex];
            presentation.Slides.Reorder(targetIndex, slideToMove);
        }

        // Save the reordered presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save presentation: {ex.Message}");
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
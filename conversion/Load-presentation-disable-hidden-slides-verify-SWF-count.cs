using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Disable hidden slides in SWF export
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ShowHiddenSlides = false;

                // Calculate visible slide count
                int totalSlides = pres.Slides.Count;
                int hiddenSlides = pres.DocumentProperties.HiddenSlides;
                int visibleSlides = totalSlides - hiddenSlides;

                // Save as SWF with hidden slides excluded
                string swfPath = Path.Combine(Environment.CurrentDirectory, "output.swf");
                pres.Save(swfPath, SaveFormat.Swf, swfOptions);

                // Verify that visible slide count matches expected SWF slide count
                Console.WriteLine($"Total slides: {totalSlides}");
                Console.WriteLine($"Hidden slides: {hiddenSlides}");
                Console.WriteLine($"Visible slides (expected in SWF): {visibleSlides}");
                // Additional verification of SWF content can be performed here if needed.

                // Save presentation before exit
                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
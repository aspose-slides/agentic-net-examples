using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        // Output SWF path
        string outputSwfPath = Path.Combine(Environment.CurrentDirectory, "output.swf");
        // Optional output PPTX path to verify changes
        string outputPptxPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Hide the first slide (if any) to test hidden slide handling
            if (pres.Slides.Count > 0)
            {
                pres.Slides[0].Hidden = true;
            }

            // Save the modified presentation (optional, ensures changes are persisted)
            pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Configure SWF options to exclude hidden slides
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ShowHiddenSlides = false;

            // Save as SWF; hidden slide thumbnails will not be included
            pres.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            Console.WriteLine("SWF saved without hidden slide thumbnails.");
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation
        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Ensure there is at least one slide
        if (pres.Slides.Count == 0)
        {
            Console.WriteLine("No slides to process.");
            pres.Dispose();
            return;
        }

        // Get reference to the first slide
        Aspose.Slides.ISlide firstSlide = pres.Slides[0];

        // Check for embedded media in the slide
        bool hasMedia = false;
        foreach (Aspose.Slides.IShape shape in firstSlide.Shapes)
        {
            if (shape is Aspose.Slides.IVideoFrame ||
                shape is Aspose.Slides.IAudioFrame ||
                shape is Aspose.Slides.OleObjectFrame)
            {
                hasMedia = true;
                break;
            }
        }

        if (hasMedia)
        {
            Console.WriteLine("Slide contains embedded media. Removal aborted.");
        }
        else
        {
            // Remove slide using its ISlide reference
            pres.Slides.Remove(firstSlide);
            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Slide removed and presentation saved.");
        }

        // Dispose presentation
        pres.Dispose();
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate backwards to safely remove hidden slides
                for (int i = presentation.Slides.Count - 1; i >= 0; i--)
                {
                    ISlide slide = presentation.Slides[i];
                    if (slide.Hidden)
                    {
                        slide.Remove();
                    }
                }

                // Save the cleaned presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        // Handle unsupported format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
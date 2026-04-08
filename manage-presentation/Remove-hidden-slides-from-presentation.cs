using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Collect hidden slides
            List<ISlide> slidesToRemove = new List<ISlide>();
            foreach (ISlide slide in presentation.Slides)
            {
                if (slide.Hidden)
                {
                    slidesToRemove.Add(slide);
                }
            }

            // Remove hidden slides
            foreach (ISlide slide in slidesToRemove)
            {
                slide.Remove();
            }

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
        }
    }
}
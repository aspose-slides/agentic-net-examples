using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Check if the input file exists
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
                // Export each slide to JPEG with quality 90
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    using (IImage slideImage = slide.GetImage(1f, 1f))
                    {
                        string outputFile = $"Slide_{index + 1}.jpg";
                        slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg, 90);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
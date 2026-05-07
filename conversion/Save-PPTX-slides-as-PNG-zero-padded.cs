using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                int slideCount = pres.Slides.Count;
                int padLength = slideCount.ToString().Length;

                // Export each slide as a PNG with zero‑padded index
                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = pres.Slides[i];
                    string outputPath = $"slide_{(i + 1).ToString().PadLeft(padLength, '0')}.png";

                    // Use GetImage inside a using block and save as PNG
                    using (IImage image = slide.GetImage())
                    {
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
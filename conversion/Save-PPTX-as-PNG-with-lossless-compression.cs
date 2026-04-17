using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Apply lossless compression to all pictures (no compression)
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IPictureFrame pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            pictureFrame.PictureFormat.CompressImage(false, PicturesCompression.DocumentResolution);
                        }
                    }
                }

                // Export each slide as a PNG image using GetImage inside a using block
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    using (IImage image = slide.GetImage())
                    {
                        string outputPath = $"slide_{i + 1}.png";
                        image.Save(outputPath, ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting (optional)
                string savedPath = "output.pptx";
                pres.Save(savedPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
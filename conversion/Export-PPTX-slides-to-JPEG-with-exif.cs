using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";

        // Output directory for JPEG images
        string outputDir = "output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];

                    // Generate a full‑scale image of the slide
                    Aspose.Slides.IImage slideImage = slide.GetImage();

                    // Define the output JPEG file name
                    string jpegPath = Path.Combine(outputDir, "slide_" + (i + 1) + ".jpg");

                    // Save the slide as JPEG
                    slideImage.Save(jpegPath, Aspose.Slides.ImageFormat.Jpeg);

                    // -----------------------------------------------------------------
                    // Insert EXIF metadata (timestamp and source file name) here.
                    // Aspose.Slides does not expose direct EXIF editing; this placeholder
                    // indicates where a suitable API (e.g., using a third‑party library)
                    // would add the required metadata to the JPEG file.
                    // -----------------------------------------------------------------
                }

                // Save the presentation before exiting (lifecycle requirement)
                string savedPresentationPath = Path.Combine(outputDir, "presentation_saved.pptx");
                pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling (including external URL or web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
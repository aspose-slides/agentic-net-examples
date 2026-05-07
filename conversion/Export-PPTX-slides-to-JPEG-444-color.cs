using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToJpeg444
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation and output folder
            string inputPath = "input.pptx";
            string outputFolder = "output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Export each slide to JPEG with maximum quality (100) which uses 4:4:4 subsampling
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    // Get a full‑scale image of the slide
                    Aspose.Slides.IImage slideImage = slide.GetImage(1f, 1f);
                    // Build the output file name
                    string outputPath = Path.Combine(outputFolder, $"Slide_{index + 1}.jpg");
                    // Save the image as JPEG with quality 100
                    slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 100);
                }

                // Save the presentation before exiting (lifecycle requirement)
                presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions (e.g., network issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
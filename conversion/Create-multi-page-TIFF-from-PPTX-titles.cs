using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MultiPageTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "presentation.pptx";
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Directory for output TIFF files
                    string outputDir = Path.Combine(Path.GetDirectoryName(inputPath), "TiffPages");
                    if (!Directory.Exists(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Iterate through each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        // Access slide by index
                        ISlide slide = pres.Slides[i];

                        // Generate a filename based on slide number (as a placeholder for title)
                        string slideFileName = "Slide_" + (i + 1).ToString() + ".tiff";
                        string outputPath = Path.Combine(outputDir, slideFileName);

                        // Create TIFF options (default)
                        TiffOptions tiffOptions = new TiffOptions();

                        // Render slide to TIFF image
                        IImage tiffImage = slide.GetImage(tiffOptions);

                        // Save the TIFF image
                        tiffImage.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);
                        tiffImage.Dispose();
                    }

                    // Save the presentation before exiting (as per requirement)
                    string savedPresentationPath = Path.Combine(Path.GetDirectoryName(inputPath), "SavedPresentation.pptx");
                    pres.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
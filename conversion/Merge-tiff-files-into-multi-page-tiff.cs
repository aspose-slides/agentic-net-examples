using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergeTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output multi‑page TIFF path
            string outputTiffPath = Path.Combine(Environment.CurrentDirectory, "MergedOutput.tiff");

            // Create a new presentation to hold the images
            Presentation presentation = new Presentation();

            // Ensure there is at least one layout slide to use for empty slides
            if (presentation.LayoutSlides.Count == 0)
            {
                Console.WriteLine("No layout slides available in the presentation.");
                presentation.Dispose();
                return;
            }

            // Process each input file path passed as argument
            foreach (string inputPath in args)
            {
                try
                {
                    // Verify the file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load the TIFF image into the presentation's image collection
                    using (FileStream imageStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        IPPImage tiffImage = presentation.Images.AddImage(imageStream);

                        // Add a new empty slide based on the first layout slide
                        ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                        // Insert the image onto the slide as a picture frame
                        // Position at (0,0) and use the image's original dimensions
                        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, tiffImage.Width, tiffImage.Height, tiffImage);
                    }
                }
                catch (NotSupportedException)
                {
                    // The file format is not supported by Aspose.Slides
                    // Comment: format not supported.
                    Console.WriteLine($"Unsupported format: {inputPath}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine($"Error processing file '{inputPath}': {ex.Message}");
                }
            }

            // Save the combined presentation as a multi‑page TIFF
            try
            {
                TiffOptions tiffOptions = new TiffOptions();
                presentation.Save(outputTiffPath, SaveFormat.Tiff, tiffOptions);
                Console.WriteLine($"Merged TIFF saved to: {outputTiffPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save merged TIFF: {ex.Message}");
            }
            finally
            {
                // Ensure the presentation is disposed before exit
                presentation.Dispose();
            }
        }
    }
}
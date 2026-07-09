using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "InputPresentations");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ShapeThumbnails");

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string presentationPath in presentationFiles)
            {
                try
                {
                    // Check for supported formats (PPTX, PPT, ODP)
                    string extension = Path.GetExtension(presentationPath).ToLowerInvariant();
                    if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")
                    {
                        // Format not supported
                        // Comment: format not supported
                        continue;
                    }

                    // Load the presentation
                    Presentation presentation = new Presentation(presentationPath);
                    try
                    {
                        // Iterate through slides
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            ISlide slide = presentation.Slides[slideIndex];

                            // Iterate through shapes on the slide
                            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                            {
                                IShape shape = slide.Shapes[shapeIndex];

                                // Generate thumbnail for the shape
                                IImage shapeImage = shape.GetImage();

                                // Build output file name
                                string shapeFileName = Path.Combine(
                                    outputDirectory,
                                    Path.GetFileNameWithoutExtension(presentationPath) +
                                    "_Slide" + slide.SlideNumber +
                                    "_Shape" + shapeIndex + ".jpg");

                                // Save the thumbnail image
                                shapeImage.Save(shapeFileName, Aspose.Slides.ImageFormat.Jpeg);
                            }
                        }

                        // Save the presentation (no modifications) before exiting
                        presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    finally
                    {
                        // Ensure resources are released
                        presentation.Dispose();
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file access issues)
                    Console.WriteLine("Error processing file '" + presentationPath + "': " + ex.Message);
                }
            }
        }
    }
}
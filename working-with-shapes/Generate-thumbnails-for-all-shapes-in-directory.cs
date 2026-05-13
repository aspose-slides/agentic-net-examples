using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories (can be passed as arguments)
            string inputDirectory = args.Length > 0 ? args[0] : "InputPresentations";
            string outputDirectory = args.Length > 1 ? args[1] : "ShapeThumbnails";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Process each file in the input directory
            string[] presentationFiles = Directory.GetFiles(inputDirectory);
            foreach (string presentationPath in presentationFiles)
            {
                try
                {
                    // Check for supported formats (PPTX, PPT, ODP)
                    string fileExtension = Path.GetExtension(presentationPath).ToLowerInvariant();
                    if (fileExtension != ".pptx" && fileExtension != ".ppt" && fileExtension != ".odp")
                    {
                        // Format not supported – skip this file
                        // Unsupported format comment
                        continue;
                    }

                    // Load the presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);

                    // Iterate through slides
                    int slideIndex = 0;
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through shapes on the slide
                        int shapeIndex = 0;
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Generate thumbnail for the shape
                            Aspose.Slides.IImage shapeImage = shape.GetImage();

                            // Build output file name
                            string shapeFileName = Path.Combine(
                                outputDirectory,
                                Path.GetFileNameWithoutExtension(presentationPath) +
                                $"_slide{slideIndex}_shape{shapeIndex}.png");

                            // Save the thumbnail image
                            shapeImage.Save(shapeFileName, Aspose.Slides.ImageFormat.Png);

                            shapeIndex++;
                        }
                        slideIndex++;
                    }

                    // Save the presentation (no modifications) before exiting
                    presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported – comment handled above
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file access issues)
                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);
                }
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ValidateSlideTitlePlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file (can be passed as a command‑line argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            // Load the presentation with proper exception handling for unsupported formats
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    bool allSlidesValid = true;

                    // Iterate through all slides and check for a title placeholder
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Find shapes that are title placeholders
                        var titleShapes = SlideUtil.FindShapesByPlaceholderType(slide, PlaceholderType.Title);
                        if (titleShapes == null || titleShapes.Length == 0)
                        {
                            Console.WriteLine($"Slide {i + 1} does not contain a title placeholder.");
                            allSlidesValid = false;
                        }
                    }

                    if (allSlidesValid)
                    {
                        Console.WriteLine("All slides contain at least one title placeholder.");
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "validated_" + Path.GetFileName(inputPath));
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
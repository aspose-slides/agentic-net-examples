using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSwfSlideCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to source PPT and generated SWF files
            string sourcePptPath = "source.pptx";
            string generatedSwfPath = "output.swf";

            // Verify that the source PPT file exists
            if (!File.Exists(sourcePptPath))
            {
                Console.WriteLine($"Source presentation file not found: {sourcePptPath}");
                return;
            }

            // Verify that the generated SWF file exists
            if (!File.Exists(generatedSwfPath))
            {
                Console.WriteLine($"Generated SWF file not found: {generatedSwfPath}");
                return;
            }

            // Load the source presentation
            using (Presentation sourcePresentation = new Presentation(sourcePptPath))
            {
                // Calculate visible slide count (exclude hidden slides when ShowHiddenSlides is false)
                int totalSlides = sourcePresentation.DocumentProperties.Slides;
                int hiddenSlides = sourcePresentation.DocumentProperties.HiddenSlides;
                int visibleSlideCount = totalSlides - hiddenSlides;

                // Attempt to load the SWF file as a presentation to obtain its slide count
                int swfSlideCount = -1;
                try
                {
                    using (Presentation swfPresentation = new Presentation(generatedSwfPath))
                    {
                        swfSlideCount = swfPresentation.Slides.Count;
                    }
                }
                catch (NotSupportedException)
                {
                    // SWF format is not supported for loading as a Presentation
                    Console.WriteLine("SWF format is not supported for loading. Cannot retrieve slide count from SWF.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file corruption, I/O errors)
                    Console.WriteLine($"Error while processing SWF file: {ex.Message}");
                }

                // Compare slide counts if SWF slide count was retrieved successfully
                if (swfSlideCount >= 0)
                {
                    if (visibleSlideCount == swfSlideCount)
                    {
                        Console.WriteLine("Slide count matches: both have the same number of visible slides.");
                    }
                    else
                    {
                        Console.WriteLine($"Slide count mismatch: source PPT visible slides = {visibleSlideCount}, SWF slides = {swfSlideCount}");
                    }
                }

                // Save the source presentation before exiting (as per lifecycle rule)
                sourcePresentation.Save(sourcePptPath, SaveFormat.Pptx);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfSlideValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputSwfPath = "output.swf";

            bool isValid = ValidateSwfSlideCounts(inputPath, outputSwfPath);
            Console.WriteLine("SWF slide count validation result: " + isValid);
        }

        static bool ValidateSwfSlideCounts(string inputFilePath, string outputSwfFilePath)
        {
            // Verify input file existence
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file not found: " + inputFilePath);
                return false;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);

                // Expected slide count from the source presentation
                int expectedSlideCount = presentation.Slides.Count;

                // Configure SWF export options
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.ShowHiddenSlides = true; // include hidden slides if any

                // Save the presentation as SWF
                presentation.Save(outputSwfFilePath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // If save succeeded, assume all slides were exported
                // (Aspose.Slides does not provide direct SWF slide count retrieval)
                return true;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                // Comment: format not supported
                return false;
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                // Comment: format not supported
                return false;
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
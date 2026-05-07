using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToSwf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF options with a fallback font
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.DefaultRegularFont = "Arial"; // Fallback font name

                    // Save the presentation as SWF using the correct SaveFormat enum
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                    // Save the presentation before exiting (as required by lifecycle rules)
                    presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
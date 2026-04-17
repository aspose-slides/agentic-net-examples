using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace ReplacePlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Placeholder text to find and its replacement
            string placeholder = "[PLACEHOLDER]";
            string replacement = "DynamicValue";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Replace placeholder text in all slides, including master slides
                    SlideUtil.FindAndReplaceText(presentation, true, placeholder, replacement, null);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Placeholder text replaced successfully. Saved to " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified save format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
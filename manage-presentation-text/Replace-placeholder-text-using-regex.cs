using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace ReplacePlaceholderText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define the regular expression to find placeholder text (e.g., [PLACEHOLDER])
                    Regex placeholderRegex = new Regex(@"\[PLACEHOLDER\]");

                    // Retrieve all text frames, including those in master slides
                    ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(presentation, true);

                    // Replace each placeholder occurrence with the desired text
                    foreach (ITextFrame textFrame in textFrames)
                    {
                        textFrame.ReplaceRegex(placeholderRegex, "ActualValue", null);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GenerateSwf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output SWF file path
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
                    // Display default font substitution information
                    foreach (FontSubstitutionInfo substitutionInfo in presentation.FontsManager.GetSubstitutions())
                    {
                        Console.WriteLine(string.Format("{0} -> {1}", substitutionInfo.OriginalFontName, substitutionInfo.SubstitutedFontName));
                    }

                    // Create SWF options (default font substitution)
                    SwfOptions swfOptions = new SwfOptions();
                    // Example: set a default regular font if desired
                    // swfOptions.DefaultRegularFont = "Arial";

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported file format
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AuditSwfFontSubstitution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "presentation.pptx";
            string outputPath = "presentation.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF conversion options (optional)
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.DefaultRegularFont = "Arial";

                // Save the presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Log font substitution information
                Console.WriteLine("Font substitutions during conversion:");
                foreach (FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine(substitution.OriginalFontName + " -> " + substitution.SubstitutedFontName);
                }

                // Ensure the presentation is saved before exiting (already saved above)
                presentation.Dispose();
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
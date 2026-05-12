using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

namespace FontManagementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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

                // Retrieve embedded fonts
                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // List embedded fonts
                Console.WriteLine("Embedded fonts before deduplication:");
                foreach (IFontData font in embeddedFonts)
                {
                    Console.WriteLine("- " + font.FontName);
                }

                // Remove duplicate embedded fonts based on font name
                HashSet<string> seenFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (IFontData font in embeddedFonts)
                {
                    if (seenFontNames.Contains(font.FontName))
                    {
                        presentation.FontsManager.RemoveEmbeddedFont(font);
                    }
                    else
                    {
                        seenFontNames.Add(font.FontName);
                    }
                }

                // Compress remaining embedded fonts
                Compress.CompressEmbeddedFonts(presentation);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                // List embedded fonts after processing
                Console.WriteLine("Processing completed. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to unsupported format, the format is not supported.
            }
        }
    }
}
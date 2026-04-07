using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveEmbeddedFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            // Name of the embedded font to remove
            string fontNameToRemove = "Arial";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Record original file size
            long sizeBefore = new FileInfo(inputPath).Length;
            Console.WriteLine("Original file size: " + sizeBefore + " bytes");

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get all embedded fonts
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    // Find the font to remove
                    IFontData fontToRemove = null;
                    foreach (IFontData fontData in embeddedFonts)
                    {
                        if (string.Equals(fontData.FontName, fontNameToRemove, StringComparison.OrdinalIgnoreCase))
                        {
                            fontToRemove = fontData;
                            break;
                        }
                    }

                    if (fontToRemove != null)
                    {
                        // Remove the embedded font
                        presentation.FontsManager.RemoveEmbeddedFont(fontToRemove);
                        Console.WriteLine("Removed embedded font: " + fontNameToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Embedded font not found: " + fontNameToRemove);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                // Record new file size
                long sizeAfter = new FileInfo(outputPath).Length;
                Console.WriteLine("New file size: " + sizeAfter + " bytes");

                // Verify size decrease
                if (sizeAfter < sizeBefore)
                {
                    Console.WriteLine("File size decreased after removing the font.");
                }
                else
                {
                    Console.WriteLine("File size did not decrease.");
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                // format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                // format not supported
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
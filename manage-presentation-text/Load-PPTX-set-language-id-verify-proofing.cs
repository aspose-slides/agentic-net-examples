// -----------------------------------------------------------------------------
// Example: Load PPTX set language id verify proofing using C#
//
// Description:
// Demonstrates how to load a PPTX file, set the language identifier for each
// text portion, verify the language setting, and save the presentation using
// C# and Aspose.Slides for .NET. The example iterates through all slides,
// shapes, paragraphs, and portions, applying the language ID and outputting
// verification information to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Language, Verify, Proofing,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading PPTX files and setting language identifiers for proofing.
// - Build C# tools for PowerPoint text processing and language verification.
// - Generate or modify PPTX presentations with specific language settings in .NET.
// - Validate language configuration before publishing or further integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < presentation.Slides[slideIndex].Shapes.Count; shapeIndex++)
                        {
                            IShape shape = presentation.Slides[slideIndex].Shapes[shapeIndex];
                            // Process only AutoShapes that contain a TextFrame
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                // Iterate through paragraphs and portions
                                for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                                {
                                    IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                    {
                                        IPortion portion = paragraph.Portions[portionIndex];
                                        // Set language identifier (e.g., en-US)
                                        portion.PortionFormat.LanguageId = "en-US";
                                        // Verify and output the language identifier
                                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}, Portion {portionIndex + 1}: LanguageId = {portion.PortionFormat.LanguageId}");
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

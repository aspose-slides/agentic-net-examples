// -----------------------------------------------------------------------------
// Example: Load PPTX set Japanese language ID for title shape using C#
//
// Description:
// Demonstrates how to load a PPTX file, locate the centered title placeholder,
// and set its LanguageId to Japanese (ja-JP) for all text portions using
// Aspose.Slides for .NET. The example includes basic file existence checks,
// error handling, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Japanese, LanguageId, TitleShape, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting Japanese language metadata on title shapes in PPTX files.
// - Build C# utilities for localization of PowerPoint presentations.
// - Integrate language ID adjustments into .NET presentation workflows.
// - Validate and prepare PPTX files for Japanese audiences before distribution.
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
            // Define input and output file paths
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
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Iterate through shapes to find the title placeholder
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape.Placeholder != null && shape is IAutoShape)
                        {
                            // Check if the placeholder is a centered title
                            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle)
                            {
                                IAutoShape titleShape = (IAutoShape)shape;

                                // Set LanguageId to Japanese for all portions in the title shape
                                foreach (IParagraph paragraph in titleShape.TextFrame.Paragraphs)
                                {
                                    foreach (IPortion portion in paragraph.Portions)
                                    {
                                        portion.PortionFormat.LanguageId = "ja-JP";
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
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

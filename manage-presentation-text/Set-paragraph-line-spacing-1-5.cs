// -----------------------------------------------------------------------------
// Example: Set paragraph line spacing 1 5 using C#
//
// Description:
// Demonstrates how to set paragraph line spacing to 1.5 lines (150%) using
// C# and Aspose.Slides for .NET. The example loads a PPTX file, iterates over
// all text-containing AutoShapes, updates each paragraph's line spacing, and
// saves the modified presentation. This pattern can be used to automate
// paragraph formatting in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Paragraph, Line Spacing, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust line spacing of all paragraphs in a presentation to 1.5 lines.
// - Build tools that enforce consistent paragraph formatting across slides.
// - Process and transform PPTX files programmatically in .NET applications.
// - Prepare presentations for publishing with standardized spacing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetParagraphLineSpacing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only AutoShape objects that contain a TextFrame
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                            // Iterate through all paragraphs in the text frame
                            for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                            {
                                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                                // Set line spacing to 1.5 lines (150%)
                                paragraph.ParagraphFormat.SpaceWithin = 150f;
                                paragraph.ParagraphFormat.SpaceBefore = 0f;
                                paragraph.ParagraphFormat.SpaceAfter = 0f;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or other errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

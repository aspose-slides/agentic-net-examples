// -----------------------------------------------------------------------------
// Example: Edit hyperlink tooltip with updated text using C#
//
// Description:
// Demonstrates how to edit the tooltip of an existing hyperlink in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads a PPTX
// file, locates the first auto shape's first text portion, updates its
// hyperlink tooltip, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Edit, Hyperlink, Tooltip,
// Updated, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate updating hyperlink tooltips in existing presentations.
// - Build .NET utilities for refining PPTX content before distribution.
// - Integrate tooltip modifications into larger PowerPoint processing pipelines.
// - Ensure accessibility and clarity of hyperlink descriptions in slides.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesHyperlinkTooltipEdit
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

            // Load the presentation with proper exception handling
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported for PPTX files
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                return;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Format not supported for PPT files
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Assume the first shape on the first slide contains the mutable hyperlink
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes[0] as Aspose.Slides.IAutoShape;
            if (shape != null && shape.TextFrame != null && shape.TextFrame.Paragraphs.Count > 0 && shape.TextFrame.Paragraphs[0].Portions.Count > 0)
            {
                Aspose.Slides.IHyperlink hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
                if (hyperlink != null)
                {
                    // Update the tooltip of the existing hyperlink
                    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Updated descriptive tooltip";
                }
                else
                {
                    Console.WriteLine("No hyperlink found on the specified portion.");
                }
            }
            else
            {
                Console.WriteLine("Specified shape or text portion not found.");
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported for saving as PPTX
                Console.WriteLine("Unsupported format when saving: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}

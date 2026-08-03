// -----------------------------------------------------------------------------
// Example: Set paragraph alignment to justified using C#
//
// Description:
// Demonstrates how to set each paragraph's alignment to justified (low) in a
// PowerPoint presentation using Aspose.Slides for .NET. The example loads an
// existing PPTX file, iterates through all text frames (including those on
// master slides), applies the JustifyLow alignment, and saves the result as a
// new PPTX file. This pattern can be used in console applications or
// integrated into larger .NET solutions for automated presentation processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Paragraph, Alignment,
// JustifyLow, Justified, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting paragraph alignment to justified (low) across a presentation.
// - Build C# utilities for bulk text formatting in PowerPoint files.
// - Generate or transform PPTX files with consistent paragraph alignment.
// - Validate and test presentation formatting before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ParagraphAlignmentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output_justified.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation pres = null;
            try
            {
                // Load presentation
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // format not supported
                return;
            }

            // Get all text frames in the presentation (including master slides)
            ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(pres, true);

            // Iterate through each text frame and set paragraph alignment to justified
            foreach (ITextFrame textFrame in textFrames)
            {
                for (int i = 0; i < textFrame.Paragraphs.Count; i++)
                {
                    IParagraph paragraph = textFrame.Paragraphs[i];
                    paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.JustifyLow;
                }
            }

            try
            {
                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}

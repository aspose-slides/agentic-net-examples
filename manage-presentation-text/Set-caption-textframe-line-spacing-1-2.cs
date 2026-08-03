// -----------------------------------------------------------------------------
// Example: Set caption textframe line spacing 1.2 using C#
//
// Description:
// Demonstrates how to set the line spacing multiplier to 1.2 for all caption
// text frames in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads a presentation, retrieves every text frame (including those
// on master slides), updates each paragraph's SpaceWithin property to achieve
// the desired line spacing, and saves the modified file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Caption, TextFrame, Line Spacing,
// 1.2 multiplier, Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust line spacing of captions across an entire presentation.
// - Build C# utilities for consistent text formatting in PPTX files.
// - Automate presentation styling tasks in .NET applications.
// - Ensure uniform line spacing before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Retrieve all text frames, including those in master slides
            ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(presentation, true);

            // Apply a line spacing multiplier of 1.2 (represented as 120 points) to each paragraph
            foreach (ITextFrame textFrame in textFrames)
            {
                foreach (IParagraph paragraph in textFrame.Paragraphs)
                {
                    paragraph.ParagraphFormat.SpaceWithin = 120; // 1.2 multiplier
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported formats or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

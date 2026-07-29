// -----------------------------------------------------------------------------
// Example: Convert PPT to DOCX preserve layouts using C#
//
// Description:
// Demonstrates how to convert a PowerPoint presentation (PPTX) to a DOCX
// document while preserving slide layouts using C# and Aspose.Slides for .NET.
// The example loads a presentation, validates the input file, saves it in
// DOCX format, and handles potential errors in a console application.
// Developers can adapt this pattern to automate PPTX‑to‑DOCX conversions,
// integrate presentation processing into .NET solutions, or validate
// workflow outputs.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, Convert, Docx, Preserve,
// Layouts, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of PPTX files to DOCX while keeping original layouts.
// - Build C# utilities for PowerPoint presentation transformation.
// - Integrate DOCX export functionality into .NET applications.
// - Validate and test presentation conversion pipelines before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Desired output DOCX file path
        string outputPath = "output.docx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation from the PPTX file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation as DOCX preserving layouts
                presentation.Save(outputPath, SaveFormat.Docx);
                Console.WriteLine($"Presentation successfully converted to DOCX: {outputPath}");
            }
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("DOCX format is not supported for saving presentations.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("An error occurred while saving the presentation to DOCX.");
        }
        catch (Exception ex)
        {
            // Handle any other exceptions (e.g., file read errors)
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}

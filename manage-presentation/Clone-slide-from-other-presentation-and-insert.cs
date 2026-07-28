// -----------------------------------------------------------------------------
// Example: Clone slide from other presentation and insert using C#
//
// Description:
// Demonstrates how to clone a slide from a source presentation and insert it
// into a destination presentation at a specified position using C# and
// Aspose.Slides for .NET. The example loads two PPTX files, copies the first
// slide from the source, inserts it into the destination, and saves the result.
// This pattern can be used to automate slide reuse across presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Other,
// Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of a slide from one PowerPoint file to another.
// - Build C# tools for consolidating or reusing slides across presentations.
// - Generate customized PPTX files by inserting external slides at runtime.
// - Validate slide insertion workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string sourceFile = "SourcePresentation.pptx";
        string destinationFile = "DestinationPresentation.pptx";
        string outputFile = "ClonedPresentation.pptx";
        int insertPosition = 2; // zero‑based index where the slide will be inserted

        // Verify that the source file exists
        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Source file not found: " + sourceFile);
            return;
        }

        // Verify that the destination file exists
        if (!File.Exists(destinationFile))
        {
            Console.WriteLine("Destination file not found: " + destinationFile);
            return;
        }

        try
        {
            // Load the source presentation
            using (Presentation sourcePres = new Presentation(sourceFile))
            {
                // Load the destination presentation
                using (Presentation destPres = new Presentation(destinationFile))
                {
                    // Get the first slide from the source presentation
                    ISlide sourceSlide = sourcePres.Slides[0];

                    // Insert a clone of the source slide into the destination at the specified index
                    destPres.Slides.InsertClone(insertPosition, sourceSlide);

                    // Save the modified destination presentation
                    destPres.Save(outputFile, SaveFormat.Pptx);
                }
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // The file format is not supported
            Console.WriteLine("One of the files has an unsupported PPTX format.");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // The file format is not supported
            Console.WriteLine("One of the files has an unsupported PPT format.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

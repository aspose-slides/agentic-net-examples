// -----------------------------------------------------------------------------
// Example: Check unsigned PPTX slides for review using C#
//
// Description:
// Demonstrates how to check unsigned PPTX slides for review using C# and 
// Aspose.Slides for .NET. The example loads a presentation, determines whether
// it contains any digital signatures, reports the result, and saves the file.
// This pattern can be used to automate PPTX validation workflows in .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Check, Unsigned, Slides, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate checking of unsigned PPTX slides for review.
// - Build C# tools for PowerPoint presentation validation.
// - Integrate presentation verification into .NET applications.
// - Ensure presentations meet signing requirements before distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file path
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist: " + inputFile);
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputFile))
            {
                // Check for digital signatures
                if (pres.DigitalSignatures.Count == 0)
                {
                    Console.WriteLine("Presentation is unsigned. Flagging for review.");
                }
                else
                {
                    Console.WriteLine("Presentation has digital signatures.");
                }

                // Save presentation before exit
                string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputFile, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

// -----------------------------------------------------------------------------
// Example: List flash objects and output sizes using C#
//
// Description:
// Demonstrates how to enumerate ActiveX (Flash) controls in a PowerPoint presentation,
// retrieve their binary data, and output each object's name and size in bytes using
// Aspose.Slides for .NET. The example loads a PPTX file, scans all slides for flash
// objects, prints their details to the console, and saves the presentation unchanged.
// This pattern helps developers audit embedded flash content in presentations.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Flash, ActiveX, Control, Binary Data, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Identify and report embedded flash objects in PPTX files.
// - Validate size of ActiveX controls before publishing or conversion.
// - Build tooling to audit or clean up legacy flash content in presentations.
// - Integrate flash object inspection into automated .NET workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    // Get the collection of controls (including flash objects) on the slide
                    IControlCollection controls = presentation.Slides[slideIndex].Controls;

                    // Iterate through each control
                    for (int ctrlIndex = 0; ctrlIndex < controls.Count; ctrlIndex++)
                    {
                        IControl ctrl = controls[ctrlIndex];
                        // Cast to Control to access ActiveXControlBinary (flash data)
                        Control flash = ctrl as Control;
                        if (flash != null)
                        {
                            byte[] binaryData = flash.ActiveXControlBinary;
                            if (binaryData != null && binaryData.Length > 0)
                            {
                                string name = flash.Name;
                                Console.WriteLine($"Flash Object: {name}, Size: {binaryData.Length} bytes");
                            }
                        }
                    }
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Comment: format not supported
            Console.WriteLine("The file format is not supported (PPTX).");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Comment: format not supported
            Console.WriteLine("The file format is not supported (PPT).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Set smartart layout to basicprocess and verify using C#
//
// Description:
// Demonstrates how to set a SmartArt diagram's layout to BasicProcess and verify the change using C#
// and Aspose.Slides for .NET. The example creates a new presentation, adds a SmartArt shape,
// modifies its layout, checks the result, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Layout, BasicProcess, 
// Verify, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate changing SmartArt layout to BasicProcess and verify the operation.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate SmartArt configurations before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram with BasicBlockList layout
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

            // Change the layout to BasicProcess
            smartArt.Layout = SmartArtLayoutType.BasicProcess;

            // Verify that the layout has been changed
            if (smartArt.Layout == SmartArtLayoutType.BasicProcess)
            {
                Console.WriteLine("SmartArt layout successfully changed to BasicProcess.");
            }
            else
            {
                Console.WriteLine("Failed to change SmartArt layout.");
            }

            // Save the presentation
            string outputPath = "SmartArtLayoutChanged.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format, file I/O issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

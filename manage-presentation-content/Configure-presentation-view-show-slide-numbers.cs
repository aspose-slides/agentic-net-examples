// -----------------------------------------------------------------------------
// Example: Configure presentation view show slide numbers using C#
//
// Description:
// Demonstrates how to enable slide number placeholders on all slides of a
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, makes slide numbers visible, and saves the result as a PPTX file.
// This pattern can be used to automate slide numbering in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Presentation, View, 
// Show, Slide Numbers, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically enable slide numbers in generated presentations.
// - Build C# utilities for PowerPoint slide numbering.
// - Integrate slide number configuration into .NET document workflows.
// - Prepare PPTX files with consistent slide numbering before distribution.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideNumberDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Make slide number placeholders visible on all slides
            presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

            // Define output file path
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "PresentationWithSlideNumbers.pptx");

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}

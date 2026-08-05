// -----------------------------------------------------------------------------
// Example: Set footer on layout hide children using C#
//
// Description:
// Demonstrates how to set the footer visibility on a layout slide and then hide
// the footer on its child slides using C# and Aspose.Slides for .NET. The example
// loads an existing presentation, modifies the footer settings on a layout and
// its dependent slides, and saves the result as a new PPTX file. This pattern
// can be used to control footer visibility across slide hierarchies in PowerPoint
// automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Footer, Layout, Hide, Children,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting footer visibility on a layout while hiding it on child slides.
// - Build C# tools for PowerPoint presentation processing that manage header/footer settings.
// - Generate or transform PPTX files with customized footer behavior in .NET applications.
// - Validate presentation workflows involving layout inheritance before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        var dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        var inputPath = Path.Combine(dataDir, "input.pptx");
        var outputPath = Path.Combine(dataDir, "output.pptx");

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get a layout slide (first one for demonstration)
                var layoutSlide = presentation.Masters[0].LayoutSlides[0];

                // Set footer visibility to true on the layout slide (affects its child placeholders)
                var layoutHeaderFooter = layoutSlide.HeaderFooterManager;
                layoutHeaderFooter.SetFooterAndChildFootersVisibility(true);

                // Hide footers on child slides that use this layout
                foreach (var slide in presentation.Slides)
                {
                    if (slide.LayoutSlide == layoutSlide)
                    {
                        var slideHeaderFooter = slide.HeaderFooterManager;
                        slideHeaderFooter.SetFooterVisibility(false);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

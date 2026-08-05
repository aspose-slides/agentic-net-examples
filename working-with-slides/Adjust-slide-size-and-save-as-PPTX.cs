// -----------------------------------------------------------------------------
// Example: Adjust slide size and save as PPTX using C#
//
// Description:
// Demonstrates how to adjust slide size (both custom dimensions and predefined
// A4 paper size) and save the presentation as PPTX using C# and Aspose.Slides
// for .NET. The example shows the required presentation-processing steps for
// PowerPoint files and produces the requested output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Slide, Size, Save,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adjusting slide size and saving as PPTX.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Set custom slide size with EnsureFit scaling
            presentation.SlideSize.SetSize(800f, 600f, SlideSizeScaleType.EnsureFit);
            // Set slide size to A4 paper with Maximize scaling
            presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);

            // Save the presentation as PPTX
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}

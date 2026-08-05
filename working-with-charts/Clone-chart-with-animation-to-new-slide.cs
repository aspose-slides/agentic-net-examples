// -----------------------------------------------------------------------------
// Example: Clone chart with animation to new slide using C#
//
// Description:
// Demonstrates how to clone a chart together with its animation sequence to a
// new slide using C# and Aspose.Slides for .NET. The example loads an existing
// presentation, copies the slide that contains the chart (including animations),
// and saves the result as a new PPTX file. This pattern can be used to automate
// PowerPoint workflows that require duplication of chart visuals and associated
// animations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Chart, Animation, Slide,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of chart with animation to a new slide.
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
    static void Main()
    {
        string inputPath = "source.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation sourcePres = new Presentation(inputPath))
            {
                // Get the slide that contains the chart (assumed to be the first slide)
                ISlide sourceSlide = sourcePres.Slides[0];

                // Clone the slide (including the chart and its animation sequence) to the end of the slide collection
                ISlide clonedSlide = sourcePres.Slides.InsertClone(sourcePres.Slides.Count, sourceSlide);

                // Save the modified presentation
                sourcePres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Clone chart with animation to another slide using C#
//
// Description:
// Demonstrates how to clone a chart together with its animation sequence from
// one slide to another slide in a PowerPoint presentation using C# and
// Aspose.Slides for .NET. The example loads an existing PPTX, clones the first
// slide (which contains the chart and its animations), optionally reorders the
// cloned slide, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Chart, Animation,
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of charts with animations to new slides.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and test presentation workflows involving animated charts.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string sourcePath = "source.pptx";
        string outputPath = "output.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            // Load the presentation from the source file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Get the first slide (assumed to contain the chart to be cloned)
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

                // Clone the entire slide, which includes the chart and its animation sequence
                Aspose.Slides.ISlide clonedSlide = presentation.Slides.AddClone(sourceSlide);

                // (Optional) You can reposition the cloned slide if needed, e.g., move it to the end
                // presentation.Slides.Reorder(presentation.Slides.Count - 1, clonedSlide);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Comment: format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL or web service errors)
        }
    }
}

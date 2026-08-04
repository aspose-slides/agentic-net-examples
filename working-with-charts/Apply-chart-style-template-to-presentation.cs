// -----------------------------------------------------------------------------
// Example: Apply chart style template to presentation using C#
//
// Description:
// Demonstrates how to apply a predefined chart style template to every chart
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, iterates through all slides and shapes, identifies
// chart objects, sets their Style property to a specific template, and saves the
// modified presentation. This pattern can be used to enforce consistent chart
// appearance across presentations in automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Chart, Style, Template,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a uniform chart style to existing presentations.
// - Build C# utilities for batch processing of PPTX files to ensure visual consistency.
// - Integrate chart styling into .NET applications that generate or modify PowerPoint content.
// - Validate and standardize chart appearances before publishing or distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    IChart chart = shape as IChart;

                    if (chart != null)
                    {
                        // Apply a predefined chart style template for consistency
                        chart.Style = StyleType.Style1;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access issues, corrupted file)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

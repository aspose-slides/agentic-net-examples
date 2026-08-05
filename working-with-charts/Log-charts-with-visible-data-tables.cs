// -----------------------------------------------------------------------------
// Example: Log charts with visible data tables using C#
//
// Description:
// Demonstrates how to log charts with visible data tables using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Charts, Visible, Data, Tables, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate log charts with visible data tables.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file (can be passed as a command‑line argument)
            string presentationPath = "input.pptx";
            if (args.Length > 0)
            {
                presentationPath = args[0];
            }

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    Aspose.Slides.ISlideCollection slides = presentation.Slides;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = slides[slideIndex];
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                        // Check each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = shapes[shapeIndex];
                            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                            // If the shape is a chart and its data table is visible, log the slide index
                            if (chart != null && chart.HasDataTable)
                            {
                                Console.WriteLine("Chart with visible data table found on slide index: " + slideIndex);
                                // No need to check remaining shapes on this slide
                                break;
                            }
                        }
                    }

                    // Save the presentation (required by the task)
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (System.Exception ex)
            {
                // Handle errors such as unsupported file formats
                // Comment: format not supported
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}

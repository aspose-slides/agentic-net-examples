// -----------------------------------------------------------------------------
// Example: Add connector each shape to title using C#
//
// Description:
// Demonstrates how to add connector each shape to title using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Each, Shape, Title, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add connector each shape to title.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AddConnectorBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist. Creating a new presentation.");
            }

            try
            {
                // Load existing presentation or create a new one
                Aspose.Slides.Presentation presentation;
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Find title placeholder shapes on the slide
                    Aspose.Slides.IShape[] titlePlaceholders = Aspose.Slides.Util.SlideUtil.FindShapesByPlaceholderType(
                        slide,
                        PlaceholderType.Title);

                    // If no title placeholder, skip this slide
                    if (titlePlaceholders == null || titlePlaceholders.Length == 0)
                    {
                        continue;
                    }

                    // Use the first title placeholder as the source shape
                    Aspose.Slides.IShape titleShape = titlePlaceholders[0];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Skip the title placeholder itself
                        if (shape == titleShape)
                        {
                            continue;
                        }

                        // Add a bent connector shape
                        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(
                            ShapeType.BentConnector2,
                            0f,
                            0f,
                            10f,
                            10f);

                        // Connect the title placeholder to the current shape
                        connector.StartShapeConnectedTo = titleShape;
                        connector.EndShapeConnectedTo = shape;

                        // Reroute to get the shortest path
                        connector.Reroute();
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The file format is not supported for PPTX.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The file format is not supported for PPT.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

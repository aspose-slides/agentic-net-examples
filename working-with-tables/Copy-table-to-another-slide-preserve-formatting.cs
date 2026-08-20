// -----------------------------------------------------------------------------
// Example: Copy table to another slide preserve formatting using C#
//
// Description:
// Demonstrates how to copy the first table from one slide to another slide while preserving its formatting using C# and Aspose.Slides for .NET. The example loads a presentation, finds the first table on the first slide, clones it onto a second slide (or creates one), and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Copy, Table, Another, Slide, Preserve Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate copying a table between slides while keeping its style.
// - Build C# utilities for PowerPoint slide manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate table layout consistency across slides.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Source slide (first slide)
                ISlide sourceSlide = pres.Slides[0];

                // Destination slide (second slide or create a new one)
                ISlide destSlide;
                if (pres.Slides.Count > 1)
                {
                    destSlide = pres.Slides[1];
                }
                else
                {
                    // Add an empty slide using the layout of the source slide
                    destSlide = pres.Slides.AddEmptySlide(sourceSlide.LayoutSlide);
                }

                // Locate the first table on the source slide
                ITable sourceTable = null;
                foreach (IShape shape in sourceSlide.Shapes)
                {
                    if (shape is ITable)
                    {
                        sourceTable = (ITable)shape;
                        break;
                    }
                }

                if (sourceTable != null)
                {
                    // Clone the table shape to the destination slide, preserving position
                    IShapeCollection destShapes = destSlide.Shapes;
                    destShapes.AddClone(sourceTable, sourceTable.X, sourceTable.Y);
                }
                else
                {
                    Console.WriteLine("No table found on the source slide.");
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

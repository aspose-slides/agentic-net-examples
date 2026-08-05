// -----------------------------------------------------------------------------
// Example: Batch update line widths 1 5pt preserve dash using C#
//
// Description:
// Demonstrates how to batch update line widths to 1.5 points while preserving
// dash styles using C# and Aspose.Slides for .NET. The example iterates through
// all shapes in a presentation, modifies the line width where defined, and
// saves the result as a new PPTX file. This pattern can be used to automate
// presentation styling tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Update, Line, Width, 
// Preserve Dash, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch updating of line widths to 1.5 pt while keeping dash styles.
// - Build C# utilities for PowerPoint presentation styling.
// - Generate or transform PPTX files in .NET applications.
// - Ensure consistent line formatting across slides before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        var lineFormat = shape.LineFormat;
                        if (lineFormat != null && !lineFormat.IsFormatNotDefined)
                        {
                            lineFormat.Width = 1.5; // set width to 1.5 points, dash style preserved
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

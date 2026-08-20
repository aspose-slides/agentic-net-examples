// -----------------------------------------------------------------------------
// Example: Set all table cells font size twelve using C#
//
// Description:
// Demonstrates how to set all table cells font size twelve using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Cells, Font, Size, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set all table cells font size twelve.
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
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.ITable table = slide.Shapes[shapeIndex] as Aspose.Slides.ITable;
                        if (table == null)
                        {
                            continue;
                        }

                        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                        portionFormat.FontHeight = 12f;
                        table.SetTextFormat(portionFormat);
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}

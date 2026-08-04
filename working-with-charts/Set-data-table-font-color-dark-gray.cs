// -----------------------------------------------------------------------------
// Example: Set data table font color dark gray using C#
//
// Description:
// Demonstrates how to set the font color of a data table to dark gray in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, accesses the first table on the first slide,
// applies a dark gray solid fill to the table's text, and saves the modified
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Data Table, Font Color, Dark Gray,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting data table font color to dark gray.
// - Build C# utilities for PowerPoint presentation styling.
// - Generate or modify PPTX files in .NET applications.
// - Validate presentation formatting before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // format not supported
            return;
        }

        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
        if (table == null)
        {
            Console.WriteLine("No table found on the first slide.");
            presentation.Dispose();
            return;
        }

        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
        portionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkGray;

        table.SetTextFormat(portionFormat);

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}

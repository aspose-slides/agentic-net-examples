// -----------------------------------------------------------------------------
// Example: Apply table style and verify properties using C#
//
// Description:
// Demonstrates how to create a table, apply a predefined table style, and
// verify effective formatting properties such as fill type using C# and
// Aspose.Slides for .NET. The example creates a presentation, adds a table,
// applies the MediumStyle2Accent1 style, checks the effective fill format,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Table, Style, Verify,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a table style and validating its properties.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or transform PPTX files with styled tables in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a new table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Apply a predefined table style
        table.StylePreset = Aspose.Slides.TableStylePreset.MediumStyle2Accent1;

        // Retrieve effective table formatting to verify style properties
        Aspose.Slides.ITableFormatEffectiveData tableEffective = table.TableFormat.GetEffective();

        // Example verification: check if the effective fill type is solid
        if (tableEffective.FillFormat != null && tableEffective.FillFormat.FillType == Aspose.Slides.FillType.Solid)
        {
            Console.WriteLine("Effective table fill type is solid as expected.");
        }
        else
        {
            Console.WriteLine("Effective table fill type is not solid.");
        }

        // Save the presentation
        string outputPath = "StyledTable.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

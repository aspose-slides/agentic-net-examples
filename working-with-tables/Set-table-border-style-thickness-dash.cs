// -----------------------------------------------------------------------------
// Example: Set table border style thickness dash using C#
//
// Description:
// Demonstrates how to create a table and apply a blue dashed border with a
// thickness of 3 points to all sides of each cell using Aspose.Slides for .NET.
// The example creates a new presentation, adds a 3x4 table, configures the
// border style, and saves the result as a PPTX file. This pattern can be used
// to automate table styling in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Border, Style, Thickness,
// Dash, Presentation Processing, Office Automation
//
// Use Cases:
// - Apply consistent dashed borders to tables in generated presentations.
// - Build C# utilities for styling PowerPoint tables programmatically.
// - Generate or transform PPTX files with custom table formatting.
// - Validate table border configurations before publishing.
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
        string outputPath = "CustomBorderTable.pptx";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            double[] cols = new double[] { 100, 100, 100 };
            double[] rows = new double[] { 50, 50, 50, 50 };
            ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

            foreach (IRow row in table.Rows)
            {
                foreach (ICell cell in row)
                {
                    // Top border
                    cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderTop.Width = 3;
                    cell.CellFormat.BorderTop.DashStyle = LineDashStyle.Dash;

                    // Bottom border
                    cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderBottom.Width = 3;
                    cell.CellFormat.BorderBottom.DashStyle = LineDashStyle.Dash;

                    // Left border
                    cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderLeft.Width = 3;
                    cell.CellFormat.BorderLeft.DashStyle = LineDashStyle.Dash;

                    // Right border
                    cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderRight.Width = 3;
                    cell.CellFormat.BorderRight.DashStyle = LineDashStyle.Dash;
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

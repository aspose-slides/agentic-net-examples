// -----------------------------------------------------------------------------
// Example: Adjust data table column width to longest using C#
//
// Description:
// Demonstrates how to adjust the column widths of a data table in a PowerPoint
// slide to fit the longest text in each column using Aspose.Slides for .NET.
// The example loads a presentation, locates the first table on the first slide,
// calculates the required width for each column based on cell text length, applies
// the new widths, and saves the modified presentation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Table, Column Width, Adjust, Data Table,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically resize table columns to accommodate content in generated PPTX files.
// - Build .NET tools that ensure tables are readable without manual adjustment.
// - Integrate table formatting into PowerPoint automation workflows.
// - Validate and standardize table layouts before publishing presentations.
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

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);
            ISlide slide = presentation.Slides[0];
            ITable table = null;

            // Find the first table on the slide
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is ITable)
                {
                    table = (ITable)shape;
                    break;
                }
            }

            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                presentation.Save(outputPath, SaveFormat.Pptx);
                return;
            }

            // Adjust column widths based on longest text in each column
            int columnCount = table.Columns.Count;
            double[] newWidths = new double[columnCount];
            double charWidth = 7.0; // Approximate width per character in points

            for (int col = 0; col < columnCount; col++)
            {
                int maxLength = 0;
                foreach (IRow row in table.Rows)
                {
                    ICell cell = row[col];
                    string text = cell.TextFrame != null ? cell.TextFrame.Text : string.Empty;
                    if (text != null && text.Length > maxLength)
                    {
                        maxLength = text.Length;
                    }
                }

                // Add some padding
                newWidths[col] = maxLength * charWidth + 10;
                table.Columns[col].Width = newWidths[col];
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs, I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

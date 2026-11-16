// -----------------------------------------------------------------------------
// Example: Replace Table Placeholder with CSV Data in PowerPoint
//
// Description:
// Demonstrates how to replace a table placeholder in a PowerPoint slide with
// data from a CSV file using C# and Aspose.Slides for .NET. The program creates
// a presentation, adds a layout slide containing a table placeholder, reads a
// CSV file, populates a table at the placeholder location, and saves the result.
// This enables automated PPTX workflows that require dynamic table generation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Table Placeholder, CSV, Data Import
//
// Use Cases:
// - Automate the replacement of table placeholders with CSV data in presentations.
// - Build tools for generating or updating tables in PowerPoint files.
// - Integrate CSV-driven content into PPTX slides within .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ReplaceTablePlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = "data.csv";
            string outputPath = "output.pptx";

            // Ensure CSV file exists; create sample if missing
            if (!File.Exists(csvPath))
            {
                try
                {
                    string[] sampleLines = new string[]
                    {
                        "Header1,Header2,Header3",
                        "Row1Col1,Row1Col2,Row1Col3",
                        "Row2Col1,Row2Col2,Row2Col3"
                    };
                    File.WriteAllLines(csvPath, sampleLines);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample CSV: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

                Aspose.Slides.ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;
                Aspose.Slides.IAutoShape placeholder = placeholderManager.AddTablePlaceholder(10, 10, 500, 300);

                Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layoutSlide);

                Aspose.Slides.IShape placeholderShape = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Table)
                    {
                        placeholderShape = shape;
                        break;
                    }
                }

                if (placeholderShape == null)
                {
                    Console.WriteLine("Table placeholder not found on the slide.");
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Environment.Exit(1);
                }

                string[] csvLines = File.ReadAllLines(csvPath);
                int rowCount = csvLines.Length;
                int columnCount = 0;
                if (rowCount > 0)
                {
                    columnCount = csvLines[0].Split(',').Length;
                }

                double[] columnWidths = new double[columnCount];
                double[] rowHeights = new double[rowCount];
                for (int i = 0; i < columnCount; i++)
                {
                    columnWidths[i] = 100;
                }
                for (int i = 0; i < rowCount; i++)
                {
                    rowHeights[i] = 20;
                }

                Aspose.Slides.ITable table = (Aspose.Slides.Table)slide.Shapes.AddTable(placeholderShape.X, placeholderShape.Y, columnWidths, rowHeights);

                for (int r = 0; r < rowCount; r++)
                {
                    string[] cells = csvLines[r].Split(',');
                    for (int c = 0; c < columnCount; c++)
                    {
                        if (c < cells.Length)
                        {
                            table[r, c].TextFrame.Text = cells[c];
                        }
                    }
                }

                slide.Shapes.Remove(placeholderShape);

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The specified file format is not supported.
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}

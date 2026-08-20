// -----------------------------------------------------------------------------
// Example: Detect empty cells and fill with placeholder using C#
//
// Description:
// Demonstrates how to detect empty table cells in a PowerPoint presentation
// and fill them with a placeholder text using Aspose.Slides for .NET. The
// example loads an existing PPTX file, iterates through all tables, checks each
// cell for empty text, replaces empty values with a predefined placeholder, and
// saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Empty Cells, Fill,
// Placeholder, Table Processing, Presentation Automation
//
// Use Cases:
// - Ensure all table cells contain meaningful data before publishing.
// - Automate cleanup of PowerPoint reports by inserting default values.
// - Build .NET tools that validate and enrich PPTX content.
// - Integrate placeholder insertion into larger presentation generation pipelines.
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
        const string placeholder = "N/A";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is ITable table)
                        {
                            for (int row = 0; row < table.Rows.Count; row++)
                            {
                                for (int col = 0; col < table.Columns.Count; col++)
                                {
                                    ICell cell = table[row, col];
                                    string text = cell.TextFrame.Text;
                                    if (string.IsNullOrEmpty(text))
                                    {
                                        cell.TextFrame.Text = placeholder;
                                    }
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("PPTX format not supported: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("PPT format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

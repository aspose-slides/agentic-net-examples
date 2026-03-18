using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableColumnInsertionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first table on the slide
                Aspose.Slides.ITable table = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    table = slide.Shapes[i] as Aspose.Slides.ITable;
                    if (table != null)
                    {
                        break;
                    }
                }

                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Store original table dimensions
                int originalRowCount = table.Rows.Count;
                int originalColumnCount = table.Columns.Count;

                // Retrieve existing column widths
                double[] originalColumnWidths = new double[originalColumnCount];
                for (int col = 0; col < originalColumnCount; col++)
                {
                    originalColumnWidths[col] = table.Columns[col].Width;
                }

                // Retrieve existing row heights
                double[] originalRowHeights = new double[originalRowCount];
                for (int row = 0; row < originalRowCount; row++)
                {
                    originalRowHeights[row] = table.Rows[row].Height;
                }

                // Define new column width (you can adjust the width as needed)
                double newColumnWidth = 50.0;

                // Create a new column widths array with an additional column
                double[] newColumnWidths = new double[originalColumnCount + 1];
                for (int col = 0; col < originalColumnCount; col++)
                {
                    newColumnWidths[col] = originalColumnWidths[col];
                }
                newColumnWidths[originalColumnCount] = newColumnWidth; // add new column at the end

                // Add a new table with the updated column count
                Aspose.Slides.ITable newTable = slide.Shapes.AddTable(table.X, table.Y, newColumnWidths, originalRowHeights);

                // Copy existing cell texts and basic formatting to the new table
                for (int row = 0; row < originalRowCount; row++)
                {
                    for (int col = 0; col < originalColumnCount; col++)
                    {
                        // Copy text
                        newTable.Rows[row][col].TextFrame.Text = table.Rows[row][col].TextFrame.Text;

                        // Copy simple formatting (font size and color as an example)
                        newTable.Rows[row][col].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 
                            table.Rows[row][col].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight;
                        newTable.Rows[row][col].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = 
                            table.Rows[row][col].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color;
                    }

                    // Initialize cells of the newly added column (optional: set default text)
                    newTable.Rows[row][originalColumnCount].TextFrame.Text = "New Column";
                }

                // Remove the old table
                slide.Shapes.Remove(table);

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
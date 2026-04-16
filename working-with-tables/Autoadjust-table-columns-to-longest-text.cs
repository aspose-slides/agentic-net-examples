using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableAutoAdjust
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "AutoAdjustedTable.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Define initial column widths and row heights
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50, 50 };

                // Add a table to the slide
                ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate the table with sample text of varying lengths
                string[,] sampleTexts = new string[,]
                {
                    { "Short", "Medium length", "A considerably longer piece of text" },
                    { "Tiny", "Some text", "Another long text example" },
                    { "Brief", "Longer text here", "Short" },
                    { "Lorem ipsum dolor sit amet", "Consectetur", "Adipiscing elit" }
                };

                for (int row = 0; row < sampleTexts.GetLength(0); row++)
                {
                    for (int col = 0; col < sampleTexts.GetLength(1); col++)
                    {
                        table[row, col].TextFrame.Text = sampleTexts[row, col];
                    }
                }

                // Adjust column widths based on the longest text in each column
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    double maxWidth = 0;
                    foreach (IRow row in table.Rows)
                    {
                        ICell cell = row[col];
                        string text = cell.TextFrame.Text ?? string.Empty;
                        // Approximate width: character count * 7 (points per character)
                        double estimatedWidth = text.Length * 7;
                        if (estimatedWidth > maxWidth)
                        {
                            maxWidth = estimatedWidth;
                        }
                    }
                    // Add a small padding
                    table.Columns[col].Width = maxWidth + 10;
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling for external services or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
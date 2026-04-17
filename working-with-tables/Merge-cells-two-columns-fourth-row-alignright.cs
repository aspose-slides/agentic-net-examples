using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableMergeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Define column widths and row heights (at least 3 columns and 4 rows)
                    double[] columnWidths = new double[] { 100, 100, 100 };
                    double[] rowHeights = new double[] { 50, 50, 50, 50 };

                    // Add a table to the slide
                    ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

                    // Merge the first two columns (0 and 1) in the fourth row (row index 3)
                    ICell cell1 = table[0, 3]; // column 0, row 3
                    ICell cell2 = table[1, 3]; // column 1, row 3
                    ICell mergedCell = table.MergeCells(cell1, cell2, false);

                    // Set text for the merged cell
                    mergedCell.TextFrame.Text = "Merged Right Aligned";

                    // Align the text to the right
                    mergedCell.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;

                    // Save the presentation
                    pres.Save("MergedTable.pptx", SaveFormat.Pptx);
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing input file scenario (not used in this example)
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format scenario
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DuplicateTableRowExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Define column widths and row heights
                    double[] columnWidths = new double[] { 100, 100, 100 };
                    double[] rowHeights = new double[] { 50, 50 };

                    // Add a table to the slide
                    ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                    // Populate the first row with sample text
                    table.Rows[0][0].TextFrame.Text = "Cell 1";
                    table.Rows[0][1].TextFrame.Text = "Cell 2";
                    table.Rows[0][2].TextFrame.Text = "Cell 3";

                    // Duplicate the first row while preserving formatting and contents
                    IRowCollection rows = table.Rows;
                    IRow templateRow = rows[0];
                    rows.AddClone(templateRow, true);

                    // Save the presentation
                    presentation.Save("DuplicatedRow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
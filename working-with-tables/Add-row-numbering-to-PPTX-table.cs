using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableNumberingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Define column widths (first column for numbers, second for other data)
                double[] columnWidths = new double[] { 50, 150 };

                // Define row heights (5 rows as an example)
                double[] rowHeights = new double[] { 30, 30, 30, 30, 30 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

                // Add sequential numbers to the first column of each row
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    // Set the text of the first cell in the row
                    table.Rows[i][0].TextFrame.Text = (i + 1).ToString();
                }

                // Save the presentation
                pres.Save("NumberedTable.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
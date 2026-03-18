using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableDuplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate the table with sample text
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                    {
                        table[rowIndex, colIndex].TextFrame.Text = $"R{rowIndex + 1}C{colIndex + 1}";
                    }
                }

                // Duplicate the second row (index 1) and append it to the table
                Aspose.Slides.IRow templateRow = table.Rows[1];
                table.Rows.AddClone(templateRow, false);

                // Duplicate the third column (index 2) and append it to the table
                Aspose.Slides.IColumn templateColumn = table.Columns[2];
                table.Columns.AddClone(templateColumn, false);

                // Save the presentation
                presentation.Save("DuplicatedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
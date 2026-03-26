using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights (in points)
            double[] columnWidths = new double[] { 100, 150, 100 };
            double[] rowHeights = new double[] { 40, 30, 30, 30 };

            // Add a table shape to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Sample data to populate the table
            string[,] data = new string[,]
            {
                { "Header1", "Header2", "Header3" },
                { "Row1Col1", "Row1Col2", "Row1Col3" },
                { "Row2Col1", "Row2Col2", "Row2Col3" },
                { "Row3Col1", "Row3Col2", "Row3Col3" }
            };

            // Fill the table cells with data and apply simple formatting
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Aspose.Slides.ICell cell = table[col, row];
                    cell.TextFrame.Text = data[row, col];

                    // Make header row bold
                    if (row == 0)
                    {
                        cell.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                    }
                }
            }

            // Save the presentation to disk
            pres.Save("RenderedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 40, 30, 30, 30 };

                // Add a table to the slide
                ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Apply border and fill formatting to each cell
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Rows[row].Count; col++)
                    {
                        // Top border
                        table.Rows[row][col].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                        table.Rows[row][col].CellFormat.BorderTop.Width = 2;

                        // Bottom border
                        table.Rows[row][col].CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Blue;
                        table.Rows[row][col].CellFormat.BorderBottom.Width = 2;

                        // Left border
                        table.Rows[row][col].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Blue;
                        table.Rows[row][col].CellFormat.BorderLeft.Width = 2;

                        // Right border
                        table.Rows[row][col].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Blue;
                        table.Rows[row][col].CellFormat.BorderRight.Width = 2;

                        // Cell fill
                        table.Rows[row][col].CellFormat.FillFormat.FillType = FillType.Solid;
                        table.Rows[row][col].CellFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
                    }
                }

                // Merge first two cells in the first row and add text
                table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
                table.Rows[0][0].TextFrame.Text = "Merged Header";

                // Set text formatting for all cells
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Rows[row].Count; col++)
                    {
                        IPortion portion = table.Rows[row][col].TextFrame.Paragraphs[0].Portions[0];
                        portion.PortionFormat.FontHeight = 12;
                        portion.PortionFormat.FontBold = NullableBool.True;
                        portion.PortionFormat.FontItalic = NullableBool.False;
                        portion.PortionFormat.FontUnderline = TextUnderlineType.Single;
                        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
                        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
                    }
                }

                // Save the presentation
                pres.Save("StyledTable.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50 };
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Apply border and fill formatting to each cell
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Rows[row].Count; col++)
                    {
                        Aspose.Slides.ICell cell = table.Rows[row][col];

                        // Top border
                        cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderTop.Width = 2;

                        // Bottom border
                        cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderBottom.Width = 2;

                        // Left border
                        cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderLeft.Width = 2;

                        // Right border
                        cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderRight.Width = 2;

                        // Cell background fill
                        cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.FillFormat.SolidFillColor.Color = Color.LightYellow;
                    }
                }

                // Define text formatting for all cells
                Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                portionFormat.FontHeight = 14;
                portionFormat.FontBold = Aspose.Slides.NullableBool.True;
                portionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
                portionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                portionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;

                table.SetTextFormat(portionFormat);

                // Add sample text to a cell
                Aspose.Slides.ICell firstCell = table[0, 0];
                firstCell.TextFrame.Text = "Hello";

                // Save the presentation
                presentation.Save("FormattedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] cols = new double[] { 100, 100, 100 };
        double[] rows = new double[] { 50, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

        // Apply solid red borders to each cell
        foreach (Aspose.Slides.IRow row in table.Rows)
        {
            foreach (Aspose.Slides.ICell cell in row)
            {
                cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                cell.CellFormat.BorderTop.Width = 5;

                cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                cell.CellFormat.BorderBottom.Width = 5;

                cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                cell.CellFormat.BorderLeft.Width = 5;

                cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                cell.CellFormat.BorderRight.Width = 5;
            }
        }

        // Merge the first two cells of the first row
        table.MergeCells(table[0, 0], table[0, 1], false);
        table[0, 0].TextFrame.Text = "Header";

        // Apply text formatting to the first row
        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
        portionFormat.FontHeight = 14;
        table.Rows[0].SetTextFormat(portionFormat);

        Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
        paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
        paragraphFormat.MarginRight = 5;
        table.Rows[0].SetTextFormat(paragraphFormat);

        // Save the presentation
        string outputPath = "StyledTable.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
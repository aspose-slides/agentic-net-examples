using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] cols = new double[] { 150, 150, 150, 150 };
        double[] rows = new double[] { 100, 100, 100, 100, 90 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

        // Modify each cell's borders (solid red, width 2)
        foreach (Aspose.Slides.IRow row in table.Rows)
        {
            foreach (Aspose.Slides.ICell cell in row)
            {
                cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderTop.Width = 2;

                cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderBottom.Width = 2;

                cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderLeft.Width = 2;

                cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderRight.Width = 2;
            }
        }

        // Set text in the first cell
        table[0, 0].TextFrame.Text = "Modified Cell";

        // Save the presentation
        presentation.Save("ModifiedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
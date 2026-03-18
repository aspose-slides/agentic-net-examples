using System;
using System.IO;
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 150, 150, 150, 150 };
            double[] rowHeights = new double[] { 100, 100, 100, 100, 90 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Set borders for each cell
            foreach (Aspose.Slides.IRow row in table.Rows)
            {
                foreach (Aspose.Slides.ICell cell in row)
                {
                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderTop.Width = 5;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderBottom.Width = 5;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderLeft.Width = 5;

                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderRight.Width = 5;
                }
            }

            // Merge cells (first two rows and columns) and add text
            table.MergeCells(table[0, 0], table[1, 1], false);
            table[0, 0].TextFrame.Text = "Merged Cell";

            // Add an image inside the merged cell
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile("image.jpg");
            Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(image);
            table[0, 0].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = pptImage;

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            double[] columnWidths = new double[] { 150, 150, 150, 150 };
            double[] rowHeights = new double[] { 100, 100, 100, 100, 90 };
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile("input.jpg");
            Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(image);

            // Apply picture fill to the first cell
            table[0, 0].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = pptImage;

            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
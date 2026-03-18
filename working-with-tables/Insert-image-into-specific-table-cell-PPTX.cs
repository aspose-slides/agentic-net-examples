using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageIntoTableCell
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

                // Define column widths and row heights for the table
                double[] columnWidths = new double[] { 150, 150, 150, 150 };
                double[] rowHeights = new double[] { 100, 100, 100, 100, 90 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Load an image from file and add it to the presentation's image collection
                Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile("input.jpg");
                Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(image);

                // Insert the image into the cell at column 0, row 0
                table[0, 0].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = pptImage;

                // Optional: set cropping values (0 means no cropping)
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.CropRight = 0;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.CropLeft = 0;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.CropTop = 0;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.CropBottom = 0;

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
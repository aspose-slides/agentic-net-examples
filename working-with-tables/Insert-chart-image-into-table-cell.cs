using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
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

                // Add a chart to the slide (it will be used only to obtain an image)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 400f, 300f);

                // Get the chart as an image
                Aspose.Slides.IImage chartImage = chart.GetImage();

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(chartImage);

                // Define column widths and row heights for the table
                double[] columnWidths = new double[] { 150, 150, 150 };
                double[] rowHeights = new double[] { 100, 100, 100, 100, 90 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Embed the chart image into the first cell of the table
                table[0, 0].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = pptImage;

                // Save the presentation
                presentation.Save("ChartInTableCell.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
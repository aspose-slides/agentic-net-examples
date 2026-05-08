using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string chartImagePath = "chart.png";
            string presentationPath = "chartPresentation.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Scale factor to achieve approximately 300 DPI (default is 96 DPI)
            float scale = 300f / 96f;

            Aspose.Slides.IImage chartImage = chart.GetImage(
                Aspose.Slides.ShapeThumbnailBounds.Shape,
                scale,
                scale);

            chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
        }
    }
}
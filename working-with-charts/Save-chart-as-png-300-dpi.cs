using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesChartImage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Get the chart image (default resolution)
                // To achieve higher visual quality, a scaling factor can be applied if needed.
                Aspose.Slides.IImage chartImage = chart.GetImage();

                // Save the chart image as PNG (300 DPI approximation)
                string chartImagePath = "ChartImage.png";
                chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation
                string presentationPath = "PresentationOutput.pptx";
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
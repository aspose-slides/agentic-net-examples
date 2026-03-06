using System;

namespace ChartImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            string chartImagePath = "chart.png";
            string presentationPath = "output.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Get the chart image
            Aspose.Slides.IImage chartImage = chart.GetImage();

            // Save the chart image as PNG
            chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
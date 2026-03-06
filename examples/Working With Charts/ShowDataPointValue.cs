using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ShowDataPointValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Get the data points collection of the first series
            Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

            // Show the value for the first data point's label
            dataPoints[0].Label.DataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save("ShowDataPointValue_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
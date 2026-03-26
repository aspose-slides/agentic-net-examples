using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a stacked column chart
            IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 50f, 50f, 500f, 400f);

            // Enable displaying values and percentages on data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Save the presentation
            presentation.Save("OutputChart.pptx", SaveFormat.Pptx);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the title slide (first slide)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Set chart title (optional)
            chart.ChartTitle.AddTextFrameForOverriding("Sample Pie Chart");
            chart.HasTitle = true;

            // Show percentage labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Set number format to display percentages
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0%";

            // Save the presentation
            presentation.Save("PieChartWithPercentage.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
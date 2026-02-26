using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (created by default)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 500, 400);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Enable data labels and configure their formatting
        series.Labels.DefaultDataLabelFormat.ShowValue = true;
        series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
        series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
        series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
        series.Labels.DefaultDataLabelFormat.Separator = "; ";

        // Save the presentation
        presentation.Save("ChartDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
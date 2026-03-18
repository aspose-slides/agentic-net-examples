using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a blank slide
            Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400).Chart;

            // Configure the first series data labels to show percentages with a trailing percent sign
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
            series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
            series.Labels.DefaultDataLabelFormat.NumberFormat = "0%";

            // Optionally show the value as well (can be omitted if only percentage is needed)
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save("ChartDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Data");

            // Configure data labels for the first series
            var series0 = chart.ChartData.Series[0];
            series0.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            series0.Labels.DefaultDataLabelFormat.ShowValue = true;
            series0.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
            series0.Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

            // Configure data labels for the second series
            var series1 = chart.ChartData.Series[1];
            series1.Labels.DefaultDataLabelFormat.ShowSeriesName = true;
            series1.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Save the presentation
            presentation.Save("ChartDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
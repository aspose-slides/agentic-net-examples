using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a stacked column chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn, 50, 50, 500, 400);

        // Configure data labels to show percentages with a trailing percent sign
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0%";

        // Save the presentation
        presentation.Save("ChartWithPercentageLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
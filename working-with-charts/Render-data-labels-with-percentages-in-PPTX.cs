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

        // Add a stacked column chart to the slide
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn, 50f, 50f, 500f, 400f);

        // Enable display of numeric values on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Enable display of percentages on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Save the presentation to a PPTX file
        presentation.Save("ChartWithLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}
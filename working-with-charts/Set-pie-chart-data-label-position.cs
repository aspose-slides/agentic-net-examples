using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();
        // Access the first slide
        ISlide slide = pres.Slides[0];
        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 400f);
        // Set the default data label position for the series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
        // Optionally show the value in data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        // Save the presentation
        pres.Save("PieChartDataLabelPosition.pptx", SaveFormat.Pptx);
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Ensure the chart displays a legend
        chart.HasLegend = true;

        // Customize legend position and size using fractional values relative to the chart
        chart.Legend.X = 0.8f;      // 80% from the left edge of the chart
        chart.Legend.Y = 0.1f;      // 10% from the top edge of the chart
        chart.Legend.Width = 0.15f; // 15% of the chart width
        chart.Legend.Height = 0.3f; // 30% of the chart height

        // Optionally set the legend position type (overrides X/Y if set)
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

        // Save the presentation to a PPTX file
        presentation.Save("CustomLegendChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
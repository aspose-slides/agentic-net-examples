using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Reposition and resize the plot area within the chart
            chart.PlotArea.AsILayoutable.X = 0.1f;      // 10% from left
            chart.PlotArea.AsILayoutable.Y = 0.1f;      // 10% from top
            chart.PlotArea.AsILayoutable.Width = 0.8f;  // 80% of chart width
            chart.PlotArea.AsILayoutable.Height = 0.8f; // 80% of chart height

            // Define layout target type for the plot area
            chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

            // Save the presentation
            pres.Save("ModifiedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
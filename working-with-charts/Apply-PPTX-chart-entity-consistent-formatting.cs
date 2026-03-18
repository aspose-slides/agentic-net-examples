using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide's shape collection
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add a sample chart (Clustered Column) to the slide
            Aspose.Slides.Charts.IChart chart = shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Apply a consistent chart style
            chart.Style = Aspose.Slides.Charts.StyleType.Style5;

            // Ensure each series uses varied colors for visual consistency
            int seriesCount = chart.ChartData.Series.Count;
            for (int i = 0; i < seriesCount; i++)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[i];
                Aspose.Slides.Charts.IChartSeriesGroup group = series.ParentSeriesGroup;
                group.IsColorVaried = true;
            }

            // Save the presentation to disk
            pres.Save("ConsistentChartFormatting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
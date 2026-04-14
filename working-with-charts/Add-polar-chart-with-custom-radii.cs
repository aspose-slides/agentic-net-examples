using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Array of different chart types for comparison
        Aspose.Slides.Charts.ChartType[] chartTypes = new Aspose.Slides.Charts.ChartType[]
        {
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            Aspose.Slides.Charts.ChartType.StackedColumn,
            Aspose.Slides.Charts.ChartType.Pie,
            Aspose.Slides.Charts.ChartType.PieOfPie,
            Aspose.Slides.Charts.ChartType.Line,
            Aspose.Slides.Charts.ChartType.Area,
            Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
            Aspose.Slides.Charts.ChartType.Doughnut,
            Aspose.Slides.Charts.ChartType.Radar,
            Aspose.Slides.Charts.ChartType.Bubble
        };

        // Add a slide for each chart type and insert the chart
        for (int i = 0; i < chartTypes.Length; i++)
        {
            // Add a new empty slide using the layout of the first slide
            Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(chartTypes[i], 50, 50, 500, 400);

            // Set chart title to identify the chart type
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding(chartTypes[i].ToString() + " Chart");
        }

        // Save the presentation
        try
        {
            presentation.Save("ChartComparison.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception)
        {
            // Format not supported
        }

        // Ensure resources are released
        presentation.Dispose();
    }
}
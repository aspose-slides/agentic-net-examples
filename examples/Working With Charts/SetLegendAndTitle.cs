using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);
        chart.ValidateChartLayout();

        // Get references to the chart title and legend objects
        Aspose.Slides.Charts.ChartTitle chartTitle = (Aspose.Slides.Charts.ChartTitle)chart.ChartTitle;
        Aspose.Slides.Charts.Legend legend = (Aspose.Slides.Charts.Legend)chart.Legend;

        // Enable and set the chart title
        chart.HasTitle = true;
        chartTitle.AddTextFrameForOverriding("Sample Title");
        chartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Enable and position the legend
        chart.HasLegend = true;
        legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

        // Save the presentation
        pres.Save("SetLegendAndTitle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
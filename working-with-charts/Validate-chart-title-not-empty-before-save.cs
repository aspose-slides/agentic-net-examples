using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
        chart.ValidateChartLayout();

        // Set chart title (using the chart-title rule)
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20;
        chart.ChartTitle.Width = 400;
        chart.ChartTitle.Y = 0;
        chart.ChartTitle.X = 0;

        // Validate that the chart title is a non‑empty string before saving
        if (chart.HasTitle &&
            chart.ChartTitle.TextFrameForOverriding != null &&
            !string.IsNullOrEmpty(chart.ChartTitle.TextFrameForOverriding.Text))
        {
            // Save the presentation
            pres.Save("ChartTitleValidated.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        else
        {
            // Title is empty – handle accordingly
            Console.WriteLine("Chart title is empty. Presentation not saved.");
        }
    }
}
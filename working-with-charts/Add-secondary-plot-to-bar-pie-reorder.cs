using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a Bar of Pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.BarOfPie, 50f, 50f, 500f, 400f);

        // Configure secondary plot options
        chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 150; // size of secondary bar (percentage)
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0; // split at 30%

        // Adjust the order of data series (example: reverse order of first two series)
        if (chart.ChartData.Series.Count > 0)
        {
            chart.ChartData.Series[0].Order = 2;
        }
        if (chart.ChartData.Series.Count > 1)
        {
            chart.ChartData.Series[1].Order = 1;
        }

        // Save the presentation
        try
        {
            presentation.Save("BarOfPieSecondaryPlot.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
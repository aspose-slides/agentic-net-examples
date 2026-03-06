using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = pres.Slides[0];

        // Add a Pie of Pie chart
        var pieChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.PieOfPie, 50, 50, 400, 400);
        // Configure second plot options via the series group
        var pieSeriesGroup = pieChart.ChartData.Series[0].ParentSeriesGroup;
        pieSeriesGroup.SecondPieSize = 150; // Size of second pie as 150% of first pie
        pieSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByValue; // Split by value

        // Add a Bar of Pie chart
        var barChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.BarOfPie, 50, 500, 400, 400);
        // Configure second plot options via the series group
        var barSeriesGroup = barChart.ChartData.Series[0].ParentSeriesGroup;
        barSeriesGroup.SecondPieSize = 120; // Size of second bar as 120% of first pie
        barSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage; // Split by percentage

        // Save the presentation
        pres.Save("SecondPlotOptions.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
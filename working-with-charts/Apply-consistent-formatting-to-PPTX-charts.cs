using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a PieOfPie chart
        IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50f, 50f, 500f, 400f);

        // Show values for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Set the size of the second pie (percentage of the first pie)
        chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = (ushort)150;

        // Split the pie by percentage
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;

        // Define the split position (percentage)
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0;

        // Customize legend position and size
        chart.Legend.X = 10f;
        chart.Legend.Y = 10f;
        chart.Legend.Width = 200f;
        chart.Legend.Height = 100f;

        // Save the presentation
        string outputPath = "FormattedChartPresentation.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
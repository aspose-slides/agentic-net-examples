using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an Area chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 500f, 400f);

        // Calculate actual layout values for the chart
        chart.ValidateChartLayout();

        // Retrieve actual axis values
        double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
        double minValue = chart.Axes.VerticalAxis.ActualMinValue;
        double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
        double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;

        // Retrieve actual plot area dimensions (cast required)
        Aspose.Slides.Charts.ChartPlotArea plotArea = (Aspose.Slides.Charts.ChartPlotArea)chart.PlotArea;
        float actualX = plotArea.ActualX;
        float actualY = plotArea.ActualY;
        float actualWidth = plotArea.ActualWidth;
        float actualHeight = plotArea.ActualHeight;

        // Example usage: output values to console
        Console.WriteLine("Axis Max Value: " + maxValue);
        Console.WriteLine("Axis Min Value: " + minValue);
        Console.WriteLine("Axis Major Unit: " + majorUnit);
        Console.WriteLine("Axis Minor Unit: " + minorUnit);
        Console.WriteLine("Plot Area X: " + actualX);
        Console.WriteLine("Plot Area Y: " + actualY);
        Console.WriteLine("Plot Area Width: " + actualWidth);
        Console.WriteLine("Plot Area Height: " + actualHeight);

        // Save the presentation
        string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ActualValuesChart.pptx");
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}
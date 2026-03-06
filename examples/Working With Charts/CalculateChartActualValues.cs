using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outPath = "CalculateChartActualValues_out.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an Area chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50, 50, 500, 400);

        // Calculate actual layout values for the chart
        chart.ValidateChartLayout();

        // Retrieve actual axis values
        double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
        double minValue = chart.Axes.VerticalAxis.ActualMinValue;
        double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
        double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;

        // Display the calculated values
        Console.WriteLine("Actual Max Value: " + maxValue);
        Console.WriteLine("Actual Min Value: " + minValue);
        Console.WriteLine("Actual Major Unit: " + majorUnit);
        Console.WriteLine("Actual Minor Unit: " + minorUnit);

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}
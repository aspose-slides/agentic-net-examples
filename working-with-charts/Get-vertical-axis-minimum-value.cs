using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Output file path
        string outPath = "AxisMinValue_out.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add an Area chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 500, 400);

        // Validate chart layout to ensure axis values are calculated
        chart.ValidateChartLayout();

        // Retrieve the minimum value of the vertical axis using MinValue property
        double minValue = chart.Axes.VerticalAxis.MinValue;

        // Output the retrieved value
        Console.WriteLine("Vertical Axis MinValue: " + minValue);

        // Save the presentation
        pres.Save(outPath, SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}
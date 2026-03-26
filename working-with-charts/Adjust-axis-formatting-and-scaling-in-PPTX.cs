using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outPath = "ChartAxesDemo.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an Area chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 500f, 400f);

        // Validate layout to obtain actual axis values
        chart.ValidateChartLayout();

        // Retrieve actual axis scaling values
        double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
        double minValue = chart.Axes.VerticalAxis.ActualMinValue;
        double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
        double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;

        // Set category axis label distance (offset)
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)20;

        // Show display unit label in millions on the vertical axis
        chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

        // Position the horizontal axis between categories
        chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
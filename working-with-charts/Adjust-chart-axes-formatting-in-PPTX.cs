using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an Area chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 500f, 400f);
        chart.ValidateChartLayout();

        // Retrieve actual axis values (read‑only properties)
        double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
        double minValue = chart.Axes.VerticalAxis.ActualMinValue;
        double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
        double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;

        // Set category axis label distance
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)20; // distance in percent

        // Show display unit label (e.g., millions) on the vertical axis
        chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

        // Customize vertical axis scaling
        chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
        chart.Axes.VerticalAxis.MinValue = minValue - 10; // extend minimum
        chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
        chart.Axes.VerticalAxis.MaxValue = maxValue + 10; // extend maximum

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
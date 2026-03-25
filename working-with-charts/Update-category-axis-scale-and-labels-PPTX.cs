using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart (or use existing chart)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Adjust category axis label distance (using set-category-axis-label-distance rule)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)100; // 10% offset

            // Set vertical axis scale
            chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
            chart.Axes.VerticalAxis.MinValue = 0;
            chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
            chart.Axes.VerticalAxis.MaxValue = 100;
            chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
            chart.Axes.VerticalAxis.MajorUnit = 10;

            // Format horizontal axis number labels
            chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
            chart.Axes.HorizontalAxis.NumberFormat = "0%";

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
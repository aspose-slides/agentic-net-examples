using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Change the chart data range
                chart.ChartData.SetRange("Sheet1!$A$1:$B$5");

                // Set the horizontal axis to be between categories
                chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

                // Customize the first data point of the first series (set solid fill color)
                Aspose.Slides.Charts.IChartDataPointCollection firstSeriesPoints = chart.ChartData.Series[0].DataPoints;
                Aspose.Slides.Charts.IChartDataPoint firstDataPoint = firstSeriesPoints[0];
                firstDataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                firstDataPoint.Format.Fill.SolidFillColor.Color = Color.Yellow;

                // Customize data labels for the second series
                Aspose.Slides.Charts.IChartSeries secondSeries = chart.ChartData.Series[1];
                secondSeries.Labels.DefaultDataLabelFormat.ShowValue = true;
                secondSeries.Labels[0].DataLabelFormat.ShowCategoryName = true;
                secondSeries.Labels[0].DataLabelFormat.Separator = " - ";

                // Retrieve axis values and unit scales (for demonstration)
                double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
                double minValue = chart.Axes.VerticalAxis.ActualMinValue;
                double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
                double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
                Console.WriteLine($"Vertical Axis: Min={minValue}, Max={maxValue}");
                Console.WriteLine($"Horizontal Axis: MajorUnit={majorUnit}, MinorUnit={minorUnit}");
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}
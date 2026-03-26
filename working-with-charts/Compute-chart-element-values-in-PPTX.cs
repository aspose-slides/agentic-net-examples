using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation from the specified file
        Presentation presentation = new Presentation(inputPath);

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IChart chart = slide.Shapes[shapeIndex] as IChart;
                if (chart != null)
                {
                    // Calculate actual layout values for the chart
                    chart.ValidateChartLayout();

                    // Calculate any formulas present in the chart's data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    workbook.CalculateFormulas();

                    // Retrieve axis values
                    double verticalMax = chart.Axes.VerticalAxis.ActualMaxValue;
                    double verticalMin = chart.Axes.VerticalAxis.ActualMinValue;
                    double horizontalMajor = chart.Axes.HorizontalAxis.ActualMajorUnit;
                    double horizontalMinor = chart.Axes.HorizontalAxis.ActualMinorUnit;

                    Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}:");
                    Console.WriteLine($"  Vertical Axis - Max: {verticalMax}, Min: {verticalMin}");
                    Console.WriteLine($"  Horizontal Axis - Major Unit: {horizontalMajor}, Minor Unit: {horizontalMinor}");

                    // Iterate through series and data points to obtain computed values
                    for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                    {
                        IChartSeries series = chart.ChartData.Series[seriesIndex];
                        for (int pointIndex = 0; pointIndex < series.DataPoints.Count; pointIndex++)
                        {
                            IChartDataPoint dataPoint = series.DataPoints[pointIndex];
                            object pointValue = dataPoint.Value;
                            Console.WriteLine($"    Series {seriesIndex + 1}, Point {pointIndex + 1}: Value = {pointValue}");
                        }
                    }
                }
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}
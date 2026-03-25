using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        try
        {
            using var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                var slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    if (slide.Shapes[shapeIndex] is Aspose.Slides.Charts.IChart chart)
                    {
                        // Calculate actual layout values
                        chart.ValidateChartLayout();

                        // Access the embedded workbook and calculate formulas
                        var workbook = chart.ChartData.ChartDataWorkbook;
                        workbook.CalculateFormulas();

                        // Output series and data point values
                        for (var seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                        {
                            var series = chart.ChartData.Series[seriesIndex];
                            Console.WriteLine($"Slide {slideIndex}, Chart {shapeIndex}, Series {seriesIndex}");

                            for (var pointIndex = 0; pointIndex < series.DataPoints.Count; pointIndex++)
                            {
                                var dataPoint = series.DataPoints[pointIndex];
                                var value = dataPoint.Value;
                                Console.WriteLine($"  DataPoint {pointIndex} Value: {value}");
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing presentation: {ex.Message}");
        }
    }
}
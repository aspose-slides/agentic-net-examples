using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "BubbleChartScaled.pptx";
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];
                // Add a bubble chart
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);
                // Access the embedded workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Sample data
                double[] xValues = new double[] { 1, 2, 3, 4 };
                double[] yValues = new double[] { 10, 20, 30, 40 };
                double[] bubbleSizes = new double[] { 5, 15, 25, 35 };

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                // Use literal doubles for bubble sizes
                series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

                // Populate data points
                for (int i = 0; i < xValues.Length; i++)
                {
                    IChartDataPoint point = series.DataPoints.AddDataPointForBubbleSeries(xValues[i], yValues[i], bubbleSizes[i]);
                    point.BubbleSize.AsLiteralDouble = bubbleSizes[i];
                }

                // Determine maximum bubble size
                double maxSize = 0;
                foreach (IChartDataPoint point in series.DataPoints)
                {
                    if (point.BubbleSize.AsLiteralDouble > maxSize)
                    {
                        maxSize = point.BubbleSize.AsLiteralDouble;
                    }
                }

                // Scale all bubble sizes proportionally so that the largest becomes 100
                double desiredMax = 100.0;
                double scaleFactor = desiredMax / maxSize;

                foreach (IChartDataPoint point in series.DataPoints)
                {
                    double original = point.BubbleSize.AsLiteralDouble;
                    point.BubbleSize.AsLiteralDouble = original * scaleFactor;
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
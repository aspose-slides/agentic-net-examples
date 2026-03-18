using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ModifyChartElements
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the first shape as a chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

                if (chart != null)
                {
                    // Enable varied colors for each series (replaces FillType usage)
                    Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                    series1.ParentSeriesGroup.IsColorVaried = true;

                    Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
                    series2.ParentSeriesGroup.IsColorVaried = true;

                    // Modify axes
                    chart.Axes.HorizontalAxis.AxisBetweenCategories = true;
                    chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

                    // Switch rows and columns in the chart data
                    chart.ChartData.SwitchRowColumn();

                    // Access the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Change the value of the first data point in the first series
                    series1.DataPoints[0].Value.Data = 42;

                    // Add a new data point to the second series
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 3, 70));
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ModifyDoughnutChart
{
    class Program
    {
        static void Main(string[] args)
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

                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart == null || chart.Type != Aspose.Slides.Charts.ChartType.Doughnut)
                {
                    Console.WriteLine("No doughnut chart found on the first slide.");
                    return;
                }

                // Adjust the first slice angle
                chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 45;

                // Adjust the doughnut hole size
                chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50;

                // Change colors of individual data points
                Aspose.Slides.Charts.IChartDataPoint point1 = chart.ChartData.Series[0].DataPoints[0];
                point1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                point1.Format.Fill.SolidFillColor.Color = Color.Red;

                Aspose.Slides.Charts.IChartDataPoint point2 = chart.ChartData.Series[0].DataPoints[1];
                point2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                point2.Format.Fill.SolidFillColor.Color = Color.Green;

                Aspose.Slides.Charts.IChartDataPoint point3 = chart.ChartData.Series[0].DataPoints[2];
                point3.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                point3.Format.Fill.SolidFillColor.Color = Color.Blue;

                // Update data values
                Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
                dataPoints.Clear();
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                dataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 1, 1, 30));
                dataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 2, 1, 50));
                dataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 3, 1, 20));

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}
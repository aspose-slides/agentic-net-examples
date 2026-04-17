using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace DoughnutChartPalette
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "CorporateDoughnutChart.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a doughnut chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Doughnut,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Set the doughnut hole size (e.g., 60%)
                chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)60;

                // Define corporate color palette
                Color[] corporateColors = new Color[]
                {
                    Color.FromArgb(0, 112, 192),   // Corporate Blue
                    Color.FromArgb(255, 192, 0),   // Corporate Gold
                    Color.FromArgb(0, 176, 80)     // Corporate Green
                };

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1");
                workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2");
                workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3");
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Revenue"),
                    chart.Type
                );

                // Add data points for the series
                series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 45));
                series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 25));

                // Apply corporate colors to each data point
                for (int i = 0; i < series.DataPoints.Count; i++)
                {
                    Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[i];
                    point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = corporateColors[i % corporateColors.Length];
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found: " + fnfEx.Message);
            }
            catch (ArgumentException argEx)
            {
                // Handle unsupported format or invalid arguments
                Console.WriteLine("Argument error (possible unsupported format): " + argEx.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
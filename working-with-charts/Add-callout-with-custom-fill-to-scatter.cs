using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace ScatterChartCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ScatterChartWithCallout.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a scatter chart
                IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Clear default series and categories
                chart.ChartData.Series.Clear();

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

                // Populate Series 1 with data points
                IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 1.0), workbook.GetCell(defaultWorksheetIndex, 2, 2, 2.0));
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 2.0), workbook.GetCell(defaultWorksheetIndex, 3, 2, 3.0));
                // Outlier point
                IChartDataPoint outlierPoint = series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 3.0), workbook.GetCell(defaultWorksheetIndex, 4, 2, 15.0));

                // Highlight the outlier point with a distinct fill color
                outlierPoint.Format.Fill.FillType = FillType.Solid;
                outlierPoint.Format.Fill.SolidFillColor.Color = Color.Red;

                // Add a callout shape near the outlier point
                // Position the callout manually (example coordinates)
                AutoShape callout = (AutoShape)slide.Shapes.AddAutoShape(ShapeType.Callout1, 250, 250, 150, 50);
                callout.TextFrame.Text = "Outlier";
                callout.FillFormat.FillType = FillType.Solid;
                callout.FillFormat.SolidFillColor.Color = Color.Yellow;
                callout.LineFormat.FillFormat.FillType = FillType.Solid;
                callout.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
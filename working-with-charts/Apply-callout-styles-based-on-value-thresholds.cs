using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CalloutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "CalloutChart.pptx";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add a clustered column chart
                IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Access the chart data workbook
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(wb.GetCell(defaultWorksheetIndex, 0, 0, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, 1, 0, "A"));
                chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, 2, 0, "B"));
                chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, 3, 0, "C"));

                // Ensure the series uses literal double values
                series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                // Add data points with literal values
                series.DataPoints.AddDataPointForBarSeries(10.0);
                series.DataPoints.AddDataPointForBarSeries(55.0);
                series.DataPoints.AddDataPointForBarSeries(30.0);

                // Enable callouts for data labels
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Apply distinct callout styles based on value thresholds
                foreach (IChartDataPoint dp in series.DataPoints)
                {
                    double pointValue = dp.Value.ToDouble();

                    if (pointValue > 50.0)
                    {
                        // High values: red fill
                        dp.Format.Fill.FillType = FillType.Solid;
                        dp.Format.Fill.SolidFillColor.Color = Color.Red;
                        dp.Format.Line.FillFormat.FillType = FillType.Solid;
                        dp.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
                    }
                    else if (pointValue < 20.0)
                    {
                        // Low values: green fill
                        dp.Format.Fill.FillType = FillType.Solid;
                        dp.Format.Fill.SolidFillColor.Color = Color.Green;
                        dp.Format.Line.FillFormat.FillType = FillType.Solid;
                        dp.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
                    }
                    else
                    {
                        // Medium values: yellow fill
                        dp.Format.Fill.FillType = FillType.Solid;
                        dp.Format.Fill.SolidFillColor.Color = Color.Yellow;
                        dp.Format.Line.FillFormat.FillType = FillType.Solid;
                        dp.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
                    }
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace CalloutStylesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Get the default worksheet index
            int defaultWorksheetIndex = 0;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default generated series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate series with data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20.0));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50.0));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30.0));

            // Enable callouts for all data labels in this series
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Apply distinct callout styles based on value thresholds
            for (int i = 0; i < series.DataPoints.Count; i++)
            {
                IChartDataPoint point = series.DataPoints[i];

                // Retrieve the numeric value from the underlying cell (known from insertion order)
                double pointValue = 0.0;
                if (i == 0) pointValue = 20.0;
                else if (i == 1) pointValue = 50.0;
                else if (i == 2) pointValue = 30.0;

                // Set callout style per point
                if (pointValue > 40.0)
                {
                    // High values: red fill, thick black border
                    point.Format.Fill.FillType = FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = Color.Red;
                    point.Format.Line.FillFormat.FillType = FillType.Solid;
                    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
                    point.Format.Line.Width = 2.0;
                }
                else
                {
                    // Low/medium values: green fill, thin gray border
                    point.Format.Fill.FillType = FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = Color.Green;
                    point.Format.Line.FillFormat.FillType = FillType.Solid;
                    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
                    point.Format.Line.Width = 1.0;
                }

                // Ensure the individual data label also shows as a callout
                point.Label.DataLabelFormat.ShowLabelAsDataCallout = true;
                point.Label.DataLabelFormat.ShowLeaderLines = true;
                point.Label.DataLabelFormat.ShowValue = true;
            }

            // Save the presentation
            try
            {
                pres.Save("CalloutStyles.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
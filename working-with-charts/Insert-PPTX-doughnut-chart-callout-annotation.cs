using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesCalloutExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a doughnut chart
                IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                // Add data points for the doughnut series
                series.DataPoints.AddDataPointForDoughnutSeries(30);
                series.DataPoints.AddDataPointForDoughnutSeries(50);
                series.DataPoints.AddDataPointForDoughnutSeries(20);

                // Enable callout for data labels in the series
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Customize the first data point's callout appearance
                IChartDataPoint firstPoint = series.DataPoints[0];

                // Set fill color of the callout
                firstPoint.Format.Fill.FillType = FillType.Solid;
                firstPoint.Format.Fill.SolidFillColor.Color = Color.LightBlue;

                // Set line color and width of the callout
                firstPoint.Format.Line.FillFormat.FillType = FillType.Solid;
                firstPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
                firstPoint.Format.Line.Width = 1.5f;

                // Set text format of the callout
                firstPoint.Label.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
                firstPoint.Label.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
                firstPoint.Label.DataLabelFormat.TextFormat.PortionFormat.FontItalic = NullableBool.False;

                // Save the presentation
                presentation.Save("DoughnutChartWithCallout.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
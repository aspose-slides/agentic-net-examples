using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a doughnut chart
                IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 500f, 400f);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20f;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                IChartDataCell catCell1 = workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1");
                IChartDataCell catCell2 = workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2");
                IChartDataCell catCell3 = workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3");
                chart.ChartData.Categories.Add(catCell1);
                chart.ChartData.Categories.Add(catCell2);
                chart.ChartData.Categories.Add(catCell3);

                // Add a series with a name
                IChartDataCell seriesNameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "Product A");
                IChartSeries series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

                // Populate series data points
                series.DataPoints.AddDataPointForDoughnutSeries(30.0);
                series.DataPoints.AddDataPointForDoughnutSeries(45.0);
                series.DataPoints.AddDataPointForDoughnutSeries(25.0);

                // Customize series appearance
                series.Format.Fill.FillType = FillType.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.CornflowerBlue;
                series.Explosion = 10; // explode slices by 10%
                series.ParentSeriesGroup.DoughnutHoleSize = 60; // set hole size to 60%

                // Save the presentation
                pres.Save("DoughnutChartOutput.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
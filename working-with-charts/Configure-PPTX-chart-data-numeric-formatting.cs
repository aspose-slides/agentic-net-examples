using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConfigureChartNumericFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Add a clustered column chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Get the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default sample data
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Add a series
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                    // Populate series data and set numeric format (e.g., two decimal places)
                    Aspose.Slides.Charts.IChartDataCell cell1 = workbook.GetCell(0, 1, 1, 1234.567);
                    cell1.PresetNumberFormat = 2; // 0.00 format
                    series.DataPoints.AddDataPointForBarSeries(cell1);

                    Aspose.Slides.Charts.IChartDataCell cell2 = workbook.GetCell(0, 2, 1, 2345.678);
                    cell2.PresetNumberFormat = 2;
                    series.DataPoints.AddDataPointForBarSeries(cell2);

                    Aspose.Slides.Charts.IChartDataCell cell3 = workbook.GetCell(0, 3, 1, 3456.789);
                    cell3.PresetNumberFormat = 2;
                    series.DataPoints.AddDataPointForBarSeries(cell3);

                    // Save the presentation
                    pres.Save("ChartNumericFormatting_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
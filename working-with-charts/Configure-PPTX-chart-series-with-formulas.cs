using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormulaExample
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

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Get the chart's data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                int defaultWorksheetIndex = 0;

                // Add series names using workbook cells
                IChartDataCell series1NameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1");
                IChartSeries series1 = chart.ChartData.Series.Add(series1NameCell, chart.Type);

                IChartDataCell series2NameCell = workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2");
                IChartSeries series2 = chart.ChartData.Series.Add(series2NameCell, chart.Type);

                // Add categories
                IChartDataCell cat1 = workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1");
                chart.ChartData.Categories.Add(cat1);
                IChartDataCell cat2 = workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2");
                chart.ChartData.Categories.Add(cat2);
                IChartDataCell cat3 = workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3");
                chart.ChartData.Categories.Add(cat3);

                // Set up cells with values and a formula for Series 1
                workbook.GetCell(defaultWorksheetIndex, "B2", 2);
                workbook.GetCell(defaultWorksheetIndex, "B3", 3);
                IChartDataCell b4Cell = workbook.GetCell(defaultWorksheetIndex, "B4");
                b4Cell.Formula = "B2+B3";

                // Add data points to Series 1 referencing the cells
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B2"));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B3"));
                series1.DataPoints.AddDataPointForBarSeries(b4Cell);

                // Add data points to Series 2 with static values
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Save the presentation
                pres.Save("ChartWithFormulas.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartWithFormulasDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Add a clustered column chart
                var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Get chart data workbook
                var chartData = chart.ChartData;
                var defaultWorksheetIndex = 0;
                var workbook = chartData.ChartDataWorkbook;

                // Clear default series and categories
                chartData.Series.Clear();
                chartData.Categories.Clear();

                // Add series with names from cells
                var series1NameCell = workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1");
                var series2NameCell = workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2");
                var series1 = chartData.Series.Add(series1NameCell, chart.Type);
                var series2 = chartData.Series.Add(series2NameCell, chart.Type);

                // Add categories
                var category1Cell = workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A");
                var category2Cell = workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B");
                chartData.Categories.Add(category1Cell);
                chartData.Categories.Add(category2Cell);

                // Populate data cells
                var valueCell1 = workbook.GetCell(defaultWorksheetIndex, 1, 1, 10); // B2
                var valueCell2 = workbook.GetCell(defaultWorksheetIndex, 2, 1, 20); // B3
                var formulaCell = workbook.GetCell(defaultWorksheetIndex, 3, 1);   // B4
                formulaCell.Formula = "B2+B3";

                // Add data points referencing the cells
                series1.DataPoints.AddDataPointForBarSeries(valueCell1);
                series1.DataPoints.AddDataPointForBarSeries(formulaCell);
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));

                // Calculate formulas to update cell values
                workbook.CalculateFormulas();

                // Save the presentation
                presentation.Save("ChartWithFormulas.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
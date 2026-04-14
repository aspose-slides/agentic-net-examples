using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "MultiLevelCategoryChart.pptx";

        try
        {
            Presentation pres = new Presentation();
            // Add a clustered column chart
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add multi-level categories (Region -> Country)
            IChartCategory category;

            // North America -> USA
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A2", "North America"));
            category.GroupingLevels.SetGroupingItem(0, "North America");
            category.GroupingLevels.SetGroupingItem(1, "USA");

            // North America -> Canada
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A3", "North America"));
            category.GroupingLevels.SetGroupingItem(0, "North America");
            category.GroupingLevels.SetGroupingItem(1, "Canada");

            // Europe -> Germany
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A4", "Europe"));
            category.GroupingLevels.SetGroupingItem(0, "Europe");
            category.GroupingLevels.SetGroupingItem(1, "Germany");

            // Europe -> France
            category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A5", "Europe"));
            category.GroupingLevels.SetGroupingItem(0, "Europe");
            category.GroupingLevels.SetGroupingItem(1, "France");

            // Add a series with data points
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "B1", "Sales"), ChartType.ClusteredColumn);
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B2", 5000));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B3", 3000));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B4", 4000));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B5", 3500));

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing input files
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
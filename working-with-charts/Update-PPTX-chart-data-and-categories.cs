using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A1", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A2", "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A3", "Category 3"));

            // Add two series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "B0", "Series 1"), ChartType.ClusteredColumn);
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "C0", "Series 2"), ChartType.ClusteredColumn);

            // Populate data points for series 1
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B1", 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B2", 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "B3", 30));

            // Populate data points for series 2
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "C1", 15));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "C2", 25));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "C3", 35));

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        else
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape is a chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add a new category
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "A4", "Category 4"));

                // Add a new series
                Aspose.Slides.Charts.IChartSeries newSeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "D0", "Series 3"), chart.Type);

                // Populate data points for the new series (matching the number of categories)
                newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D1", 40));
                newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D2", 50));
                newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D3", 60));
                newSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D4", 70));

                // Add a data point to each existing series for the new category
                foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
                {
                    // Use a literal value for simplicity
                    series.DataPoints.AddDataPointForBarSeries(0);
                }
            }

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
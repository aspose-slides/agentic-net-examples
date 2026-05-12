using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFromCsvExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input CSV and output presentation
            string inputCsvPath = "data.csv";
            string outputPptxPath = "ChartFromCsv.pptx";

            // Verify that the CSV file exists
            if (!File.Exists(inputCsvPath))
            {
                Console.WriteLine("CSV file not found: " + inputCsvPath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Use a blank layout for the new slide
            ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
            ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Clear the default sample data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Read CSV data
            string[] csvLines = File.ReadAllLines(inputCsvPath);
            if (csvLines.Length < 2)
            {
                Console.WriteLine("CSV file does not contain enough data.");
                presentation.Dispose();
                return;
            }

            // Parse header (first line) – first column is category, remaining columns are series names
            string[] headerColumns = csvLines[0].Split(',');
            int seriesCount = headerColumns.Length - 1;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add series based on header
            for (int i = 0; i < seriesCount; i++)
            {
                string seriesName = headerColumns[i + 1];
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, i + 1, seriesName), chart.Type);
            }

            // Add categories and data points
            for (int rowIndex = 1; rowIndex < csvLines.Length; rowIndex++)
            {
                string[] rowColumns = csvLines[rowIndex].Split(',');
                if (rowColumns.Length != headerColumns.Length)
                {
                    // Skip malformed rows
                    continue;
                }

                string categoryName = rowColumns[0];
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, rowIndex, 0, categoryName));

                for (int colIndex = 1; colIndex < rowColumns.Length; colIndex++)
                {
                    double cellValue;
                    if (!double.TryParse(rowColumns[colIndex], out cellValue))
                    {
                        cellValue = 0;
                    }

                    IChartSeries series = chart.ChartData.Series[colIndex - 1];
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, rowIndex, colIndex, cellValue));
                }
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPptxPath, SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
                // Comment: The requested format is not supported by Aspose.Slides.
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
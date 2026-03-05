using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartDataToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string outputCsvPath = Path.Combine(dataDir, "chart_data.csv");
            string outputPptxPath = Path.Combine(dataDir, "ExportChartData_out.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a sample chart (Clustered Column) with default data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 600f, 400f);

            // Access the embedded workbook that holds chart data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Determine the number of series and categories
            int seriesCount = chart.ChartData.Series.Count;
            int categoriesCount = chart.ChartData.Categories.Count;

            // Build CSV content
            StringBuilder csvBuilder = new StringBuilder();

            // Write header row (empty first cell + series names)
            csvBuilder.Append("Category");
            for (int s = 0; s < seriesCount; s++)
            {
                // Series name is stored in the first row of each series column
                object seriesNameObj = workbook.GetCell(0, 0, s + 1).Value;
                string seriesName = seriesNameObj != null ? seriesNameObj.ToString() : $"Series{s + 1}";
                csvBuilder.Append(',').Append(seriesName);
            }
            csvBuilder.AppendLine();

            // Write each category row with its data points
            for (int c = 0; c < categoriesCount; c++)
            {
                // Category name is stored in the first column of each category row
                object categoryNameObj = workbook.GetCell(0, c + 1, 0).Value;
                string categoryName = categoryNameObj != null ? categoryNameObj.ToString() : $"Category{c + 1}";
                csvBuilder.Append(categoryName);

                // Append each series value for this category
                for (int s = 0; s < seriesCount; s++)
                {
                    object cellValueObj = workbook.GetCell(0, c + 1, s + 1).Value;
                    string cellValue = cellValueObj != null ? cellValueObj.ToString() : "";
                    csvBuilder.Append(',').Append(cellValue);
                }
                csvBuilder.AppendLine();
            }

            // Write CSV file to disk
            File.WriteAllText(outputCsvPath, csvBuilder.ToString());

            // Save the presentation
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}
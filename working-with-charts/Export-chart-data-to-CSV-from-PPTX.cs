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
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output CSV file path
            string outputCsvPath = "chart_data.csv";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // StringBuilder to accumulate CSV content
                StringBuilder csvBuilder = new StringBuilder();

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only chart shapes
                        IChart chart = shape as IChart;
                        if (chart == null)
                            continue;

                        // Retrieve categories
                        IChartCategoryCollection categories = chart.ChartData.Categories;
                        int categoryCount = categories.Count;

                        // Retrieve series
                        IChartSeriesCollection seriesCollection = chart.ChartData.Series;
                        int seriesCount = seriesCollection.Count;

                        // Build CSV header: Category, Series1, Series2, ...
                        csvBuilder.Append("Category");
                        for (int s = 0; s < seriesCount; s++)
                        {
                            IChartSeries series = seriesCollection[s];
                            string seriesName = GetStringFromBaseValue(series.Name);
                            csvBuilder.Append("," + EscapeCsv(seriesName));
                        }
                        csvBuilder.AppendLine();

                        // Build rows for each category
                        for (int c = 0; c < categoryCount; c++)
                        {
                            IChartCategory category = categories[c];
                            string categoryName = GetStringFromBaseValue(category.Value);
                            csvBuilder.Append(EscapeCsv(categoryName));

                            // Append each series value for this category
                            for (int s = 0; s < seriesCount; s++)
                            {
                                IChartSeries series = seriesCollection[s];
                                if (c < series.DataPoints.Count)
                                {
                                    IBaseChartValue pointValue = series.DataPoints[c].Value;
                                    string cellText = GetStringFromBaseValue(pointValue);
                                    csvBuilder.Append("," + EscapeCsv(cellText));
                                }
                                else
                                {
                                    csvBuilder.Append(","); // Empty cell if data point missing
                                }
                            }
                            csvBuilder.AppendLine();
                        }

                        // Write CSV for the first chart found (remove break to process all charts)
                        File.WriteAllText(outputCsvPath, csvBuilder.ToString());
                        Console.WriteLine("Chart data exported to: " + outputCsvPath);
                        // Optionally, break after first chart
                        // break;
                    }
                }

                // Save the presentation before exiting (as per requirement)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }

        // Helper method to extract string representation from various chart value types
        private static string GetStringFromBaseValue(object valueObj)
        {
            if (valueObj == null)
                return string.Empty;

            // Direct string
            string directString = valueObj as string;
            if (directString != null)
                return directString;

            // IStringChartValue
            IStringChartValue stringChartValue = valueObj as IStringChartValue;
            if (stringChartValue != null)
                return stringChartValue.AsLiteralString ?? string.Empty;

            // IDoubleChartValue
            IDoubleChartValue doubleChartValue = valueObj as IDoubleChartValue;
            if (doubleChartValue != null)
                return doubleChartValue.AsLiteralDouble.ToString();

            // IStringOrDoubleChartValue
            IStringOrDoubleChartValue stringOrDouble = valueObj as IStringOrDoubleChartValue;
            if (stringOrDouble != null)
            {
                // Prefer literal string if set
                if (!string.IsNullOrEmpty(stringOrDouble.AsLiteralString))
                    return stringOrDouble.AsLiteralString;
                return stringOrDouble.AsLiteralDouble.ToString();
            }

            // Fallback to ToString()
            return valueObj.ToString();
        }

        // Helper method to escape CSV fields
        private static string EscapeCsv(string field)
        {
            if (field == null)
                return string.Empty;

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                string escaped = field.Replace("\"", "\"\"");
                return "\"" + escaped + "\"";
            }
            return field;
        }
    }
}
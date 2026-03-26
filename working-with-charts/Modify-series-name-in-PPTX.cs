using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ModifySeriesName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (File.Exists(inputPath))
            {
                // Load existing presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Assume the first shape on the first slide is a chart
                    IShape shape = pres.Slides[0].Shapes[0];
                    IChart chart = shape as IChart;
                    if (chart != null)
                    {
                        // Access the workbook that holds chart data
                        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                        // Update the name of the first series (cell at row 0, column 1)
                        // The first series name is stored in the first worksheet at (0,1)
                        workbook.GetCell(0, 0, 1, "Updated Series Name");
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            else
            {
                // Create a new presentation with a chart and set a custom series name
                using (Presentation pres = new Presentation())
                {
                    // Add a chart to the first slide
                    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

                    // Get the workbook for chart data
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Remove default sample series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series with the desired name
                    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Updated Series Name"), chart.Type);

                    // Add a sample category (required for the chart to display data)
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));

                    // Save the newly created presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
    }
}
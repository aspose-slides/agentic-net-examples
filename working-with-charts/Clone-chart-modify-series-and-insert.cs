// -----------------------------------------------------------------------------
// Example: Clone chart modify series and insert using C#
//
// Description:
// Demonstrates how to clone a chart from a source presentation, modify its
// series and categories, and insert it into a new presentation using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Chart, Modify, Series,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of charts, modifying series, and inserting into new PPTX.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "source.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist: " + sourcePath);
            return;
        }

        try
        {
            using (Presentation sourcePres = new Presentation(sourcePath))
            {
                // Assume the first slide contains the chart to clone
                ISlide sourceSlide = sourcePres.Slides[0];
                IShape shape = sourceSlide.Shapes[0];
                IChart sourceChart = shape as IChart;
                if (sourceChart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                using (Presentation destPres = new Presentation())
                {
                    // Use the first slide of the destination presentation
                    ISlide destSlide = destPres.Slides[0];

                    // Add a new chart with the same type as the source chart
                    IChart clonedChart = destSlide.Shapes.AddChart(sourceChart.Type, 0, 0, 500, 400);

                    // Modify the series of the cloned chart
                    clonedChart.ChartData.Series.Clear();
                    clonedChart.ChartData.Categories.Clear();

                    IChartDataWorkbook workbook = clonedChart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Add categories
                    clonedChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    clonedChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                    clonedChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                    // Add first series
                    IChartSeries series1 = clonedChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), clonedChart.Type);
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                    // Add second series
                    IChartSeries series2 = clonedChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), clonedChart.Type);
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

                    // Save the modified presentation
                    destPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

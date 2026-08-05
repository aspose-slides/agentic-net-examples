// -----------------------------------------------------------------------------
// Example: Load CSV data into sunburst chart using C#
//
// Description:
// Demonstrates how to read CSV data and populate a Sunburst chart in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a Sunburst chart, clears any default data, reads category
// and value pairs from a CSV file, builds the hierarchical chart structure, and
// saves the result as a PPTX file. This pattern can be used to automate PPTX
// generation, integrate data-driven charts, or validate presentation workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, CSV, Sunburst, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading CSV data into a Sunburst chart.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with data-driven charts in .NET applications.
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
        string csvPath = "data.csv";
        string outputPath = "SunburstChart.pptx";

        if (!File.Exists(csvPath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        Presentation presentation = new Presentation();
        ISlide slide = presentation.Slides[0];
        IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 600f, 400f);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);

        // Add a root category required for Sunburst hierarchy
        IChartCategory rootCategory = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Root"));
        rootCategory.GroupingLevels.SetGroupingItem(0, "Root");

        IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

        using (StreamReader reader = new StreamReader(csvPath))
        {
            string line;
            int rowIndex = 1; // Excel rows are zero‑based in the workbook API
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 2)
                    continue;

                string category = parts[0];
                double value;
                if (!double.TryParse(parts[1], out value))
                    continue;

                // Add a category for the hierarchy (optional)
                IChartCategory cat = chart.ChartData.Categories.Add(workbook.GetCell(0, "C" + (rowIndex + 1), category));
                cat.GroupingLevels.SetGroupingItem(0, category);

                // Add the data point to the Sunburst series
                series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D" + (rowIndex + 1), value));

                rowIndex++;
            }
        }

        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}

// -----------------------------------------------------------------------------
// Example: Set custom percentage symbol in chart data labels using C#
//
// Description:
// Demonstrates how to create a clustered column chart, add categories and a series,
// enable percentage display for data labels, and customize the percentage symbol
// (e.g., using a per‑mille sign) via the NumberFormat property. The example uses
// Aspose.Slides for .NET to generate a PPTX file with the customized chart.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Data Labels, Percentage Symbol,
// NumberFormat, Clustered Column Chart, Presentation Automation
//
// Use Cases:
// - Generate PowerPoint charts with custom percentage symbols.
// - Automate chart creation and formatting in .NET applications.
// - Produce presentations where data labels require non‑standard symbols.
// - Integrate custom chart labeling into reporting tools.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Access chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add data points
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 30));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 70));

                // Enable percentage display for data labels
                series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

                // Customize the percentage symbol using NumberFormat (e.g., per‑mille sign)
                series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0‰";

                // Save the presentation
                try
                {
                    presentation.Save("ChartWithCustomPercentageSymbol.pptx", SaveFormat.Pptx);
                }
                catch (Exception)
                {
                    // Format not supported
                }
            }
        }
    }
}

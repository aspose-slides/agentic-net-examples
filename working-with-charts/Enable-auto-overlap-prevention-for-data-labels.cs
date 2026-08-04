// -----------------------------------------------------------------------------
// Example: Enable auto overlap prevention for data labels using C#
//
// Description:
// Demonstrates how to enable (or prepare for) auto overlap prevention for data
// labels in a chart using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a clustered column chart, ensures a series and
// categories exist, enables value labels, and shows where the overlap
// prevention setting would be applied. The presentation is saved as a PPTX file.
// This pattern can be used to automate chart label handling in PowerPoint
// files within .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Labels, Auto,
// Overlap Prevention, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling auto overlap prevention for chart data labels.
// - Build C# utilities for processing PowerPoint charts and labels.
// - Generate or modify PPTX files with charts in .NET applications.
// - Validate and adjust chart label layout before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure there is at least one series; if not, add a default series
            if (chart.ChartData.Series.Count == 0)
            {
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                chart.ChartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            }

            // Enable data labels to show values for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Enable automatic overlapping prevention for data labels
            // Note: In the current Aspose.Slides version, IDataLabelFormat does not expose an OverlapMode property.
            // If the property becomes available, it would be set as shown below:
            // chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.OverlapMode = OverlapMode.Auto;

            // Save the presentation
            pres.Save("Output.pptx", SaveFormat.Pptx);
        }
    }
}

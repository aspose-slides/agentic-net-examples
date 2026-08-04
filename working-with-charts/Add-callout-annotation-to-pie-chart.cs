// -----------------------------------------------------------------------------
// Example: Add callout annotation to pie chart using C#
//
// Description:
// Demonstrates how to add a callout annotation to a pie chart using C# and 
// Aspose.Slides for .NET. The example creates a presentation, inserts a pie 
// chart, populates it with categories and data, enables data labels as callouts, 
// and saves the result as a PPTX file. This pattern can be used to automate 
// PowerPoint chart enhancements, validate visual output, or integrate chart 
// creation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Callout, Annotation, Chart, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding callout annotations to pie charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with annotated charts in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            presentation.Save("PieChartWithCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Add bubble border thickness to chart using C#
//
// Description:
// Demonstrates how to set the border thickness of bubbles in a bubble chart
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a bubble chart, configures the line width of the bubbles, optionally
// sets the bubble size representation, populates sample data, and saves the
// file as a PPTX. This pattern can be used to customize bubble chart appearance
// in automated PowerPoint generation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Border Thickness, 
// Chart Customization, Presentation Generation, Office Automation
//
// Use Cases:
// - Automate setting bubble border thickness in PowerPoint charts.
// - Build C# utilities for customizing chart appearance in PPTX files.
// - Generate or modify presentations with specific bubble chart styling.
// - Validate chart formatting in automated PowerPoint workflows.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "BubbleChart.pptx";
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);
            // Set custom bubble border thickness
            chart.LineFormat.Width = 5;
            // Optional: set bubble size representation
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;
            // Add sample data points
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series.DataPoints.AddDataPointForBubbleSeries(10, 20, 30);
            series.DataPoints.AddDataPointForBubbleSeries(15, 25, 35);
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception)
        {
            // Format not supported.
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}

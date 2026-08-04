// -----------------------------------------------------------------------------
// Example: Adjust pie chart data label position using C#
//
// Description:
// Demonstrates how to adjust the data label position of a pie chart using C# 
// and Aspose.Slides for .NET. The example creates a new presentation, adds a 
// pie chart, sets the data labels to appear outside the slices, optionally 
// shows the values on the labels, and saves the result as a PPTX file. This 
// pattern can be used to automate chart formatting tasks in PowerPoint 
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Chart, Data, Label, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adjustment of pie chart data label positions.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart labeling in .NET 
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

            // Adjust the position of data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

            // Optionally show the values on data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation
            string outputPath = "PieChartWithLabelPosition.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Show value and category labels on stacked area chart using C#
//
// Description:
// Demonstrates how to display both value and category name data labels on a
// stacked area chart using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a stacked area chart, configures the first series to
// show value and category name on its data labels, and saves the result as a
// PPTX file. This pattern can be used to automate chart labeling in PowerPoint
// files within .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Stacked Area Chart, Data Labels,
// Show Value, Show Category Name, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding value and category labels to stacked area charts.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart labeling requirements.
// - Validate chart data label settings before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedArea, 50f, 50f, 600f, 400f);
            // Show both value and category name on data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            // Save the presentation
            presentation.Save("StackedAreaChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

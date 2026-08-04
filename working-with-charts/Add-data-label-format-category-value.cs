// -----------------------------------------------------------------------------
// Example: Add data label format category value using C#
//
// Description:
// Demonstrates how to configure data labels of a chart to display both the
// category name and the value, and how to set a custom separator between them
// using Aspose.Slides for .NET. The example creates a new presentation, adds a
// pie chart, modifies the default data label format, and saves the result as a
// PPTX file. This pattern can be used to automate chart label customization in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Labels, Category Name,
// Value, Separator, Presentation Processing, Office Automation
//
// Use Cases:
// - Customize chart data labels to show category names and values.
// - Set custom separators for chart data labels.
// - Build .NET tools for PowerPoint chart formatting.
// - Automate PPTX generation with specific chart label requirements.
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
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data labels to show both category name and value
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Set a separator between category name and value
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = ", ";

        // Save the presentation
        try
        {
            presentation.Save("CustomDataLabel.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}

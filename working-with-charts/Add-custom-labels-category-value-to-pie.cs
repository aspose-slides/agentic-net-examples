// -----------------------------------------------------------------------------
// Example: Add custom labels category value to pie using C#
//
// Description:
// Demonstrates how to add custom data labels that display both the category name
// and the value with a custom separator to a pie chart using C# and Aspose.Slides
// for .NET. The example creates a new presentation, inserts a pie chart, configures
// the data label format, and saves the presentation as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie Chart, Custom Labels,
// Category Name, Value, Separator, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding custom category and value labels to pie charts.
// - Build C# utilities for PowerPoint chart customization.
// - Generate PPTX files with tailored chart labeling in .NET applications.
// - Validate chart label configurations before publishing presentations.
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
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f, 50f, 500f, 400f);

        // Customize data labels to show both category name and value with a separator
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = " - ";

        // Save the presentation
        try
        {
            pres.Save("CustomDataLabelPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            // Format not supported: ex.Message
        }
    }
}

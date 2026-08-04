// -----------------------------------------------------------------------------
// Example: Add data labels show category and value using C#
//
// Description:
// Demonstrates how to add data labels that show both category name and value
// on a pie chart using C# and Aspose.Slides for .NET. The example creates a
// presentation, inserts a pie chart, configures the data labels, and saves the
// result as a PPTX file. This pattern can be used to automate chart labeling
// tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie Chart, Data Labels,
// Category Name, Value, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding data labels with category and value to charts.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart labeling in .NET apps.
// - Validate chart data presentation before publishing.
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
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data labels to show both category name and value
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        try
        {
            pres.Save("CustomDataLabel.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}

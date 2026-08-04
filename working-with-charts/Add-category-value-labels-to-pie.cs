// -----------------------------------------------------------------------------
// Example: Add category value labels to pie using C#
//
// Description:
// Demonstrates how to add both category names and values as data labels to a
// pie chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a pie chart, configures the data label format to show
// the category name and value separated by a custom delimiter, and saves the
// result as a PPTX file. This pattern can be used to automate chart label
// customization in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Category, Value, Labels,
// Chart, Pie Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding category and value labels to pie charts.
// - Build C# tools for PowerPoint chart processing and customization.
// - Generate or transform PPTX files with customized chart data labels.
// - Validate chart label configurations before publishing or integration.
// -----------------------------------------------------------------------------

using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

        // Customize data labels to show both category name and value with a separator
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = " - ";

        // Save the presentation
        pres.Save("CustomDataLabelPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

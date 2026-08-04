// -----------------------------------------------------------------------------
// Example: Unlink data label number format from source using C#
//
// Description:
// Demonstrates how to unlink a data label's number format from its source data
// and apply a custom number format to a pie chart using Aspose.Slides for .NET.
// The example creates a presentation, adds a pie chart, modifies the data label
// formatting, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Unlink, Data Label, Number Format,
// Chart, Pie Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the removal of linked number formatting for chart data labels.
// - Build C# utilities that customize chart appearance in PowerPoint files.
// - Generate or modify PPTX presentations with specific data label formats.
// - Validate and preprocess presentation content before distribution.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide (created by default)
        ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Charts.IChart chart = slide.Shapes.AddChart(Charts.ChartType.Pie, 50, 50, 400, 400);

        // Unlink data label number format from source data
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;

        // Optionally set a custom number format for the data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

        // Save the presentation
        presentation.Save("UnlinkedDataLabel.pptx", SaveFormat.Pptx);
    }
}

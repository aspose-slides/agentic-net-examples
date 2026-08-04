// -----------------------------------------------------------------------------
// Example: Add currency symbol to data labels using C#
//
// Description:
// Demonstrates how to add a currency symbol to data labels in a pie chart using
// C# and Aspose.Slides for .NET. The example creates a presentation, inserts a
// pie chart, configures data label formatting, applies a custom number format
// that includes a dollar sign, and saves the result as a PPTX file. This pattern
// can be used to automate chart formatting tasks in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Currency Symbol, Data Labels,
// Charts, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding currency symbols to chart data labels.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with formatted charts in .NET applications.
// - Validate chart label formatting before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data label settings
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

        // Set custom number format to include currency symbol
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "\"$\"#,##0.00";

        // Save the presentation
        presentation.Save("CustomCurrencyLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}

// -----------------------------------------------------------------------------
// Example: Enable percentage data labels on chart using C#
//
// Description:
// Demonstrates how to enable percentage data labels (and optionally values) on a
// stacked column chart using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a stacked column chart, configures the first series to
// show percentage and value data labels, and saves the result as a PPTX file.
// This pattern can be used to automate chart labeling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Stacked Column, Percentage,
// Data Labels, ShowValue, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling percentage data labels on charts in PPTX files.
// - Build C# utilities for customizing chart appearance in presentations.
// - Generate or modify PowerPoint reports with detailed chart labeling.
// - Validate chart data representation before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn, 50f, 50f, 500f, 400f);

        // Enable displaying percentage values on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Optionally also show the actual values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("ChartWithPercentages.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

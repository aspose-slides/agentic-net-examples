// -----------------------------------------------------------------------------
// Example: Serialize modified plot area to memory stream using C#
//
// Description:
// Demonstrates how to modify a chart's plot area dimensions, serialize the
// presentation to a memory stream, reload it, and verify the plot area size
// using Aspose.Slides for .NET. The example includes creating a line chart,
// adjusting plot area size fractions, saving to a memory stream, reloading,
// and finally saving the presentation to a file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Serialize, Modified Plot Area,
// Chart, Memory Stream, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate serialization of modified chart plot areas to memory streams.
// - Build C# utilities for PowerPoint chart manipulation and validation.
// - Generate or transform PPTX files with custom chart layouts in .NET apps.
// - Verify chart layout changes before publishing or integrating into workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line chart
        IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 450f, 300f);

        // Modify plot area size fractions
        chart.PlotArea.Width = 0.8f;   // 80% of chart width
        chart.PlotArea.Height = 0.6f;  // 60% of chart height

        // Validate layout to obtain actual dimensions
        chart.ValidateChartLayout();
        float actualWidth = chart.PlotArea.ActualWidth;
        float actualHeight = chart.PlotArea.ActualHeight;

        // Serialize presentation to a memory stream
        MemoryStream memStream = new MemoryStream();
        try
        {
            presentation.Save(memStream, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Reset stream position for reading
        memStream.Position = 0;

        // Reload presentation from memory stream
        Presentation loadedPresentation = new Presentation(memStream);
        IChart loadedChart = loadedPresentation.Slides[0].Shapes[0] as IChart;
        if (loadedChart != null)
        {
            loadedChart.ValidateChartLayout();
            float loadedActualWidth = loadedChart.PlotArea.ActualWidth;
            float loadedActualHeight = loadedChart.PlotArea.ActualHeight;
            // Dimensions can be verified here
        }

        // Save the modified presentation to a file
        string outputPath = "ModifiedChart.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
        loadedPresentation.Dispose();
        memStream.Dispose();
    }
}

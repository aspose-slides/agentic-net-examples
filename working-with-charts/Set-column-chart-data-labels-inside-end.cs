// -----------------------------------------------------------------------------
// Example: Set column chart data labels inside end using C#
//
// Description:
// Demonstrates how to set column chart data labels inside end using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Column, Chart, Data Labels, InsideEnd, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting column chart data labels inside end.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Set data label position to InsideEnd for all series
                for (int i = 0; i < chart.ChartData.Series.Count; i++)
                {
                    chart.ChartData.Series[i].Labels.DefaultDataLabelFormat.Position =
                        DataLabelPosition.InsideEnd;
                }

                // Save the presentation
                presentation.Save("Output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

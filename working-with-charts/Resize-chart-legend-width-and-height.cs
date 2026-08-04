// -----------------------------------------------------------------------------
// Example: Resize chart legend width and height using C#
//
// Description:
// Demonstrates how to resize a chart legend's width and height using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, adjusts the legend dimensions as fractions of the chart size, 
// and saves the result as a PPTX file. This pattern can be used to automate 
// PowerPoint chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Resize, Chart, Legend, Width, Height, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically adjust chart legend dimensions in generated presentations.
// - Build .NET tools for customizing PowerPoint chart appearance.
// - Automate PPTX creation with specific legend sizing requirements.
// - Validate and test chart formatting before deployment.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ResizeChartLegend
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Resize the legend by setting its Width and Height (as fractions of the chart size)
            chart.Legend.Width = 0.6f;   // 60% of the chart width
            chart.Legend.Height = 0.2f;  // 20% of the chart height

            // Save the presentation
            string outputPath = "ResizedLegendChart.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the format is not supported, handle accordingly
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}

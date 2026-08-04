// -----------------------------------------------------------------------------
// Example: Set chart data label background transparent using C#
//
// Description:
// Demonstrates how to set the background of chart data labels to transparent
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, enables data labels for the first series,
// and configures the data label fill to NoFill. The resulting PPTX file shows
// data labels without any background fill.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Labels, Background,
// Transparent, NoFill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart data label backgrounds to transparent.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with customized chart label appearance.
// - Validate chart formatting in automated presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartDataLabelBackgroundTransparent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Enable data labels for the first series
                IChartSeries series = chart.ChartData.Series[0];
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Set data label background to transparent (no fill)
                // DataLabelFormat.Format returns IFormat, which has Fill property
                series.Labels.DefaultDataLabelFormat.Format.Fill.FillType = FillType.NoFill;

                // Save the presentation
                try
                {
                    pres.Save("ChartDataLabelTransparent.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}

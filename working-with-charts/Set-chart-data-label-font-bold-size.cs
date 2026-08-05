// -----------------------------------------------------------------------------
// Example: Set chart data label font bold size using C#
//
// Description:
// Demonstrates how to set chart data label font to bold and increase its
// size using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, enables data labels for the first series,
// and modifies the label font properties. The resulting presentation is saved
// as a PPTX file. This pattern helps automate PPTX chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Labels, Font,
// Bold, Font Size, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart data label font style and size.
// - Build C# tools for PowerPoint chart formatting.
// - Generate or modify PPTX files with customized chart labels in .NET
//   applications.
// - Validate chart appearance programmatically before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartDataLabelFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(
                    ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Ensure the first series shows data labels
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Set data label font to bold and increase size
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 14f;

                // Save the presentation
                pres.Save("SetDataLabelFont_out.pptx", SaveFormat.Pptx);
            }
        }
    }
}

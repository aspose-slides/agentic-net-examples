using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetLegendOverlay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Ensure the chart has a legend
                chart.HasLegend = true;

                // Activate non‑overlay legend mode
                chart.Legend.Overlay = false;

                // Optionally set legend position
                chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

                try
                {
                    // Save the presentation
                    presentation.Save("SetLegendOverlay_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException ex)
                {
                    // Format not supported
                    Console.WriteLine("The requested save format is not supported: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetLegendOverlay
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

                    // Activate non‑overlay legend mode
                    chart.Legend.Overlay = false;

                    // Save the presentation
                    pres.Save("SetLegendOverlayFalse.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
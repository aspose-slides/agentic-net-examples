using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
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

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                    // Ensure the chart has a legend
                    chart.HasLegend = true;

                    // Set the legend position using the correct enum
                    chart.Legend.Position = LegendPositionType.Right;

                    // Save the presentation
                    pres.Save("StyledLegendChart.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
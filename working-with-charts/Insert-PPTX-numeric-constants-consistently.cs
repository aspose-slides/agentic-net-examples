using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace InsertNumericConstants
{
    class Program
    {
        // Predefined numeric constants used throughout the presentation
        private const float ChartX = 100F;
        private const float ChartY = 100F;
        private const float ChartWidth = 400F;
        private const float ChartHeight = 300F;
        private const int SliceExplosion = 30; // Percentage of explosion for the first pie slice

        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a pie chart with predefined dimensions
                    IChart chart = slide.Shapes.AddChart(
                        ChartType.Pie,
                        ChartX,
                        ChartY,
                        ChartWidth,
                        ChartHeight);

                    // Retrieve the first series of the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Set explosion for the first data point using the predefined constant
                    series.DataPoints[0].Explosion = SliceExplosion;

                    // Save the presentation before exiting
                    pres.Save("NumericConstantsPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during presentation creation or saving
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
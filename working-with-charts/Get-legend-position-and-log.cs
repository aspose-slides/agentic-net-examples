using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace LegendPositionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
                chart.ValidateChartLayout();

                // Retrieve the legend and its position
                ILegend legend = chart.Legend;
                LegendPositionType currentPosition = legend.Position;

                // Log the legend position for debugging
                Console.WriteLine("Current legend position: " + currentPosition.ToString());

                // Save the presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
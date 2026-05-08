using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace LayoutFallbackExample
{
    class Program
    {
        static void Main()
        {
            // Output file path
            string outputPath = "LayoutFallback.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 600, 400);

            // Define manual layout fractions for the plot area
            chart.PlotArea.AsILayoutable.X = 0.2f;
            chart.PlotArea.AsILayoutable.Y = 0.2f;
            chart.PlotArea.AsILayoutable.Width = 0.7f;
            chart.PlotArea.AsILayoutable.Height = 0.7f;

            // Attempt to set layout target to Outer
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;

            // Calculate actual layout values
            chart.ValidateChartLayout();

            // Fallback: if resulting width or height is negative, switch to Inner layout
            if (chart.PlotArea.AsILayoutable.Width < 0 || chart.PlotArea.AsILayoutable.Height < 0)
            {
                chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
                chart.ValidateChartLayout();
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
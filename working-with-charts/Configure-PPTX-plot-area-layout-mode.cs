using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(
                        ChartType.ClusteredColumn,
                        20f,
                        100f,
                        600f,
                        400f);

                    // Set the plot area layout target type to Inner (inside the axes)
                    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

                    // Optionally adjust the plot area position and size as fractions of the chart size
                    chart.PlotArea.AsILayoutable.X = 0.2f;
                    chart.PlotArea.AsILayoutable.Y = 0.2f;
                    chart.PlotArea.AsILayoutable.Width = 0.7f;
                    chart.PlotArea.AsILayoutable.Height = 0.7f;

                    // Save the presentation
                    presentation.Save("ChartPlotAreaLayout.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
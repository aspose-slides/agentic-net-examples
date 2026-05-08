using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Define an array of different chart types to compare
            ChartType[] chartTypes = new ChartType[]
            {
                ChartType.ClusteredColumn,
                ChartType.StackedColumn,
                ChartType.Pie,
                ChartType.Line,
                ChartType.Area,
                ChartType.ScatterWithMarkers,
                ChartType.BarOfPie,
                ChartType.Doughnut,
                ChartType.Bubble,
                ChartType.Radar
            };

            // Loop through each chart type and add a slide with the chart
            for (int i = 0; i < chartTypes.Length; i++)
            {
                // Add a new empty slide (use the layout of the first slide)
                ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a chart with sample data to the slide
                IChart chart = slide.Shapes.AddChart(chartTypes[i], 50f, 50f, 500f, 400f);

                // Set chart title to indicate the chart type
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding(chartTypes[i].ToString());
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20f;
            }

            try
            {
                // Save the presentation
                presentation.Save("ChartComparison.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
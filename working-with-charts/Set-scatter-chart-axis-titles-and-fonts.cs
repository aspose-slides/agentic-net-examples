using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetScatterChartAxisTitlesAndFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();

                // Add a scatter chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
                    50f, 50f, 500f, 400f);

                // Make sure axis titles are visible
                chart.Axes.HorizontalAxis.HasTitle = true;
                chart.Axes.VerticalAxis.HasTitle = true;

                // Set custom titles for X and Y axes
                chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("X Axis Title");
                chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Y Axis Title");

                // Set font properties for the axis titles
                chart.Axes.HorizontalAxis.Title.TextFormat.PortionFormat.FontHeight = 14f;
                chart.Axes.VerticalAxis.Title.TextFormat.PortionFormat.FontHeight = 14f;
                chart.Axes.HorizontalAxis.Title.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                chart.Axes.VerticalAxis.Title.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

                // Save the presentation
                presentation.Save("ScatterChartAxisTitles.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set plot area border thickness and color
            // Access line formatting through PlotArea.Format.Line
            chart.PlotArea.Format.Line.Width = 3.0; // Thickness
            chart.PlotArea.Format.Line.FillFormat.FillType = FillType.Solid;
            chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;

            // Optional: set line style
            chart.PlotArea.Format.Line.Style = LineStyle.Single;

            // Save the presentation
            try
            {
                presentation.Save("ChartPlotAreaBorder.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
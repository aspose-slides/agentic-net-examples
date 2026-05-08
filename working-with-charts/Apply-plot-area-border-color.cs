using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaBorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Apply a solid fill to the plot area (optional background color)
            chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

            // Set a custom border (line) color for the plot area
            chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            try
            {
                presentation.Save("ChartWithCustomPlotAreaBorder.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
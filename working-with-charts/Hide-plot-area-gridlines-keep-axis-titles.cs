using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace HideChartGridlines
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "HideGridlines.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Hide plot area gridlines by setting the plot area's line fill to transparent
            chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Transparent;

            // Axis titles remain visible by default; no changes needed

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
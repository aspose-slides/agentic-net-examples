using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetPlotAreaBorder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Set plot area border thickness
                chart.PlotArea.Format.Line.Width = 2f;

                // Set plot area border color to red
                chart.PlotArea.Format.Line.FillFormat.FillType = FillType.Solid;
                chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                // Save the presentation
                presentation.Save("SetPlotAreaBorder.pptx", SaveFormat.Pptx);
            }
        }
    }
}
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UpdateLegendStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "UpdatedLegend.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure the chart has a legend
            chart.HasLegend = true;

            // Set legend background fill to light blue
            chart.Legend.Format.Fill.FillType = FillType.Solid;
            chart.Legend.Format.Fill.SolidFillColor.Color = Color.LightBlue;

            // Set legend border line style
            chart.Legend.Format.Line.FillFormat.FillType = FillType.Solid;
            chart.Legend.Format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
            chart.Legend.Format.Line.Width = 2f;

            // Modify legend text font
            chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;
            chart.Legend.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Position the legend on the right side of the chart
            chart.Legend.Position = LegendPositionType.Right;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}
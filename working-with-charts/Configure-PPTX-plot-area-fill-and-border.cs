using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConfigurePlotArea
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 600f, 400f);

                // Configure the plot area's fill color (solid blue)
                chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                chart.PlotArea.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Configure the plot area's border (solid black, width 2 points)
                chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                chart.PlotArea.Format.Line.Width = 2f;

                // Save the presentation
                presentation.Save("PlotAreaStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
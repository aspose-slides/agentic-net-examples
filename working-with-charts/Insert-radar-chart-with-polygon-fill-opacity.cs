using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.Radar, 50, 50, 500, 400);
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Radar Chart");

                IFillFormat fill = chart.PlotArea.Format.Fill;
                fill.FillType = FillType.Solid;
                fill.SolidFillColor.Color = Color.FromArgb(128, Color.LightGray);

                pres.Save("RadarChartOpacity.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
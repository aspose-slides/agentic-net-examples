using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartDataLabelFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(
                    ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Ensure the first series shows data labels
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Set data label font to bold and increase size
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 14f;

                // Save the presentation
                pres.Save("SetDataLabelFont_out.pptx", SaveFormat.Pptx);
            }
        }
    }
}
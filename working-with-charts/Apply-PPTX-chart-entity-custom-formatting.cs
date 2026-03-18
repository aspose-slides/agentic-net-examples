using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyChartFormatting
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 450f, 300f);

                // Set 3D rotation angles
                chart.Rotation3D.RotationX = 30; // Rotate around X‑axis
                chart.Rotation3D.RotationY = 45; // Rotate around Y‑axis

                // Save the presentation
                presentation.Save("FormattedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HidePlotAreaBorder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Hide the plot area border by setting its line fill type to NoFill
                chart.PlotArea.Format.Line.FillFormat.FillType = FillType.NoFill;

                // Save the presentation
                try
                {
                    pres.Save("HidePlotAreaBorder.pptx", SaveFormat.Pptx);
                }
                catch (ArgumentException)
                {
                    // Format not supported
                }
            }
        }
    }
}
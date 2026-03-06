using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetLegendFontSize
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
                0f, 0f, 500f, 400f);

            // Set the font size of the legend text
            chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

            // Save the presentation
            presentation.Save("SetLegendFontSize_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}
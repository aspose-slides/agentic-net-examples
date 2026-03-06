using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizePresentationCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Switch rows and columns of the chart data
            chart.ChartData.SwitchRowColumn();

            // Save the presentation to a PPTX file
            presentation.Save("CustomizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
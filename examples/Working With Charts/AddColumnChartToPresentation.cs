using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Switch rows and columns of the chart data (optional demonstration)
            chart.ChartData.SwitchRowColumn();

            // Save the presentation to a PPTX file
            presentation.Save("ColumnChart.pptx", SaveFormat.Pptx);
        }
    }
}
using System;

namespace SwapAxesDataExample
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

            // Swap the data between the X and Y axes
            chart.ChartData.SwitchRowColumn();

            // Save the presentation
            presentation.Save("SwapAxesData_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AxisLabelDistanceExample
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
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set the distance between the category axis labels and the axis (value between 0 and 1000)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)200;

            // Save the presentation to a PPTX file
            presentation.Save("CategoryAxisLabelDistance.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
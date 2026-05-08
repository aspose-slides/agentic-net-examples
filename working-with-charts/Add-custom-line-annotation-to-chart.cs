using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Add a custom straight line annotation to the chart at (100,200)
        // The line is added to the chart's UserShapes collection
        Aspose.Slides.IAutoShape lineShape = chart.UserShapes.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line,
            100f, 200f, 200f, 0f);
        lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        lineShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Save the presentation
        try
        {
            presentation.Save("CustomLineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception)
        {
            // Format not supported or other save error
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "RotatedAxisTitle.pptx";
        try
        {
            Presentation presentation = new Presentation();
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
            chart.Axes.VerticalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 45f;
            chart.Axes.HorizontalAxis.HasTitle = true;
            chart.Axes.HorizontalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = -30f;
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
        }
    }
}
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);
            chart.Axes.HorizontalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Bottom;
            chart.Axes.VerticalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Left;
            string outputPath = "ChartAxisPosition.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ChartAxisRotation.pptx";
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);
            chart.Axes.VerticalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90f;
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a 3D clustered column chart
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

            // Configure 3D rotation properties
            chart.Rotation3D.RotationX = (sbyte)30;      // Rotation around X-axis
            chart.Rotation3D.RotationY = (ushort)40;    // Rotation around Y-axis
            chart.Rotation3D.DepthPercents = (ushort)200; // Depth as percentage of chart width

            // Save the presentation
            string outputPath = "3DChartRotation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
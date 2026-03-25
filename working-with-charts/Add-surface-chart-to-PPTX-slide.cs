using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "template.pptx";
        string outputPath = "3DChartPresentation.pptx";

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
            }

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a Surface 3D chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Surface3D,
                50f, 50f, 500f, 400f);

            // Configure 3D rotation using the correct properties
            Aspose.Slides.Charts.IRotation3D rotation = chart.Rotation3D;
            rotation.DepthPercents = 200;      // Depth as percentage of chart width
            rotation.HeightPercents = 150;     // Height as percentage of chart width
            rotation.RotationX = 20;           // X‑axis rotation
            rotation.RotationY = 30;           // Y‑axis rotation
            rotation.Perspective = 30;         // Perspective angle
            rotation.RightAngleAxes = false;   // Use perspective

            // Add a title to the chart
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Surface 3D Chart");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Set 3D rotation angles using the Rotation3D property
            chart.Rotation3D.RotationX = (sbyte)30;   // X‑axis rotation
            chart.Rotation3D.RotationY = (ushort)40; // Y‑axis rotation

            // Add a title to the chart
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample 3D Chart");

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 450f, 300f);

            // Set 3D rotation angles
            chart.Rotation3D.RotationX = (sbyte)30;   // X-axis rotation
            chart.Rotation3D.RotationY = (ushort)20; // Y-axis rotation

            // Add a title with custom rotation
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.RotationAngle = 45f;

            // Save the presentation
            presentation.Save("FormattedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
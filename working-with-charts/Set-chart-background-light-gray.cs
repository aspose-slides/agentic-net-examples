using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Set chart background to light gray
                chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                chart.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

                // Preserve automatic callout colors (no changes needed)

                // Save the presentation
                presentation.Save("ChartBackgroundLightGray.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                // Handle any errors (e.g., unsupported format)
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
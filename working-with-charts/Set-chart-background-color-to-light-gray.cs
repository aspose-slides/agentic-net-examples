using System;
using System.Drawing;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Ensure series use automatic colors
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                chart.ChartData.Series[i].GetAutomaticSeriesColor();
            }

            // Set chart background to light gray
            chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

            // Save the presentation
            presentation.Save("ChartBackgroundLightGray.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
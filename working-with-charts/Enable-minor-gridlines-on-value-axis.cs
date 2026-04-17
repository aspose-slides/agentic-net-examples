using System;
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
            Presentation presentation = new Presentation();
            // Access the first slide
            ISlide slide = presentation.Slides[0];
            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            // Enable minor gridlines on the value (vertical) axis
            chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
            // Save the presentation
            string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "MinorGridlines_out.pptx");
            presentation.Save(outPath, SaveFormat.Pptx);
            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
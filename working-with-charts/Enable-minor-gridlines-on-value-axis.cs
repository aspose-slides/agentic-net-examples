using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Define output path
            string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "EnableMinorGridlines.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an Area chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 500f, 400f);

            // Validate layout to ensure axis values are calculated
            chart.ValidateChartLayout();

            // Enable minor gridlines on the vertical (value) axis by setting a visible fill type
            chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;

            // Save the presentation
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Ensure axis titles are visible
            chart.Axes.HorizontalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.HasTitle = true;

            // Hide major gridlines by setting their fill type to NoFill
            chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Hide minor gridlines by setting their fill type to NoFill
            chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Save the presentation
            try
            {
                pres.Save("HideGridlines.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
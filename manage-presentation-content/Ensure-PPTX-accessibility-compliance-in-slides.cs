using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Set alternative text for accessibility
                chart.AlternativeText = "Quarterly sales chart";
                chart.IsDecorative = false; // Not decorative, conveys information

                // Add a title to the chart
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Quarterly Sales");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Save the presentation
                presentation.Save("AccessiblePresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
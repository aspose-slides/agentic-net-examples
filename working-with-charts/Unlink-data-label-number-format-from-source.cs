using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UnlinkDataLabelExample
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

                // Add a Pie chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    50,   // X position
                    50,   // Y position
                    400,  // Width
                    400   // Height
                );

                // Unlink data label number format from source data
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

                // Save the presentation
                presentation.Save("UnlinkedDataLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
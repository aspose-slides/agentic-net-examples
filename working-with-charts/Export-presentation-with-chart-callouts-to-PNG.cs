using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutExample
{
    class Program
    {
        static void Main()
        {
            // Output file paths
            string presentationPath = "ChartCallout_out.pptx";
            string pngPath = "ChartCallout_slide.png";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a Pie chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                0f, 0f, 500f, 400f);

            // Enable data labels as callouts for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Save the presentation (required before exiting)
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export the first slide as PNG to verify callout appearance
            try
            {
                Aspose.Slides.IImage slideImage = slide.GetImage(2f, 2f); // Scale 2x for better resolution
                slideImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
            }
            catch (NotSupportedException)
            {
                // The requested image format is not supported
                // Comment: format not supported
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
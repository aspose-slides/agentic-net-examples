using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the path for the presentation file
            string presentationPath = "PieChartPresentation.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(presentationPath))
            {
                presentation = new Aspose.Slides.Presentation(presentationPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Ensure there is at least one slide
            Aspose.Slides.ISlide slide;
            if (presentation.Slides.Count > 0)
            {
                slide = presentation.Slides[0];
            }
            else
            {
                slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
            }

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                300f   // Height
            );

            // Customize data labels: show values and display as callouts
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Save the presentation
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
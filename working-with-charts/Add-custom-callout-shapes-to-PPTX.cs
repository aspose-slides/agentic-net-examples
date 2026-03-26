using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists; otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide (used to demonstrate callout data labels)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f,   // X position
            150f,  // Y position
            400f,  // Width
            300f   // Height
        );

        // Enable value display and set data labels to appear as callouts for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
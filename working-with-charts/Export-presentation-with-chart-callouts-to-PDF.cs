using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f, 50f, 500f, 400f);

        // Enable value display and set data labels as callouts for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation as PPTX
        string pptxPath = "ChartCallout.pptx";
        presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the presentation to PDF and verify callouts are preserved
        try
        {
            string pdfPath = "ChartCallout.pdf";
            presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation before exiting
        presentation.Dispose();
    }
}
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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

        // Enable callout for data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Prepare PDF/A compliance options
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA2a;

        // Save the presentation as PDF/A
        try
        {
            presentation.Save("ChartCallout.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            // Ensure resources are released
            presentation.Dispose();
        }
    }
}
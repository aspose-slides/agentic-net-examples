using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a pie chart to the slide
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Enable value display and set data labels as callouts
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Export the presentation to HTML5, confirming callout visibility
        string htmlOutput = "ChartCallout.html";
        try
        {
            presentation.Save(htmlOutput, Aspose.Slides.Export.SaveFormat.Html5, new Aspose.Slides.Export.Html5Options()
            {
                EmbedImages = true
            });
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation as PPTX before exiting
        presentation.Save("ChartCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
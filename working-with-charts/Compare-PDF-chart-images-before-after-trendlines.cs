using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPdfBefore = "ChartBefore.pdf";
        string outputPdfAfter = "ChartAfter.pdf";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Export PDF before adding trend lines
        try
        {
            pres.Save(outputPdfBefore, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Add a linear trend line to the first series
        Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        trendline.DisplayEquation = false;
        trendline.DisplayRSquaredValue = false;

        // Export PDF after adding trend lines
        try
        {
            pres.Save(outputPdfAfter, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Placeholder: Compare the two PDF files to ensure visual consistency
        // (Actual comparison logic would go here)

        // Save the presentation before exiting
        pres.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
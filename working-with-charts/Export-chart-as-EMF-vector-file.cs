using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");

            // Export the slide containing the chart as an EMF file
            string emfPath = "ChartSlide.emf";
            using (FileStream emfStream = new FileStream(emfPath, FileMode.Create, FileAccess.Write))
            {
                presentation.Slides[0].WriteAsEmf(emfStream);
            }

            // Save the presentation
            string pptxPath = "ChartPresentation.pptx";
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartToTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for output files
            string presentationPath = "ChartPresentation.pptx";
            string chartTiffPath = "ChartImage.tiff";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // (Optional) Customize chart data here if needed

            // Define high‑resolution TIFF options
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.DpiX = 300U; // Horizontal DPI
            tiffOptions.DpiY = 300U; // Vertical DPI

            try
            {
                // Render the slide (which contains the chart) to a TIFF image
                Aspose.Slides.IImage chartImage = presentation.Slides[0].GetImage(tiffOptions);

                // Save the chart image as TIFF
                chartImage.Save(chartTiffPath, Aspose.Slides.ImageFormat.Tiff);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Save the presentation before exiting
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideAxisLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Hide the horizontal axis line while keeping tick marks visible
                Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Hide the vertical axis line while keeping tick marks visible
                Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Save the presentation
                string outputPath = "HideAxisLine.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
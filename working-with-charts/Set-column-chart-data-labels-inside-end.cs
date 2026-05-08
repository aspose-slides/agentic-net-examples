using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Set data label position to InsideEnd for all series
                for (int i = 0; i < chart.ChartData.Series.Count; i++)
                {
                    chart.ChartData.Series[i].Labels.DefaultDataLabelFormat.Position =
                        Aspose.Slides.Charts.LegendDataLabelPosition.InsideEnd;
                }

                // Save the presentation
                presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
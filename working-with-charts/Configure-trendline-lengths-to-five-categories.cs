using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
                // Add a linear trendline to the first series
                Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
                trendline.Forward = 5;
                trendline.Backward = 5;
                // Save the presentation
                presentation.Save("TrendlineForwardBackward.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
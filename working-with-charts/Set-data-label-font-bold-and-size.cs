using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetDataLabelFontBoldAndSize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a pie chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Ensure there is at least one series and one data label
            // (AddChart creates a default series with sample data)
            // Set the data label font to bold
            chart.ChartData.Series[0].Labels[0].TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Increase the data label font size
            chart.ChartData.Series[0].Labels[0].TextFormat.PortionFormat.FontHeight = 20f;

            // Save the presentation
            try
            {
                pres.Save("DataLabelFontBoldAndSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                // Dispose the presentation
                pres.Dispose();
            }
        }
    }
}
using System;
using Aspose.Slides.Export;

namespace MyPresentationApp
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

                // Add a pie chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    0f, 0f, 500f, 400f);

                // Customize data label settings
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

                // Save the presentation
                pres.Save("PieChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
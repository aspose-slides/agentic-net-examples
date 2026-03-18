using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the first chart on the first slide (adjust indices as needed)
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                // Calculate all formulas in the embedded workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                workbook.CalculateFormulas();

                // Retrieve a string value from the first data point of the first series
                Aspose.Slides.Charts.IStringChartValue stringChartValue = chart.ChartData.Series[0].DataPoints[0].Value as Aspose.Slides.Charts.IStringChartValue;
                if (stringChartValue != null)
                {
                    string calculatedString = stringChartValue.ToString();
                    Console.WriteLine("Calculated string value: " + calculatedString);
                }
            }

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the input presentation, external workbook and output file
            string inputPresentationPath = "input.pptx";
            string externalWorkbookPath = "data.xlsx";
            string outputPresentationPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPresentationPath);

            // Get the first shape on the first slide and cast it to IChart
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Set the external workbook as the data source for the chart
                chart.ChartData.SetExternalWorkbook(externalWorkbookPath);

                // Example: change the first data point of the first series to a new literal value
                object newValue = 42; // can be any object that represents a numeric value
                chart.ChartData.Series[0].DataPoints[0].Value.Data = newValue;
            }

            // Save the modified presentation
            pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
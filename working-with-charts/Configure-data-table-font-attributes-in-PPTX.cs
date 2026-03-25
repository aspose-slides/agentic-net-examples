using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Add a chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Ensure the chart has a data table
                chart.HasDataTable = true;

                // Access the data table
                IDataTable dataTable = chart.ChartDataTable;

                // Configure font attributes for the data table
                IChartPortionFormat portionFormat = dataTable.TextFormat.PortionFormat;
                portionFormat.FontHeight = 12f;
                portionFormat.FontBold = NullableBool.True;
                portionFormat.FontItalic = NullableBool.False;
                portionFormat.FontUnderline = TextUnderlineType.None;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
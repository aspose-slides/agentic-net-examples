using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartTypeEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output PPTX file path
            string outputPath = "ChartTypes.pptx";

            // Delete existing file if it exists
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // Create a new presentation (required by lifecycle rules)
            Presentation presentation = new Presentation();

            // Enumerate all chart types supported by Aspose.Slides
            Array chartTypes = Enum.GetValues(typeof(ChartType));
            foreach (ChartType chartType in chartTypes)
            {
                Console.WriteLine(chartType.ToString());
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
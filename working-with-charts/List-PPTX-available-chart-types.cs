using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartTypesEnumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Get all chart type enum values
                var chartTypes = Enum.GetValues(typeof(ChartType));

                // Enumerate and display each chart type
                foreach (ChartType chartType in chartTypes)
                {
                    Console.WriteLine(chartType);
                }

                // Save the presentation before exiting
                presentation.Save("ChartTypes.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
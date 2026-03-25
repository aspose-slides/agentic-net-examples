using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartTypesEnumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Retrieve all chart types defined in the ChartType enumeration
            Array chartTypes = Enum.GetValues(typeof(Aspose.Slides.Charts.ChartType));

            Console.WriteLine("Available Chart Types in Aspose.Slides:");
            foreach (object chartTypeObj in chartTypes)
            {
                Aspose.Slides.Charts.ChartType chartType = (Aspose.Slides.Charts.ChartType)chartTypeObj;
                Console.WriteLine("- " + chartType.ToString());
            }

            // Save the presentation before exiting
            string outputPath = "ChartTypesEnumeration.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
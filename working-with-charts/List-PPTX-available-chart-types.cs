using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enumerate all chart types supported in PPTX
        foreach (Aspose.Slides.Charts.ChartType chartType in Enum.GetValues(typeof(Aspose.Slides.Charts.ChartType)))
        {
            Console.WriteLine(chartType.ToString());
        }

        // Save the presentation before exiting
        string outputPath = "ChartTypesEnumeration.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
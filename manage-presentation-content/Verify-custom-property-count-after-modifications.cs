using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        // Define output path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "TestPresentation.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access document properties
        Aspose.Slides.IDocumentProperties docProps = pres.DocumentProperties;

        // Add custom properties
        docProps.SetCustomPropertyValue("CustomProp1", "Value1");
        docProps.SetCustomPropertyValue("CustomProp2", 42);

        // Expected number of custom properties
        int expectedCount = 2;

        // Simple assertion
        if (docProps.CountOfCustomProperties != expectedCount)
        {
            throw new Exception($"Custom property count {docProps.CountOfCustomProperties} does not match expected {expectedCount}.");
        }

        // Save the presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
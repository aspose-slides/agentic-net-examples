using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the document properties collection
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Add custom properties
        documentProperties["CustomInt"] = 123;
        documentProperties["CustomString"] = "Hello World";
        documentProperties["AnotherInt"] = 456;

        // Get the name of the first custom property
        string firstPropertyName = documentProperties.GetCustomPropertyName(0);

        // Remove the first custom property
        documentProperties.RemoveCustomProperty(firstPropertyName);

        // Save the presentation in PPT format
        string outputPath = "CustomPropertiesPresentation.ppt";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
    }
}
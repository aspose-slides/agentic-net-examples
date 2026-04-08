using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Add custom property named ProjectId with integer value
        documentProperties["ProjectId"] = 12345;

        // Verify the custom property exists
        bool exists = documentProperties.ContainsCustomProperty("ProjectId");
        Console.WriteLine("ProjectId exists: " + exists);

        // Retrieve and display the value of the custom property
        object value = documentProperties["ProjectId"];
        Console.WriteLine("ProjectId value: " + value);

        // Save the presentation
        string outputPath = "CustomPropertyPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}
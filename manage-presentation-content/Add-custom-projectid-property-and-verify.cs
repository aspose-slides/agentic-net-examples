// -----------------------------------------------------------------------------
// Example: Add custom ProjectId property and verify using C#
//
// Description:
// Demonstrates how to add a custom ProjectId property to a PowerPoint presentation
// and verify its existence using C# and Aspose.Slides for .NET. The example shows
// the required presentation-processing steps for creating a presentation, adding
// a custom integer property, checking its presence, retrieving its value, and
// saving the file. This pattern can be used to automate PPTX workflows, validate
// custom metadata, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom, ProjectId, Property, 
// Verify, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a custom ProjectId property and verify it.
// - Build C# tools for PowerPoint presentation metadata management.
// - Generate or transform PPTX files with custom properties in .NET applications.
// - Validate presentation metadata before publishing or integration.
// -----------------------------------------------------------------------------

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

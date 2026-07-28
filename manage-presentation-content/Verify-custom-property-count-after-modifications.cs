// -----------------------------------------------------------------------------
// Example: Verify custom property count after modifications using C#
//
// Description:
// Demonstrates how to verify the number of custom document properties after
// adding them to a presentation using Aspose.Slides for .NET. The example
// creates a new PPTX file, adds custom properties, checks the property count,
// and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Custom, Property,
// Count, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verification of custom property count after modifications.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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

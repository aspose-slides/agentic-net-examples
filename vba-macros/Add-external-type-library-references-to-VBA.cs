// -----------------------------------------------------------------------------
// Example: Add external type library references to VBA using C#
//
// Description:
// Demonstrates how to add external type library references (Excel and Word) to a
// VBA project embedded in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example creates a new presentation, inserts a VBA module with sample code,
// adds OLE type library references, and saves the file as PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, VBA, Type Library, References, Excel, Word, Presentation Processing, Office Automation
//
// Use Cases:
// - Embed VBA macros with external Excel/Word references into PowerPoint files.
// - Automate creation of VBA-enabled presentations from .NET applications.
// - Generate PPTX files that require interaction with other Office applications.
// - Validate VBA project configuration before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Initialize VBA project
        presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

        // Add a VBA module
        Aspose.Slides.Vba.IVbaModule vbaModule = presentation.VbaProject.Modules.AddEmptyModule("Module1");
        vbaModule.SourceCode = "Sub HelloWorld()\n    MsgBox \"Hello World\"\nEnd Sub";

        // Create references to Excel and Word type libraries
        Aspose.Slides.Vba.VbaReferenceOleTypeLib excelRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Excel", "{00020813-0000-0000-C000-000000000046}");
        Aspose.Slides.Vba.VbaReferenceOleTypeLib wordRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Word", "{000209FF-0000-0000-C000-000000000046}");

        // Add references to the VBA project
        presentation.VbaProject.References.Add(excelRef);
        presentation.VbaProject.References.Add(wordRef);

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "VbaWithReferences.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

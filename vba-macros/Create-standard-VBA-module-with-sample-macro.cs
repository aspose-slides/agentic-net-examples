// -----------------------------------------------------------------------------
// Example: Create standard VBA module with sample macro using C#
//
// Description:
// Demonstrates how to create a standard VBA module containing a sample macro
// using C# and Aspose.Slides for .NET. The example builds a new presentation,
// adds a VBA project, inserts a module with macro code, adds required VBA
// references, and saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, VBA, Module, Macro, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of a VBA module with a sample macro in PowerPoint files.
// - Build .NET tools for adding VBA automation to presentations.
// - Generate or modify PPTX files programmatically with embedded macros.
// - Validate VBA integration before distributing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Define output file path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "MacroPresentation.pptx");
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Initialize VBA project
            presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

            // Add a new VBA module
            Aspose.Slides.Vba.IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("StandardModule");

            // Set sample macro code
            module.SourceCode = "Sub SampleMacro()\n    MsgBox \"Hello from VBA!\"\nEnd Sub";

            // Add standard references
            Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
            Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");

            presentation.VbaProject.References.Add(stdoleRef);
            presentation.VbaProject.References.Add(officeRef);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }
    }
}

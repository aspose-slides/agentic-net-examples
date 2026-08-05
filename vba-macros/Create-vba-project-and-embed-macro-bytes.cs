// -----------------------------------------------------------------------------
// Example: Create vba project and embed macro bytes using C#
//
// Description:
// Demonstrates how to create a VBA project, add VBA modules with source code,
// include required VBA references, and save the presentation as a macro‑enabled
// PPTM file using Aspose.Slides for .NET. The example shows the necessary
// presentation‑processing steps for PowerPoint files in a standalone console
// application.
//
// Keywords:
// C#, PowerPoint, PPTM, Aspose.Slides for .NET, VBA, Macro, Embed, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Automate creation of VBA projects and embedding of macro code in PPTM files.
// - Build C# utilities for PowerPoint presentation processing with macros.
// - Generate or transform macro‑enabled presentations in .NET applications.
// - Validate VBA macro integration before publishing or deployment.
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
        // Define output directory and file
        string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outPath = Path.Combine(outputDir, "MacroPresentation.pptm");

        // Create a new presentation
        Presentation pres = new Presentation();

        // Create a new VBA project
        pres.VbaProject = new VbaProject();

        // Add first VBA module
        IVbaModule module1 = pres.VbaProject.Modules.AddEmptyModule("Module1");
        module1.SourceCode = "Sub HelloWorld()\n    MsgBox \"Hello from Module1\"\nEnd Sub";

        // Add second VBA module
        IVbaModule module2 = pres.VbaProject.Modules.AddEmptyModule("Module2");
        module2.SourceCode = "Sub GoodbyeWorld()\n    MsgBox \"Goodbye from Module2\"\nEnd Sub";

        // Add references required for VBA macros
        VbaReferenceOleTypeLib stdoleRef = new VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
        VbaReferenceOleTypeLib officeRef = new VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");
        pres.VbaProject.References.Add(stdoleRef);
        pres.VbaProject.References.Add(officeRef);

        // Save the presentation with macros embedded
        try
        {
            pres.Save(outPath, SaveFormat.Pptm);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Dispose presentation resources
            pres.Dispose();
        }
    }
}

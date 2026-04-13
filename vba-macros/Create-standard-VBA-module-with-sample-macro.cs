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
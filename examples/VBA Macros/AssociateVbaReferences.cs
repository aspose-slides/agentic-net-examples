using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Initialize a new VBA project
        presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

        // Add an empty VBA module and set its source code
        Aspose.Slides.Vba.IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module1");
        module.SourceCode = "Sub HelloWorld()\n    MsgBox \"Hello, World!\"\nEnd Sub";

        // Create references to external type libraries
        Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "00020430-0000-0000-C000-000000000046");
        Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "000C0601-0000-0000-C000-000000000046");

        // Add the references to the VBA project
        presentation.VbaProject.References.Add(stdoleRef);
        presentation.VbaProject.References.Add(officeRef);

        // Save the presentation with VBA project and references
        presentation.Save("VbaPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Initialize VBA project
        presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

        // Add an empty VBA module
        Aspose.Slides.Vba.IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module1");
        module.SourceCode = "Sub AutoOpen()\n    MsgBox \"Hello\"\nEnd Sub";

        // Create references to stdole and Office type libraries
        Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "00020430-0000-0000-C000-000000000046");
        Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "000C0300-0000-0000-C000-000000000046");

        // Add references to the VBA project
        presentation.VbaProject.References.Add(stdoleRef);
        presentation.VbaProject.References.Add(officeRef);

        // Save the presentation
        presentation.Save("AddOfficeReferences.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
using System;

class Program
{
    static void Main()
    {
        // Path to save the presentation
        System.String outputPath = "output.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Initialize a new VBA project
        presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

        // Add an empty VBA module
        Aspose.Slides.Vba.IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module1");

        // Set the source code for the module
        module.SourceCode = "Sub Hello()\n    MsgBox \"Hello\"\nEnd Sub";

        // Create references to external type libraries
        Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
        Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");

        // Add the references to the VBA project
        presentation.VbaProject.References.Add(stdoleRef);
        presentation.VbaProject.References.Add(officeRef);

        // Save the presentation with the VBA project and references
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
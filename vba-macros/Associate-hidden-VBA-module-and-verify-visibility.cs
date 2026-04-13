using System;
using System.IO;
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

        // Add an empty VBA module named "HiddenModule"
        Aspose.Slides.Vba.IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("HiddenModule");

        // Set the source code for the module
        module.SourceCode = "Sub HiddenMacro()\n    MsgBox \"Hello from hidden macro\"\nEnd Sub";

        // Add standard VBA references (optional)
        Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
        Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");
        presentation.VbaProject.References.Add(stdoleRef);
        presentation.VbaProject.References.Add(officeRef);

        // Define output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "HiddenVbaModule.pptm");

        // Save the presentation as a macro-enabled PPTM file
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptm);
        }
        catch (Exception)
        {
            // Handle exception if the format is not supported
        }

        // Verify VBA project visibility (password protection flag)
        Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
        bool isPasswordProtected = vbaProject.IsPasswordProtected;
        Console.WriteLine("VBA Project password protected: " + isPasswordProtected);
    }
}
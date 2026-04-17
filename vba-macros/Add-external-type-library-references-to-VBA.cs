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
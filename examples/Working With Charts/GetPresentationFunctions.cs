using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "PredefinedFunctions.pptm");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Initialize VBA project
            presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

            // Add an empty VBA module named "Module1"
            Aspose.Slides.Vba.IVbaModule vbaModule = presentation.VbaProject.Modules.AddEmptyModule("Module1");

            // Set VBA source code for the module
            vbaModule.SourceCode = "Sub AutoOpen()\n    MsgBox \"Hello from VBA!\"\nEnd Sub";

            // Add references to standard OLE type libraries
            Aspose.Slides.Vba.VbaReferenceOleTypeLib stdOleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
            Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");

            // Register the references with the VBA project
            presentation.VbaProject.References.Add(stdOleRef);
            presentation.VbaProject.References.Add(officeRef);

            // Save the presentation (macro-enabled format)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptm);
        }
    }
}
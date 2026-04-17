using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace VbaMacroExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Initialize VBA project
            presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

            // Add first module with custom functions
            Aspose.Slides.Vba.IVbaModule module1 = presentation.VbaProject.Modules.AddEmptyModule("Module1");
            module1.SourceCode = "Function AddNumbers(a As Integer, b As Integer) As Integer\n" +
                                 "    AddNumbers = a + b\n" +
                                 "End Function";

            // Add second module that references the function from the first module
            Aspose.Slides.Vba.IVbaModule module2 = presentation.VbaProject.Modules.AddEmptyModule("Module2");
            module2.SourceCode = "Sub Test()\n" +
                                 "    Dim result As Integer\n" +
                                 "    result = AddNumbers(2, 3)\n" +
                                 "    MsgBox result\n" +
                                 "End Sub";

            // Add required VBA references
            Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
            Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");
            presentation.VbaProject.References.Add(stdoleRef);
            presentation.VbaProject.References.Add(officeRef);

            // Save the presentation
            presentation.Save("VbaPresentation.pptx", SaveFormat.Pptx);
        }
    }
}
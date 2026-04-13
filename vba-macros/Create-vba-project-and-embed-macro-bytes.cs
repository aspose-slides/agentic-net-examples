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
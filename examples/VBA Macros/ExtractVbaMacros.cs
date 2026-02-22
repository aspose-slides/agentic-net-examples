using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Path to the input presentation (must be macro-enabled, e.g., .pptm)
        string inputPath = "input.pptm";
        // Directory where extracted VBA modules will be saved
        string outputDir = "VbaModules";

        // Ensure the output directory exists
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get the VBA project from the presentation
            Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
            if (vbaProject != null)
            {
                // Iterate through all VBA modules
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                foreach (Aspose.Slides.Vba.IVbaModule module in modules)
                {
                    // Retrieve module name and source code
                    string moduleName = module.Name;
                    string sourceCode = module.SourceCode;

                    // Save the source code to a .bas file
                    string outPath = System.IO.Path.Combine(outputDir, moduleName + ".bas");
                    System.IO.File.WriteAllText(outPath, sourceCode);
                }
            }
        }
        finally
        {
            // Save the presentation (required by authoring rules)
            presentation.Save("output.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}
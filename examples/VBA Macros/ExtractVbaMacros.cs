using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input presentation containing VBA macros
        string inputPath = "input.pptm";

        // Directory where extracted VBA modules will be saved
        string outputDir = "ExtractedMacros";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get the VBA project from the presentation
            Aspose.Slides.Vba.IVbaProject vbaProject = pres.VbaProject;

            if (vbaProject != null)
            {
                // Iterate through all VBA modules
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                int moduleIndex = 0;
                foreach (Aspose.Slides.Vba.IVbaModule module in modules)
                {
                    // Retrieve module name and source code
                    string moduleName = module.Name;
                    string sourceCode = module.SourceCode;

                    // Create a file name for the module
                    string fileName = Path.Combine(outputDir, "Module_" + moduleIndex + "_" + moduleName + ".bas");

                    // Write the source code to the file
                    File.WriteAllText(fileName, sourceCode);
                    moduleIndex++;
                }
            }
        }
        finally
        {
            // Save the presentation before exiting (even if unchanged)
            pres.Save("output.pptm", SaveFormat.Pptm);
            pres.Dispose();
        }
    }
}
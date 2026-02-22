using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace ExtractVbaMacros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Directory to save extracted VBA modules
            string outputDir = "VbaModules";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the presentation
            Presentation pres = new Presentation(inputPath);
            try
            {
                // Get the VBA project from the presentation
                IVbaProject vbaProject = pres.VbaProject;
                if (vbaProject != null)
                {
                    // Get the collection of VBA modules
                    IVbaModuleCollection modules = vbaProject.Modules;
                    // Iterate through each module and save its source code
                    for (int i = 0; i < modules.Count; i++)
                    {
                        IVbaModule module = modules[i];
                        string sourceCode = module.SourceCode;
                        string moduleFileName = Path.Combine(outputDir, module.Name + ".bas");
                        File.WriteAllText(moduleFileName, sourceCode);
                    }
                }
            }
            finally
            {
                // Save the presentation before exiting
                pres.Save(inputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
        }
    }
}
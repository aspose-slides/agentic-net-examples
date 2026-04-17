using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Ensure the presentation contains a VBA project
            if (presentation.VbaProject == null)
            {
                Console.WriteLine("The presentation does not contain a VBA project.");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Define old and new module names
            string oldModuleName = "OldModule";
            string newModuleName = "NewModule";

            // Locate the module to rename
            Aspose.Slides.Vba.IVbaModule oldModule = null;
            Aspose.Slides.Vba.IVbaModuleCollection modules = presentation.VbaProject.Modules;
            for (int i = 0; i < modules.Count; i++)
            {
                Aspose.Slides.Vba.IVbaModule module = modules[i];
                if (module.Name.Equals(oldModuleName, StringComparison.OrdinalIgnoreCase))
                {
                    oldModule = module;
                    break;
                }
            }

            if (oldModule == null)
            {
                Console.WriteLine("Module '{0}' not found.", oldModuleName);
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Retrieve source code and replace internal references to the old module name
            string sourceCode = oldModule.SourceCode;
            string updatedSourceCode = sourceCode.Replace(oldModuleName, newModuleName, StringComparison.OrdinalIgnoreCase);

            // Add a new module with the desired name and set its source code
            Aspose.Slides.Vba.IVbaModule newModule = presentation.VbaProject.Modules.AddEmptyModule(newModuleName);
            newModule.SourceCode = updatedSourceCode;

            // Remove the old module from the collection
            presentation.VbaProject.Modules.Remove(oldModule);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
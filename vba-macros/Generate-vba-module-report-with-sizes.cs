using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VbaModuleReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path (same as input for saving)
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. " + ex.Message);
                return;
            }

            // Check if VBA project is present
            Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
            if (vbaProject == null)
            {
                Console.WriteLine("No VBA project found in the presentation.");
                presentation.Dispose();
                return;
            }

            // Iterate through VBA modules
            Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
            for (int i = 0; i < modules.Count; i++)
            {
                Aspose.Slides.Vba.IVbaModule module = modules[i];
                string moduleName = module.Name;
                string sourceCode = module.SourceCode ?? string.Empty;
                int sizeInBytes = Encoding.UTF8.GetByteCount(sourceCode);
                bool hasComment = sourceCode.Contains("'");

                Console.WriteLine("Module Name: " + moduleName);
                Console.WriteLine("Size (bytes): " + sizeInBytes);
                Console.WriteLine("Contains Comment: " + hasComment);
                Console.WriteLine("---------------------------");
            }

            // Save presentation before exit
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation. " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace DuplicateVbaModule
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

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure the presentation contains a VBA project with at least one module
                    if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                    {
                        // Get the first existing module
                        IVbaModule originalModule = presentation.VbaProject.Modules[0];

                        // Create a new empty module with a new name
                        string newModuleName = originalModule.Name + "_Copy";
                        IVbaModule duplicatedModule = presentation.VbaProject.Modules.AddEmptyModule(newModuleName);

                        // Copy the source code from the original module to the new module
                        duplicatedModule.SourceCode = originalModule.SourceCode;
                    }
                    else
                    {
                        Console.WriteLine("No VBA modules found in the presentation.");
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
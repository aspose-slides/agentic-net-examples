using System;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace ExtractVbaMacros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPTX file
            string inputPath = "input.pptx";

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access the VBA project
                    Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;

                    if (vbaProject != null && vbaProject.Modules != null && vbaProject.Modules.Count > 0)
                    {
                        // Iterate through all VBA modules and output their source code
                        for (int i = 0; i < vbaProject.Modules.Count; i++)
                        {
                            Aspose.Slides.Vba.IVbaModule module = vbaProject.Modules[i];
                            Console.WriteLine("Module Name: " + module.Name);
                            Console.WriteLine("Source Code:");
                            Console.WriteLine(module.SourceCode);
                            Console.WriteLine(new string('-', 40));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No VBA macros found in the presentation.");
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
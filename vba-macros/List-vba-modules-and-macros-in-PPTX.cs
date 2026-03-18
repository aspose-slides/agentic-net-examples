using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            using (Presentation presentation = new Presentation(inputPath))
            {
                IVbaProject vbaProject = presentation.VbaProject;
                if (vbaProject != null)
                {
                    IVbaModuleCollection modules = vbaProject.Modules;
                    foreach (IVbaModule module in modules)
                    {
                        Console.WriteLine("Module Name: " + module.Name);
                        Console.WriteLine("Source Code:");
                        Console.WriteLine(module.SourceCode);
                        Console.WriteLine(new string('-', 40));
                    }
                }
                else
                {
                    Console.WriteLine("No VBA project found in the presentation.");
                }

                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
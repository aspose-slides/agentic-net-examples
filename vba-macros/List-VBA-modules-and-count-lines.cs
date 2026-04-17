using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptm";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
            if (vbaProject != null)
            {
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                for (int i = 0; i < modules.Count; i++)
                {
                    Aspose.Slides.Vba.IVbaModule module = modules[i];
                    string moduleName = module.Name;
                    string sourceCode = module.SourceCode ?? string.Empty;
                    int lineCount = sourceCode.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None).Length;
                    Console.WriteLine("Module: " + moduleName + ", Lines: " + lineCount);
                }
            }
            else
            {
                Console.WriteLine("No VBA project found in the presentation.");
            }

            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
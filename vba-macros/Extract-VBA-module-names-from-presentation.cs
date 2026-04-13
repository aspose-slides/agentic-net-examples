using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace ExtractVbaModules
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "sample.pptm";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(filePath))
                {
                    IVbaProject vbaProject = presentation.VbaProject;
                    if (vbaProject != null)
                    {
                        IVbaModuleCollection modules = vbaProject.Modules;
                        foreach (IVbaModule module in modules)
                        {
                            Console.WriteLine("Module: " + module.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No VBA project found in the presentation.");
                    }

                    // Save the presentation before exiting
                    presentation.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
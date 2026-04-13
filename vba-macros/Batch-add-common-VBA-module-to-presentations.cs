using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        string folderPath = "InputPresentations";

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Folder does not exist: " + folderPath);
            return;
        }

        string[] files = Directory.GetFiles(folderPath);
        foreach (string filePath in files)
        {
            try
            {
                // Simple format check; skip unsupported extensions
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".pptx" && extension != ".ppt" && extension != ".pptm" && extension != ".odp")
                {
                    // format not supported
                    continue;
                }

                using (Presentation presentation = new Presentation(filePath))
                {
                    // Ensure a VBA project exists
                    if (presentation.VbaProject == null)
                    {
                        VbaProject vbaProject = new VbaProject();
                        presentation.VbaProject = vbaProject;
                    }

                    // Add a common VBA module (or retrieve if already exists)
                    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("CommonModule");
                    module.SourceCode = "Sub HelloWorld()\n    MsgBox \"Hello from common module\"\nEnd Sub";

                    // Save the modified presentation (overwrite original)
                    presentation.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }
    }
}
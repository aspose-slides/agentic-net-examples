// -----------------------------------------------------------------------------
// Example: Batch add common VBA module to presentations using C#
//
// Description:
// Demonstrates how to batch add a common VBA module to multiple PowerPoint
// presentations using C# and Aspose.Slides for .NET. The example iterates over
// files in a specified folder, ensures a VBA project exists, adds (or retrieves)
// a module named "CommonModule" containing a simple macro, and saves the
// presentations back to their original format.
//
// Keywords:
// C#, PowerPoint, PPTX, PPT, PPTM, ODP, Aspose.Slides for .NET, VBA, Macro,
// Batch processing, Presentation automation, Office Automation
//
// Use Cases:
// - Inject a shared VBA macro into many presentations automatically.
// - Automate macro addition for corporate PowerPoint templates.
// - Build .NET tools that embed VBA code into PPTX/PPT/PPTM/ODP files.
// - Prepare presentations with common functionality before distribution.
// -----------------------------------------------------------------------------
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

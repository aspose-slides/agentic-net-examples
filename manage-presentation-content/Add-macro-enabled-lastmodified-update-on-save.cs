using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace MacroEnabledPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path
            string dataDir = "Data";
            string outputPath = Path.Combine(dataDir, "MacroPresentation.pptm");

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add VBA project and a simple macro
                presentation.VbaProject = new VbaProject();
                Aspose.Slides.Vba.IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("AutoUpdate");
                module.SourceCode = "Sub Auto_Open()\n    MsgBox \"Presentation opened\"\nEnd Sub";

                // Save as macro‑enabled presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptm);
                presentation.Dispose();

                // Update LastSavedTime property using PresentationInfo
                Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(outputPath);
                Aspose.Slides.IDocumentProperties props = info.ReadDocumentProperties();
                props.LastSavedTime = DateTime.UtcNow;
                info.UpdateDocumentProperties(props);
                info.WriteBindedPresentation(outputPath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.FileName);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path for the macro-enabled presentation
        string outputPath = "MacroPresentation.pptm";

        // Delete the file if it already exists
        if (File.Exists(outputPath))
        {
            File.Delete(outputPath);
        }

        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Create an empty VBA project (you can pass macro bytes to the constructor if available)
                VbaProject vbaProject = new VbaProject();

                // Assign the VBA project to the presentation
                presentation.VbaProject = vbaProject;

                // Save the presentation as a macro-enabled PPTM file
                presentation.Save(outputPath, SaveFormat.Pptm);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // The requested format is not supported
            Console.WriteLine("The specified save format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
// -----------------------------------------------------------------------------
// Example: Load a PPTM presentation and retrieve its VBA project using C#
//
// Description:
// Demonstrates how to load a macro-enabled PowerPoint presentation (PPTM),
// access the embedded VBA project, check for password protection, and
// optionally output the project name. The example also shows how to save the
// presentation in PPTX format after processing. This pattern helps developers
// automate VBA inspection and conversion tasks with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTM, PPTX, Aspose.Slides for .NET, VBA, VbaProject, 
// Password Protection, Presentation Processing, Office Automation
//
// Use Cases:
// - Load a PPTM file and inspect its VBA project.
// - Detect if a VBA project is password protected.
// - Convert macro-enabled presentations to standard PPTX after analysis.
// - Integrate VBA project handling into .NET automation tools.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesVbaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string presentationPath = "input.pptm";

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(presentationPath);

                // Obtain the VBA project object
                Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;

                // Example usage: check if the VBA project is password protected
                if (vbaProject.IsPasswordProtected)
                {
                    Console.WriteLine("The VBA project is password protected.");
                }
                else
                {
                    Console.WriteLine("VBA Project Name: " + vbaProject.Name);
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

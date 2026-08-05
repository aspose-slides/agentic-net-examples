// -----------------------------------------------------------------------------
// Example: Check password protection before modifying VBA using C#
//
// Description:
// Demonstrates how to check whether a VBA project embedded in a PPTM file is
// password protected before attempting to read or modify its macros using
// Aspose.Slides for .NET. The example loads a presentation, inspects the VBA
// project protection flag, reports the status, and saves the file.
// This pattern helps developers safely automate VBA handling in PowerPoint
// automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTM, Aspose.Slides for .NET, VBA, Password, Protection, Check,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Verify VBA password protection before editing macros in a PPTM file.
// - Build .NET tools that process PowerPoint presentations with embedded VBA.
// - Prevent runtime errors when accessing protected VBA projects.
// - Automate safe transformation or analysis of macro-enabled presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationFileName = "demo.pptm";
            string presentationPath = Path.Combine(Directory.GetCurrentDirectory(), presentationFileName);

            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file does not exist: " + presentationPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);
                // Check if VBA project is password protected before accessing macros
                if (presentation.VbaProject != null && presentation.VbaProject.IsPasswordProtected)
                {
                    Console.WriteLine("The VBAProject is protected by a password.");
                }
                else
                {
                    Console.WriteLine("The VBAProject is not password protected.");
                    // Access or modify VBA macros here
                }

                // Save presentation before exit
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Clone VBA project and attach to presentation using C#
//
// Description:
// Demonstrates how to clone a VBA project from a source PowerPoint file and
// attach it to another presentation using C# and Aspose.Slides for .NET.
// The example loads two presentations, extracts the VBA project from the
// source, creates a new VBA project from its binary representation, and
// assigns it to the destination presentation before saving the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, VBA, Clone, Attach, 
// Presentation, Office Automation
//
// Use Cases:
// - Automate cloning of VBA macros between PowerPoint files.
// - Build .NET tools for PowerPoint presentation processing with VBA support.
// - Generate or transform PPTX files while preserving or reusing VBA code.
// - Validate and test VBA macro integration in automated workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace CloneVbaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";
            string outputPath = "output.pptx";

            // Verify that source and destination files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            if (!File.Exists(destinationPath))
            {
                Console.WriteLine("Destination file does not exist: " + destinationPath);
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation sourcePres = new Presentation(sourcePath))
                {
                    // Load destination presentation
                    using (Presentation destPres = new Presentation(destinationPath))
                    {
                        // Get VBA project from source presentation
                        IVbaProject sourceVba = sourcePres.VbaProject;

                        if (sourceVba != null)
                        {
                            // Export VBA project to binary representation
                            byte[] vbaBinary = sourceVba.ToBinary();

                            // Create a new VBA project from binary data
                            VbaProject newVba = new VbaProject(vbaBinary);

                            // Attach the cloned VBA project to the destination presentation
                            destPres.VbaProject = newVba;
                        }

                        // Save the destination presentation with the cloned VBA project
                        destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

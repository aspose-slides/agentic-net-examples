// -----------------------------------------------------------------------------
// Example: Clone multiple slide masters to target using C#
//
// Description:
// Demonstrates how to clone all slide masters from a source presentation into a
// new destination presentation using Aspose.Slides for .NET. The example also
// shows how to add a slide that uses one of the cloned masters. This pattern
// can be used to consolidate slide masters across presentations or to prepare
// a template with multiple masters for further editing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Multiple, Slide, Masters,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Transfer all slide masters from an existing PPTX to a new presentation.
// - Build tools that combine slide master libraries for template creation.
// - Automate preparation of presentations that require multiple master slides.
// - Enable downstream editing of cloned masters in .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for source template and destination presentation
        string sourcePath = "Template.pptx";
        string destinationPath = "ClonedMasters.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist: " + sourcePath);
            return;
        }

        try
        {
            // Load the source presentation
            using (Presentation srcPres = new Presentation(sourcePath))
            {
                // Create a new empty destination presentation
                using (Presentation destPres = new Presentation())
                {
                    // Clone all master slides from the source to the destination
                    for (int i = 0; i < srcPres.Masters.Count; i++)
                    {
                        IMasterSlide sourceMaster = srcPres.Masters[i];
                        destPres.Masters.AddClone(sourceMaster);
                    }

                    // Optionally clone a slide to demonstrate usage of the cloned masters
                    if (srcPres.Slides.Count > 0 && destPres.Masters.Count > 0)
                    {
                        ISlide sourceSlide = srcPres.Slides[0];
                        IMasterSlide destMaster = destPres.Masters[0];
                        destPres.Slides.AddClone(sourceSlide, destMaster, true);
                    }

                    // Save the destination presentation
                    destPres.Save(destinationPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

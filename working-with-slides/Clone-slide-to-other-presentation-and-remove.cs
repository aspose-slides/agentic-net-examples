// -----------------------------------------------------------------------------
// Example: Clone slide to other presentation and remove using C#
//
// Description:
// Demonstrates how to clone a slide (including its master) from a source 
// presentation to a new presentation and then remove the original slide from 
// the source using Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Other, 
// Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning a slide to another presentation and removing it from the source.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCloneAndRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string sourcePath = "source.pptx";
            string destinationPath = "cloned.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load source presentation
                Presentation srcPres = new Presentation(sourcePath);
                // Create destination presentation
                Presentation destPres = new Presentation();

                // Clone slide with its master to destination presentation
                ISlide sourceSlide = srcPres.Slides[0];
                IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);

                // Remove the original slide from source presentation
                ISlide firstSlide = srcPres.Slides[0];
                srcPres.Slides.Remove(firstSlide);

                // Save both presentations
                destPres.Save(destinationPath, SaveFormat.Pptx);
                srcPres.Save(sourcePath, SaveFormat.Pptx);

                // Dispose presentations
                srcPres.Dispose();
                destPres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
                // Comment: format not supported.
            }
        }
    }
}

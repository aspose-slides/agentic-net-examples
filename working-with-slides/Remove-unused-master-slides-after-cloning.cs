// -----------------------------------------------------------------------------
// Example: Remove unused master slides after cloning using C#
//
// Description:
// Demonstrates how to remove unused master slides after cloning using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Unused, Master, Slides, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate remove unused master slides after cloning.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePresentation = new Presentation(sourcePath))
                {
                    // Create a new empty destination presentation
                    using (Presentation destinationPresentation = new Presentation())
                    {
                        // Clone each slide from the source to the destination
                        ISlideCollection sourceSlides = sourcePresentation.Slides;
                        for (int i = 0; i < sourceSlides.Count; i++)
                        {
                            ISlide sourceSlide = sourceSlides[i];
                            // AddClone clones the slide and its master layout as needed
                            destinationPresentation.Slides.AddClone(sourceSlide);
                        }

                        // Remove unused master slides from the destination presentation
                        // ignorePreserveField set to true to remove masters even if Preserve is true
                        destinationPresentation.Masters.RemoveUnused(true);

                        // Save the destination presentation
                        destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Clone slide with animations to other presentation using C#
//
// Description:
// Demonstrates how to clone a slide, including its animations and master,
// from a source PowerPoint presentation to a new destination presentation
// using Aspose.Slides for .NET. The example loads the source file, copies the
// first slide with all associated animation sequences, removes the default
// empty slide created by the destination presentation, and saves the result
// as a new PPTX file. This pattern is useful for automating slide reuse and
// preserving animation effects across presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Animations, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of slides with animations to other presentations.
// - Build .NET tools for reusing animated content across multiple PPTX files.
// - Generate or transform PPTX files while preserving animation timelines.
// - Validate and test slide cloning workflows before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideWithAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for source and destination presentations
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePres = new Presentation(sourcePath))
                {
                    // Create a new destination presentation (contains one empty slide by default)
                    using (Presentation destPres = new Presentation())
                    {
                        // Get the first slide from the source presentation
                        ISlide sourceSlide = sourcePres.Slides[0];

                        // Clone the source slide into the destination presentation.
                        // AddClone copies the slide together with its animations and master.
                        ISlide clonedSlide = destPres.Slides.AddClone(sourceSlide);

                        // Optionally, remove the initially created empty slide if it exists
                        if (destPres.Slides.Count > 1 && destPres.Slides[0] != clonedSlide)
                        {
                            destPres.Slides.RemoveAt(0);
                        }

                        // Save the destination presentation
                        destPres.Save(destinationPath, SaveFormat.Pptx);
                    }
                }

                Console.WriteLine("Slide cloned successfully to: " + destinationPath);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format exceptions
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

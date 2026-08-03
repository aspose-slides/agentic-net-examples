// -----------------------------------------------------------------------------
// Example: Replace Ink shapes with a template shape on all slides using C#
//
// Description:
// Demonstrates how to locate Ink shapes in a presentation and replace each
// with a cloned Ink shape taken from a template presentation. The example
// uses Aspose.Slides for .NET to load the source and template PPTX files,
// iterate through all slides, remove existing Ink objects, and insert the
// template Ink shape. The resulting presentation is saved as a new PPTX file.
// This pattern can be used to standardize Ink annotations across a deck.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Ink shape, Template cloning, Slide
// processing, Presentation automation, Office document manipulation
//
// Use Cases:
// - Standardize Ink annotations by replacing them with a predefined template.
// - Automate bulk modification of Ink objects across multiple slides.
// - Build .NET utilities for PPTX content transformation.
// - Integrate Ink shape replacement into larger presentation processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace ReplaceInkShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string templatePath = "template.pptx";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(templatePath))
            {
                Console.WriteLine("Template file does not exist: " + templatePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePresentation = new Presentation(inputPath))
                {
                    // Load the template presentation containing the Ink shape to clone
                    using (Presentation templatePresentation = new Presentation(templatePath))
                    {
                        // Find the first Ink shape in the template presentation
                        Ink templateInk = null;
                        foreach (IShape shape in templatePresentation.Slides[0].Shapes)
                        {
                            if (shape is Ink)
                            {
                                templateInk = (Ink)shape;
                                break;
                            }
                        }

                        if (templateInk == null)
                        {
                            Console.WriteLine("No Ink shape found in the template presentation.");
                            return;
                        }

                        // Iterate through all slides in the source presentation
                        for (int slideIndex = 0; slideIndex < sourcePresentation.Slides.Count; slideIndex++)
                        {
                            ISlide slide = sourcePresentation.Slides[slideIndex];

                            // Iterate backwards to safely remove shapes while iterating
                            for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                            {
                                IShape shape = slide.Shapes[shapeIndex];

                                // Identify Ink shapes
                                if (shape is Ink)
                                {
                                    // Remove the existing Ink shape
                                    slide.Shapes.RemoveAt(shapeIndex);

                                    // Add a new Ink shape cloned from the template
                                    slide.Shapes.AddClone(templateInk);
                                }
                            }
                        }

                        // Save the modified presentation
                        sourcePresentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}

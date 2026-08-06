// -----------------------------------------------------------------------------
// Example: Toggle smartart shape hidden and save using C#
//
// Description:
// Demonstrates how to toggle the Hidden property of a SmartArt shape in a
// PowerPoint presentation and save the changes using Aspose.Slides for .NET.
// The example loads a PPTX file, finds the first SmartArt shape on the first
// slide, toggles its visibility, and writes the result to a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Toggle, SmartArt, Shape,
// Hidden, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate toggling SmartArt shape visibility in PPTX files.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Integrate SmartArt visibility control into .NET applications.
// - Validate and preprocess presentations before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ToggleSmartArtHidden
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the first slide using the ISlide interface (avoids CS0266)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Locate the first SmartArt shape on the slide
                    Aspose.Slides.IShape smartArtShape = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            smartArtShape = shape;
                            break;
                        }
                    }

                    if (smartArtShape != null)
                    {
                        // Toggle the Hidden property of the SmartArt shape
                        smartArtShape.Hidden = !smartArtShape.Hidden;
                    }
                    else
                    {
                        Console.WriteLine("No SmartArt shape found on the first slide.");
                    }

                    // Save the modified presentation (preserve visibility)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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

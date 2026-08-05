// -----------------------------------------------------------------------------
// Example: Load pptx select rectangle solid red using C#
//
// Description:
// Demonstrates how to load a PPTX file, select the first rectangle shape on the
// first slide, and apply a solid red fill using C# and Aspose.Slides for .NET.
// The example includes file existence checks, error handling, and saves the
// modified presentation as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Select, Rectangle, Solid Red,
// Fill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading a PPTX and applying a solid red fill to a rectangle shape.
// - Build C# utilities for PowerPoint shape formatting.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and test presentation styling workflows before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output PPTX file path
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Assume the first shape is a rectangle; cast to IShape
                    IShape shape = slide.Shapes[0];

                    // Apply solid red fill
                    shape.FillFormat.FillType = FillType.Solid;
                    shape.FillFormat.SolidFillColor.Color = Color.Red;

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
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

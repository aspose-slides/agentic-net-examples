// -----------------------------------------------------------------------------
// Example: Update group shape header fill to gray using C#
//
// Description:
// Demonstrates how to locate a group shape whose AlternativeText contains
// "Header" in a PowerPoint presentation and change its fill to solid gray
// using Aspose.Slides for .NET. The example loads an existing PPTX file,
// processes each slide and shape, updates the fill, and saves the result.
// This pattern can be used to programmatically modify grouped shape
// formatting in presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update, Group Shape, Header,
// Fill Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically apply a gray fill to header group shapes across slides.
// - Build .NET utilities for batch updating presentation styling.
// - Integrate shape formatting changes into CI pipelines for slide decks.
// - Ensure consistent visual appearance of grouped header elements.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation file
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    Aspose.Slides.ISlideCollection slides = presentation.Slides;
                    for (int slideIndex = 0; slideIndex < slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = slides[slideIndex];

                        // Iterate through all shapes on the slide
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = shapes[shapeIndex];

                            // Check if the shape is a group shape and its AlternativeText contains "Header"
                            if (shape is Aspose.Slides.IGroupShape && shape.AlternativeText != null && shape.AlternativeText.Contains("Header"))
                            {
                                Aspose.Slides.IGroupShape groupShape = (Aspose.Slides.IGroupShape)shape;

                                // Change the fill of the group shape to solid gray
                                if (groupShape.FillFormat != null)
                                {
                                    groupShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    groupShape.FillFormat.SolidFillColor.Color = Color.Gray;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format or I/O errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

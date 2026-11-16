// -----------------------------------------------------------------------------
// Example: Update Group Shape Header Fill to Gray Using C#
// 
// Description:
// Demonstrates how to locate a group shape whose AlternativeText contains
// "Header" in a PowerPoint presentation and change its fill to solid gray
// using Aspose.Slides for .NET. The program creates a sample presentation if
// the input file is missing, updates the fill, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update Group Shape Fill, Header, Gray Fill
// 
// Use Cases:
// - Automatically apply a gray fill to header group shapes across slides.
// - Build .NET utilities for batch updating presentation styling.
// - Ensure consistent visual appearance of grouped header elements.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Ensure input file exists; create a sample if it does not.
        if (!File.Exists(inputPath))
        {
            try
            {
                using (Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = samplePresentation.Slides[0];

                    // Create a group shape with AlternativeText "Header"
                    Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();
                    groupShape.AlternativeText = "Header";
                    groupShape.Frame = new Aspose.Slides.ShapeFrame(50f, 50f, 400f, 200f, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0f);

                    // Add a rectangle inside the group shape
                    Aspose.Slides.IAutoShape innerShape = (Aspose.Slides.IAutoShape)groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0f, 0f, 200f, 100f);
                    innerShape.TextFrame.Text = "Sample Header";

                    // Save the sample presentation
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        // Verify that the input file now exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            Environment.Exit(1);
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlideCollection slides = presentation.Slides;
                for (int slideIndex = 0; slideIndex < slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];
                        if (shape is Aspose.Slides.IGroupShape && shape.AlternativeText != null && shape.AlternativeText.Contains("Header"))
                        {
                            Aspose.Slides.IGroupShape groupShape = (Aspose.Slides.IGroupShape)shape;
                            if (groupShape.FillFormat != null)
                            {
                                groupShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                groupShape.FillFormat.SolidFillColor.Color = Color.Gray;
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation processed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}

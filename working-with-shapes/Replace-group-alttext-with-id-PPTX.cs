// -----------------------------------------------------------------------------
// Example: Replace Group Shape Alternative Text with Unique IDs in PPTX
//
// Description:
// This console program loads a PPTX file, iterates through all slides and
// group shapes, and replaces each group's AlternativeText with a newly
// generated GUID. It creates a sample presentation if the input file is missing
// and saves the modified file as output.pptx.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Group Shape Alt Text, Unique ID
//
// Use Cases:
// - Standardize group shape metadata across presentation files.
// - Prepare PPTX files for accessibility by assigning unique identifiers.
// - Integrate into CI pipelines to enforce naming conventions on shapes.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ReplaceGroupShapeAltText
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; create a sample if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                    Aspose.Slides.IGroupShape sampleGroup = sampleSlide.Shapes.AddGroupShape(null, 50f, 50f, 400f, 300f);
                    sampleGroup.AlternativeText = "OriginalAlt";
                    sampleGroup.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0f, 0f, 100f, 50f);
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                    Console.WriteLine("Sample input file created: " + inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                Environment.Exit(1);
            }

            try
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    ProcessShapesInCollection(slide.Shapes);
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing presentation: " + ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }

        private static void ProcessShapesInCollection(Aspose.Slides.IShapeCollection shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = shapes[i];
                if (shape is Aspose.Slides.IGroupShape)
                {
                    Aspose.Slides.IGroupShape groupShape = (Aspose.Slides.IGroupShape)shape;
                    string newAltText = Guid.NewGuid().ToString();
                    groupShape.AlternativeText = newAltText;
                    // Recursively process nested shapes within the group
                    ProcessShapesInCollection(groupShape.Shapes);
                }
            }
        }
    }
}

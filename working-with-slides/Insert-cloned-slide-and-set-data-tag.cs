// -----------------------------------------------------------------------------
// Example: Clone First Slide and Add Custom Document Property
//
// Description:
// Demonstrates how to clone the first slide of a PowerPoint PPTX file, insert the
// cloned slide at the end of the presentation, and assign a custom document
// property to identify the cloned slide using Aspose.Slides for .NET.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Custom Document Property
//
// Use Cases:
// - Automate cloning of a slide and tracking it via a custom property.
// - Build .NET tools for PowerPoint slide manipulation.
// - Generate or transform PPTX files while preserving metadata.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace InsertCloneSlideExample
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = "source.pptx";
            string outputPath = "result.pptx";

            // Ensure input file exists; create a simple one if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    using (Aspose.Slides.Presentation creationPres = new Aspose.Slides.Presentation())
                    {
                        Aspose.Slides.ISlideCollection creationSlides = creationPres.Slides;
                        Aspose.Slides.ILayoutSlide layout = creationPres.LayoutSlides[0];
                        Aspose.Slides.ISlide newSlide = creationSlides.AddEmptySlide(layout);

                        Aspose.Slides.IShape shape = newSlide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                        autoShape.TextFrame.Text = "Sample Slide";

                        creationPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    return 1;
                }
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlideCollection slides = presentation.Slides;

                    if (slides.Count == 0)
                    {
                        Console.WriteLine("The presentation contains no slides to clone.");
                        return 1;
                    }

                    Aspose.Slides.ISlide clonedSlide = slides.InsertClone(slides.Count, slides[0]);

                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
                    docProps.SetCustomPropertyValue("ClonedSlideId", clonedSlide.SlideId);

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }

            Console.WriteLine("Presentation processed successfully. Output saved to: " + outputPath);
            return 0;
        }
    }
}

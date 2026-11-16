// -----------------------------------------------------------------------------
// Example: Compare Matching Slides and Create Side‑by‑Side Comparison Images
//
// Description:
// Demonstrates how to load two PPTX presentations, identify slides with identical
// content, render each matching slide as an image, and assemble side‑by‑side
// comparison slides into a new presentation using Aspose.Slides for .NET.
// The program creates sample input files if they are missing and saves the
// comparison result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide comparison, image generation, side‑by‑side
//
// Use Cases:
// - Detect duplicate or unchanged slides across different versions of a presentation.
// - Produce visual comparison reports for review or QA.
// - Automate creation of comparison decks for stakeholder presentations.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace CompareSlides
{
    class Program
    {
        static int Main(string[] args)
        {
            string presentationPath1 = "Presentation1.pptx";
            string presentationPath2 = "Presentation2.pptx";
            string outputPath = "ComparisonSlides.pptx";

            try
            {
                // Ensure input files exist; create simple samples if they do not.
                if (!File.Exists(presentationPath1))
                {
                    CreateSamplePresentation(presentationPath1, "Sample Slide 1");
                }

                if (!File.Exists(presentationPath2))
                {
                    CreateSamplePresentation(presentationPath2, "Sample Slide 1");
                }

                // Load the two source presentations and create a result presentation.
                using (Aspose.Slides.Presentation pres1 = new Aspose.Slides.Presentation(presentationPath1))
                using (Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(presentationPath2))
                using (Aspose.Slides.Presentation resultPres = new Aspose.Slides.Presentation())
                {
                    // Iterate through slides of both presentations and find matching slides.
                    for (int i = 0; i < pres1.Slides.Count; i++)
                    {
                        for (int j = 0; j < pres2.Slides.Count; j++)
                        {
                            if (SlidesAreSimilar(pres1.Slides[i], pres2.Slides[j]))
                            {
                                // Render matching slides to images.
                                using (Aspose.Slides.IImage image1 = pres1.Slides[i].GetImage())
                                using (Aspose.Slides.IImage image2 = pres2.Slides[j].GetImage())
                                {
                                    // Add images to the result presentation's image collection.
                                    Aspose.Slides.IPPImage imgRef1 = resultPres.Images.AddImage(image1);
                                    Aspose.Slides.IPPImage imgRef2 = resultPres.Images.AddImage(image2);

                                    // Create a blank slide for side‑by‑side comparison.
                                    Aspose.Slides.ISlide blankSlide = resultPres.Slides.AddEmptySlide(
                                        resultPres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));

                                    // Add first picture frame on the left.
                                    Aspose.Slides.IPictureFrame pictureFrame1 = blankSlide.Shapes.AddPictureFrame(
                                        Aspose.Slides.ShapeType.Rectangle,
                                        0,
                                        0,
                                        imgRef1.Width,
                                        imgRef1.Height,
                                        imgRef1);

                                    // Add second picture frame on the right with a small gap.
                                    float gap = 10;
                                    Aspose.Slides.IPictureFrame pictureFrame2 = blankSlide.Shapes.AddPictureFrame(
                                        Aspose.Slides.ShapeType.Rectangle,
                                        imgRef1.Width + gap,
                                        0,
                                        imgRef2.Width,
                                        imgRef2.Height,
                                        imgRef2);

                                    // Optional: add a thin border around the right image.
                                    pictureFrame2.LineFormat.Width = 1;
                                    pictureFrame2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    pictureFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                                }
                            }
                        }
                    }

                    // Save the result presentation.
                    resultPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Comparison presentation created successfully: " + outputPath);
                return 0;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("One of the input files has an unsupported format.");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }
        }

        // Creates a simple presentation with a single slide containing the specified text.
        private static void CreateSamplePresentation(string filePath, string slideText)
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100,
                    100,
                    400,
                    100);
                shape.AddTextFrame(slideText);
                pres.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        // Determines whether two slides have similar content based on shape count and text of the first AutoShape.
        private static bool SlidesAreSimilar(Aspose.Slides.ISlide slide1, Aspose.Slides.ISlide slide2)
        {
            if (slide1.Shapes.Count != slide2.Shapes.Count)
                return false;

            Aspose.Slides.IShape shape1 = slide1.Shapes[0];
            Aspose.Slides.IShape shape2 = slide2.Shapes[0];

            Aspose.Slides.IAutoShape autoShape1 = shape1 as Aspose.Slides.IAutoShape;
            Aspose.Slides.IAutoShape autoShape2 = shape2 as Aspose.Slides.IAutoShape;

            if (autoShape1 == null || autoShape2 == null)
                return false;

            string text1 = autoShape1.TextFrame?.Text ?? string.Empty;
            string text2 = autoShape2.TextFrame?.Text ?? string.Empty;

            return string.Equals(text1, text2, StringComparison.Ordinal);
        }
    }
}

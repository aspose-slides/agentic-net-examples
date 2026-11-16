// -----------------------------------------------------------------------------
// Example: Log Group Shape Member Count Exceeding Five in PowerPoint
//
// Description:
// This console program loads a PPTX file, iterates through its slides and group
// shapes, counts the shapes inside each group, and logs groups that contain more
// than five members. It creates a sample presentation if none exists, analyzes
// it, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GroupShape, Shape Count, Presentation Analysis
//
// Use Cases:
// - Identify complex group shapes for optimization.
// - Generate logs for presentation quality checks.
// - Automate reporting of group shape statistics in .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SlideGroupAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IGroupShape sampleGroup = sampleSlide.Shapes.AddGroupShape();
                    sampleGroup.Frame = new Aspose.Slides.ShapeFrame(50f, 50f, 400f, 300f, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0f);
                    for (int i = 0; i < 6; i++)
                    {
                        sampleGroup.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 10f + i * 60f, 10f, 50f, 50f);
                    }
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IGroupShape groupShape)
                        {
                            int memberCount = groupShape.Shapes.Count;
                            if (memberCount > 5)
                            {
                                Console.WriteLine("Slide " + slide.SlideNumber + ": Group shape with " + memberCount + " members.");
                            }
                        }
                    }
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}

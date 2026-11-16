// -----------------------------------------------------------------------------
// Example: Reorder Slides Alphabetically by Title Using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, extracts slide titles,
// sorts the slides alphabetically, and reorders them accordingly. If the input
// file does not exist, a sample presentation with titled slides is created.
// The reordered presentation is saved as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reorder Slides, Alphabetical Title
//
// Use Cases:
// - Automate slide ordering before publishing a deck.
// - Integrate slide sorting into a .NET presentation processing pipeline.
// - Generate consistently ordered presentations from dynamic content.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace SlideReorderAlphabetical
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    string[] titles = new string[] { "Beta", "Alpha", "Gamma" };
                    foreach (string t in titles)
                    {
                        Aspose.Slides.ISlide slide = samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                        Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 500f, 50f);
                        titleShape.AddTextFrame(t);
                    }
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Collect slide titles with corresponding slide objects
                List<System.Tuple<string, Aspose.Slides.ISlide>> slideInfo = new List<System.Tuple<string, Aspose.Slides.ISlide>>();
                int slideCount = pres.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    string title = string.Empty;

                    // Find the first AutoShape with a TextFrame as the title
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            title = autoShape.TextFrame.Text;
                            break;
                        }
                    }

                    slideInfo.Add(new System.Tuple<string, Aspose.Slides.ISlide>(title, slide));
                }

                // Sort slides alphabetically by title
                slideInfo.Sort((a, b) => string.Compare(a.Item1, b.Item1, System.StringComparison.Ordinal));

                // Reorder slides according to sorted order
                for (int targetIndex = 0; targetIndex < slideInfo.Count; targetIndex++)
                {
                    Aspose.Slides.ISlide targetSlide = slideInfo[targetIndex].Item2;
                    int currentIndex = pres.Slides.IndexOf(targetSlide);
                    if (currentIndex != targetIndex)
                    {
                        pres.Slides.Reorder(targetIndex, targetSlide);
                    }
                }

                // Save the reordered presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation reordered and saved to: " + outputPath);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }
        }
    }
}

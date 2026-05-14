using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideReorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Collect slides with their titles
                List<Tuple<string, ISlide>> slideInfo = new List<Tuple<string, ISlide>>();
                int slideCount = pres.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = pres.Slides[i];
                    string title = string.Empty;

                    // Attempt to get title from the first AutoShape (commonly the title placeholder)
                    if (slide.Shapes.Count > 0)
                    {
                        IAutoShape autoShape = slide.Shapes[0] as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            title = autoShape.TextFrame.Text;
                        }
                    }

                    slideInfo.Add(new Tuple<string, ISlide>(title, slide));
                }

                // Sort slides alphabetically by title
                slideInfo.Sort((a, b) => string.Compare(a.Item1, b.Item1, StringComparison.Ordinal));

                // Reorder slides in the presentation according to sorted order
                for (int targetIndex = 0; targetIndex < slideInfo.Count; targetIndex++)
                {
                    ISlide targetSlide = slideInfo[targetIndex].Item2;
                    int currentIndex = pres.Slides.IndexOf(targetSlide);
                    if (currentIndex != targetIndex)
                    {
                        pres.Slides.Reorder(targetIndex, targetSlide);
                    }
                }

                // Save the reordered presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation reordered and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
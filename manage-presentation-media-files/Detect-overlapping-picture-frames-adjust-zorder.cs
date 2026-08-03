// -----------------------------------------------------------------------------
// Example: Detect overlapping picture frames adjust zorder using C#
//
// Description:
// Demonstrates how to detect overlapping picture frames and adjust their Z-order
// using Aspose.Slides for .NET. The example loads a PPTX file, finds picture
// frames that intersect, determines the larger picture as primary, and moves it
// to the front of the slide's shape stack. The modified presentation is saved
// as a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect Overlap, Picture Frames,
// Z-Order, Presentation Processing, Office Automation
//
// Use Cases:
// - Identify and resolve overlapping images in a PowerPoint slide.
// - Automatically bring larger images to the front in generated presentations.
// - Build tools that clean up slide layouts before publishing.
// - Integrate overlap detection into .NET PowerPoint automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OverlapZOrderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and input/output files
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    IShapeCollection shapes = slide.Shapes;

                    // Collect all picture frames on the slide
                    List<IPictureFrame> pictureFrames = new List<IPictureFrame>();
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        IShape shape = shapes[i];
                        if (shape is IPictureFrame)
                        {
                            pictureFrames.Add((IPictureFrame)shape);
                        }
                    }

                    // Detect overlapping picture frames and adjust Z-order
                    for (int i = 0; i < pictureFrames.Count; i++)
                    {
                        IPictureFrame pf1 = pictureFrames[i];
                        for (int j = i + 1; j < pictureFrames.Count; j++)
                        {
                            IPictureFrame pf2 = pictureFrames[j];

                            // Simple rectangle overlap check
                            bool overlapX = pf1.X < pf2.X + pf2.Width && pf1.X + pf1.Width > pf2.X;
                            bool overlapY = pf1.Y < pf2.Y + pf2.Height && pf1.Y + pf1.Height > pf2.Y;

                            if (overlapX && overlapY)
                            {
                                // Determine primary picture frame (larger area)
                                float area1 = pf1.Width * pf1.Height;
                                float area2 = pf2.Width * pf2.Height;

                                IPictureFrame primary = area1 >= area2 ? pf1 : pf2;

                                // Bring primary picture frame to front (highest Z-order)
                                shapes.Reorder(shapes.Count - 1, primary);
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment: // Format not supported
            }
        }
    }
}

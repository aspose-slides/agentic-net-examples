using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            Presentation presentation = null;

            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading presentation: " + ex.Message);
                    presentation = new Presentation();
                }
            }
            else
            {
                presentation = new Presentation();
            }

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Find an existing SmartArt shape
            ISmartArt originalSmartArt = null;
            foreach (IShape shape in slide.Shapes)
            {
                originalSmartArt = shape as Aspose.Slides.SmartArt.SmartArt;
                if (originalSmartArt != null)
                {
                    break;
                }
            }

            // If no SmartArt found, add one
            if (originalSmartArt == null)
            {
                originalSmartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
            }

            // Clone the SmartArt shape and position it at (250,150)
            IShape clonedShape = slide.Shapes.AddClone(originalSmartArt, 250, 150);

            // Ensure the cloned shape does not intersect other shapes
            bool intersect;
            do
            {
                intersect = false;
                foreach (IShape otherShape in slide.Shapes)
                {
                    if (otherShape == clonedShape)
                        continue;

                    if (ShapesIntersect(clonedShape, otherShape))
                    {
                        // Move the cloned shape 10 points to the right and check again
                        clonedShape.X = clonedShape.X + 10;
                        intersect = true;
                        break;
                    }
                }
            } while (intersect);

            // Save the presentation
            try
            {
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                presentation.Dispose();
            }
        }

        // Helper method to determine if two shapes intersect
        private static bool ShapesIntersect(IShape a, IShape b)
        {
            float aLeft = a.X;
            float aTop = a.Y;
            float aRight = a.X + a.Width;
            float aBottom = a.Y + a.Height;

            float bLeft = b.X;
            float bTop = b.Y;
            float bRight = b.X + b.Width;
            float bBottom = b.Y + b.Height;

            bool horizontalOverlap = aLeft < bRight && aRight > bLeft;
            bool verticalOverlap = aTop < bBottom && aBottom > bTop;

            return horizontalOverlap && verticalOverlap;
        }
    }
}
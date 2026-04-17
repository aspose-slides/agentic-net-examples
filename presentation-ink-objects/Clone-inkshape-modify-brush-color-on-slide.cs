using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace AsposeSlidesInkClone
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the source file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Source file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Ensure there is at least one slide
                    if (pres.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                        return;
                    }

                    // Get the first slide (source slide)
                    ISlide sourceSlide = pres.Slides[0];

                    // Find the first Ink shape on the source slide
                    Ink sourceInk = null;
                    foreach (IShape shape in sourceSlide.Shapes)
                    {
                        sourceInk = shape as Ink;
                        if (sourceInk != null)
                            break;
                    }

                    if (sourceInk == null)
                    {
                        Console.WriteLine("No Ink shape found on the first slide.");
                        return;
                    }

                    // Clone the source slide and insert it after the original slide
                    ISlide clonedSlide = pres.Slides.InsertClone(1, sourceSlide);

                    // Find the corresponding Ink shape on the cloned slide
                    Ink clonedInk = null;
                    foreach (IShape shape in clonedSlide.Shapes)
                    {
                        clonedInk = shape as Ink;
                        if (clonedInk != null)
                            break;
                    }

                    if (clonedInk == null)
                    {
                        Console.WriteLine("Cloned slide does not contain an Ink shape.");
                        return;
                    }

                    // Modify the brush color of the first trace in the cloned Ink shape
                    if (clonedInk.Traces != null && clonedInk.Traces.Length > 0)
                    {
                        IInkBrush brush = clonedInk.Traces[0].Brush;
                        brush.Color = System.Drawing.Color.Red;
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace CopyInkTraces
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "source.pptx";
            string targetPath = "target.pptx";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }
            if (!File.Exists(targetPath))
            {
                Console.WriteLine("Target file does not exist: " + targetPath);
                return;
            }

            try
            {
                // Load presentations
                using (Presentation sourcePres = new Presentation(sourcePath))
                using (Presentation targetPres = new Presentation(targetPath))
                {
                    // Assume first slide and first shape are Ink shapes
                    IInk sourceInk = sourcePres.Slides[0].Shapes[0] as IInk;
                    IInk targetInk = targetPres.Slides[0].Shapes[0] as IInk;

                    if (sourceInk == null || targetInk == null)
                    {
                        Console.WriteLine("Ink shapes not found on the expected slides.");
                        return;
                    }

                    IInkTrace[] sourceTraces = sourceInk.Traces;
                    IInkTrace[] targetTraces = targetInk.Traces;

                    // Copy brush settings from source to target for matching trace indices
                    int count = Math.Min(sourceTraces.Length, targetTraces.Length);
                    for (int i = 0; i < count; i++)
                    {
                        IInkBrush sourceBrush = sourceTraces[i].Brush;
                        IInkBrush targetBrush = targetTraces[i].Brush;

                        // Preserve color and size
                        targetBrush.Color = sourceBrush.Color;
                        targetBrush.Size = sourceBrush.Size;
                        // InkEffect is read‑only; it is preserved automatically
                    }

                    // Save the modified target presentation
                    targetPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The provided file format is not supported (PPT).");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The provided file format is not supported (PPTX).");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
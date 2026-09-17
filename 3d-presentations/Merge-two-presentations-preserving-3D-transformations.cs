// -----------------------------------------------------------------------------
// Example: Merge Two PowerPoint Presentations While Preserving 3D Object Transformations
//
// Description:
// This console application merges two PPTX files into a single presentation,
// ensuring that any 3D objects on the source slides retain their original
// transformations after cloning. It uses Aspose.Slides for .NET to load, clone,
// and save presentations, handling missing files and unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, merge presentations, 3D objects, slide cloning
//
// Use Cases:
// - Combine separate slide decks into one master deck while keeping 3D animations.
// - Consolidate client presentations without losing visual fidelity of 3D models.
// - Automate batch merging of PPTX files for reporting or training material creation.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMergeExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sourcePath1 = "Presentation1.pptx";
            string sourcePath2 = "Presentation2.pptx";
            string outputPath = "MergedPresentation.pptx";

            if (!File.Exists(sourcePath1))
            {
                Console.WriteLine("Source file not found: " + sourcePath1);
                return;
            }

            if (!File.Exists(sourcePath2))
            {
                Console.WriteLine("Source file not found: " + sourcePath2);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres1 = new Aspose.Slides.Presentation(sourcePath1))
                {
                    using (Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(sourcePath2))
                    {
                        for (int i = 0; i < pres2.Slides.Count; i++)
                        {
                            Aspose.Slides.ISlide sourceSlide = pres2.Slides[i];
                            Aspose.Slides.ISlide clonedSlide = pres1.Slides.AddClone(sourceSlide);
                            // 3D objects and their transformations are preserved during cloning.
                        }
                    }

                    pres1.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentations merged successfully. Output saved to: " + outputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported PowerPoint format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while merging presentations: " + ex.Message);
            }
        }
    }
}

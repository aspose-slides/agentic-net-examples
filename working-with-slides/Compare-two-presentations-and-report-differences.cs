using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ComparePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file paths
            string firstPresentationPath = "presentation1.pptx";
            string secondPresentationPath = "presentation2.pptx";

            // Verify that both files exist
            if (!File.Exists(firstPresentationPath))
            {
                Console.WriteLine("File not found: " + firstPresentationPath);
                return;
            }

            if (!File.Exists(secondPresentationPath))
            {
                Console.WriteLine("File not found: " + secondPresentationPath);
                return;
            }

            try
            {
                // Load both presentations
                using (Aspose.Slides.Presentation firstPresentation = new Aspose.Slides.Presentation(firstPresentationPath))
                using (Aspose.Slides.Presentation secondPresentation = new Aspose.Slides.Presentation(secondPresentationPath))
                {
                    int slideCount = Math.Min(firstPresentation.Slides.Count, secondPresentation.Slides.Count);

                    // Compare slides one by one
                    for (int index = 0; index < slideCount; index++)
                    {
                        Aspose.Slides.ISlide firstSlide = firstPresentation.Slides[index];
                        Aspose.Slides.ISlide secondSlide = secondPresentation.Slides[index];

                        // Use BaseSlide.Equals to determine if slides are identical in static content
                        bool slidesAreEqual = ((Aspose.Slides.IBaseSlide)firstSlide).Equals((Aspose.Slides.IBaseSlide)secondSlide);

                        if (!slidesAreEqual)
                        {
                            Console.WriteLine($"Slide {index + 1} differs between the two presentations.");
                        }
                    }

                    // Report if the number of slides differs
                    if (firstPresentation.Slides.Count != secondPresentation.Slides.Count)
                    {
                        Console.WriteLine("The presentations contain a different number of slides.");
                    }

                    // Save a copy of the first presentation as a result file (required by lifecycle rule)
                    firstPresentation.Save("ComparisonResult.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported PPTX format
            catch (Aspose.Slides.PptxUnsupportedFormatException pptxEx)
            {
                Console.WriteLine("Unsupported PPTX format: " + pptxEx.Message);
            }
            // Handle unsupported PPT format
            catch (Aspose.Slides.PptUnsupportedFormatException pptEx)
            {
                Console.WriteLine("Unsupported PPT format: " + pptEx.Message);
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
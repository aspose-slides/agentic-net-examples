using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source presentations
            string sourcePath1 = "Presentation1.pptx";
            string sourcePath2 = "Presentation2.pptx";

            // Load both presentations
            using (Aspose.Slides.Presentation presentation1 = new Aspose.Slides.Presentation(sourcePath1))
            using (Aspose.Slides.Presentation presentation2 = new Aspose.Slides.Presentation(sourcePath2))
            {
                // Determine slide counts
                int slideCount1 = presentation1.Slides.Count;
                int slideCount2 = presentation2.Slides.Count;
                int minCount = Math.Min(slideCount1, slideCount2);

                // Compare slides one by one
                for (int i = 0; i < minCount; i++)
                {
                    Aspose.Slides.ISlide slide1 = presentation1.Slides[i];
                    Aspose.Slides.ISlide slide2 = presentation2.Slides[i];

                    // Use BaseSlide.Equals to check structural equality
                    bool areEqual = slide1.Equals(slide2);
                    if (areEqual)
                    {
                        Console.WriteLine($"Slide {i + 1}: Identical.");
                    }
                    else
                    {
                        Console.WriteLine($"Slide {i + 1}: Different.");

                        // Generate thumbnails for visual inspection
                        using (Aspose.Slides.IImage image1 = slide1.GetImage(1f, 1f))
                        {
                            image1.Save($"Slide_{i + 1}_Pres1.png", Aspose.Slides.ImageFormat.Png);
                        }
                        using (Aspose.Slides.IImage image2 = slide2.GetImage(1f, 1f))
                        {
                            image2.Save($"Slide_{i + 1}_Pres2.png", Aspose.Slides.ImageFormat.Png);
                        }
                    }
                }

                // Report extra slides, if any
                if (slideCount1 > slideCount2)
                {
                    Console.WriteLine($"Presentation1 has {slideCount1 - slideCount2} extra slide(s) starting from index {minCount + 1}.");
                }
                else if (slideCount2 > slideCount1)
                {
                    Console.WriteLine($"Presentation2 has {slideCount2 - slideCount1} extra slide(s) starting from index {minCount + 1}.");
                }

                // Save copies of the presentations before exiting
                presentation1.Save("Presentation1_Copy.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation2.Save("Presentation2_Copy.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
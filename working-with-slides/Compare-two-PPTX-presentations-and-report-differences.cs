using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file paths
            string filePath1 = "Presentation1.pptx";
            string filePath2 = "Presentation2.pptx";

            // Verify that both files exist
            if (!File.Exists(filePath1))
            {
                Console.WriteLine("File not found: " + filePath1);
                return;
            }

            if (!File.Exists(filePath2))
            {
                Console.WriteLine("File not found: " + filePath2);
                return;
            }

            try
            {
                // Load presentations
                using (Presentation pres1 = new Presentation(filePath1))
                using (Presentation pres2 = new Presentation(filePath2))
                {
                    int slideCount1 = pres1.Slides.Count;
                    int slideCount2 = pres2.Slides.Count;
                    int minCount = Math.Min(slideCount1, slideCount2);

                    // Compare slides one by one
                    for (int i = 0; i < minCount; i++)
                    {
                        bool areEqual = pres1.Slides[i].Equals(pres2.Slides[i]);
                        if (!areEqual)
                        {
                            Console.WriteLine($"Slide {i + 1} differs between the two presentations.");
                        }
                    }

                    // Report extra slides in either presentation
                    if (slideCount1 > slideCount2)
                    {
                        Console.WriteLine($"Presentation1 has {slideCount1 - slideCount2} extra slide(s) starting from slide {slideCount2 + 1}.");
                    }
                    else if (slideCount2 > slideCount1)
                    {
                        Console.WriteLine($"Presentation2 has {slideCount2 - slideCount1} extra slide(s) starting from slide {slideCount1 + 1}.");
                    }

                    // Save a copy of the first presentation (no modifications) before exit as required
                    string outputCopyPath = "Presentation1_Copy.pptx";
                    pres1.Save(outputCopyPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other error: " + ex.Message
                Console.WriteLine("An error occurred while processing the presentations: " + ex.Message);
            }
        }
    }
}
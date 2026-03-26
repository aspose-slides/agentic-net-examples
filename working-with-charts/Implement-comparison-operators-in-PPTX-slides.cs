using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input file paths
            string inputPath1 = "Presentation1.pptx";
            string inputPath2 = "Presentation2.pptx";
            // Output file path
            string outputPath = "ComparisonResult.pptx";

            // Verify that input files exist
            if (!File.Exists(inputPath1) || !File.Exists(inputPath2))
            {
                Console.WriteLine("One or both input files do not exist.");
                return;
            }

            // Load the presentations
            using (Presentation presentation1 = new Presentation(inputPath1))
            using (Presentation presentation2 = new Presentation(inputPath2))
            {
                // Compare master slides using Equals method
                for (int i = 0; i < presentation1.Masters.Count; i++)
                {
                    for (int j = 0; j < presentation2.Masters.Count; j++)
                    {
                        if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                        {
                            Console.WriteLine(string.Format("Master slide #{0} of first presentation is equal to master slide #{1} of second presentation.", i, j));
                        }
                    }
                }

                // Add a new empty slide to indicate comparison completed
                Aspose.Slides.ISlide newSlide = presentation1.Slides.AddEmptySlide(presentation1.Slides[0].LayoutSlide);

                // Save the modified presentation
                presentation1.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
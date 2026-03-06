using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load two presentations from files
        Presentation presentation1 = new Presentation("Presentation1.pptx");
        Presentation presentation2 = new Presentation("Presentation2.pptx");

        // Compare each slide from the first presentation with each slide from the second presentation
        for (int i = 0; i < presentation1.Slides.Count; i++)
        {
            for (int j = 0; j < presentation2.Slides.Count; j++)
            {
                IBaseSlide slide1 = presentation1.Slides[i];
                IBaseSlide slide2 = presentation2.Slides[j];
                bool areEqual = slide1.Equals(slide2);
                if (areEqual)
                {
                    Console.WriteLine(string.Format("Slide {0} in Presentation1 is equal to Slide {1} in Presentation2", i, j));
                }
            }
        }

        // Save the first presentation (required before exiting)
        presentation1.Save("ComparisonResult.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation1.Dispose();
        presentation2.Dispose();
    }
}
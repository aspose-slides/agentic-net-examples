using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int slideCount = presentation.Slides.Count;

                    for (int i = 0; i < slideCount; i++)
                    {
                        Aspose.Slides.ISlide slideI = presentation.Slides[i];

                        for (int j = i + 1; j < slideCount; j++)
                        {
                            Aspose.Slides.ISlide slideJ = presentation.Slides[j];

                            bool areEqual = slideI.Equals(slideJ);
                            if (!areEqual)
                            {
                                Console.WriteLine($"Slide {i + 1} is different from Slide {j + 1}");
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
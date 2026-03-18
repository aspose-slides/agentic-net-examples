using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Index at which selected slides will be inserted
            int insertIndex = 1; // after the first slide

            // Source presentation files to merge
            string[] sourceFiles = new string[] { "source1.pptx", "source2.pptx" };

            foreach (string filePath in sourceFiles)
            {
                Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(filePath);
                Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;

                // Insert each slide from the source presentation
                for (int i = 0; i < srcSlides.Count; i++)
                {
                    Aspose.Slides.ISlide srcSlide = srcSlides[i];
                    destPres.Slides.InsertClone(insertIndex, srcSlide);
                    insertIndex++; // advance insertion point
                }

                srcPres.Dispose();
            }

            // Save the merged presentation
            destPres.Save("MergedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            destPres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
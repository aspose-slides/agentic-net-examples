using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the first source presentation
            using (Aspose.Slides.Presentation sourcePresentation1 = new Aspose.Slides.Presentation("source1.pptx"))
            // Load the second source presentation
            using (Aspose.Slides.Presentation sourcePresentation2 = new Aspose.Slides.Presentation("source2.pptx"))
            // Create a new presentation that will hold the merged result
            using (Aspose.Slides.Presentation mergedPresentation = new Aspose.Slides.Presentation())
            {
                // Merge slides from the first source
                foreach (Aspose.Slides.ISlide slide in sourcePresentation1.Slides)
                {
                    mergedPresentation.Slides.InsertClone(mergedPresentation.Slides.Count, slide);
                }

                // Merge slides from the second source
                foreach (Aspose.Slides.ISlide slide in sourcePresentation2.Slides)
                {
                    mergedPresentation.Slides.InsertClone(mergedPresentation.Slides.Count, slide);
                }

                // Access the global layout slide collection to retain or modify layouts
                Aspose.Slides.IGlobalLayoutSlideCollection globalLayouts = mergedPresentation.LayoutSlides;

                // Example: Add a custom layout slide based on the first master slide
                Aspose.Slides.IMasterSlide firstMaster = mergedPresentation.Masters[0];
                globalLayouts.Add(firstMaster, Aspose.Slides.SlideLayoutType.TitleAndObject, "CustomLayout");

                // Save the merged presentation before exiting
                mergedPresentation.Save("merged.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
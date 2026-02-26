using System;
using Aspose.Slides;

namespace PresentationImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the main presentation
            string mainPath = "MainPresentation.pptx";
            // Path to the presentation to be imported
            string importPath = "ImportPresentation.pptx";
            // Path for the output presentation
            string outputPath = "MergedPresentation.pptx";

            // Load the main presentation
            Aspose.Slides.Presentation mainPresentation = new Aspose.Slides.Presentation(mainPath);

            // Use PresentationFactory to read the presentation to be imported
            Aspose.Slides.PresentationFactory factory = new Aspose.Slides.PresentationFactory();
            Aspose.Slides.IPresentation importedPresentation = factory.ReadPresentation(importPath);

            // Append each slide from the imported presentation to the main presentation
            Aspose.Slides.ISlideCollection mainSlides = mainPresentation.Slides;
            Aspose.Slides.ISlideCollection importedSlides = importedPresentation.Slides;

            for (int i = 0; i < importedSlides.Count; i++)
            {
                Aspose.Slides.ISlide sourceSlide = importedSlides[i];
                // Clone the slide into the main presentation
                mainSlides.AddClone(sourceSlide);
            }

            // Save the merged presentation
            mainPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
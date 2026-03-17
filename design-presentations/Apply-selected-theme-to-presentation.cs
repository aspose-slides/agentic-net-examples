using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThemeApplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentation, external theme file, and output presentation
            string sourcePresentationPath = "input.pptx";
            string externalThemePath = "theme.thmx";
            string outputPresentationPath = "output.pptx";

            try
            {
                // Load the existing presentation
                using (Presentation presentation = new Presentation(sourcePresentationPath))
                {
                    // Apply the external theme to each master slide and its dependent slides
                    foreach (IMasterSlide masterSlide in presentation.Masters)
                    {
                        masterSlide.ApplyExternalThemeToDependingSlides(externalThemePath);
                    }

                    // Save the themed presentation
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
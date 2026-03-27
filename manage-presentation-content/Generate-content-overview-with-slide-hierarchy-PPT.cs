using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationContentOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Extract raw text from the presentation (use a valid extraction mode)
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    TextExtractionArrangingMode.Unarranged);

                // Iterate through each slide's extracted text and display hierarchy information
                ISlideText[] slidesText = presentationText.SlidesText;
                for (int i = 0; i < slidesText.Length; i++)
                {
                    ISlideText slideText = slidesText[i];
                    ISlide slide = presentation.Slides[i];

                    Console.WriteLine($"Slide {i + 1}:");
                    Console.WriteLine($"  Text: {slideText.Text}");
                    Console.WriteLine($"  Layout Name: {slide.LayoutSlide.Name}");
                    Console.WriteLine($"  Master Name: {slide.LayoutSlide.MasterSlide.Name}");
                }

                // Add a new empty slide using a Title layout (fallback to TitleAndObject if Title not present)
                IGlobalLayoutSlideCollection globalLayouts = presentation.LayoutSlides;
                ILayoutSlide titleLayout = globalLayouts.GetByType(SlideLayoutType.Title) ??
                                          globalLayouts.GetByType(SlideLayoutType.TitleAndObject);

                if (titleLayout != null)
                {
                    presentation.Slides.AddEmptySlide(titleLayout);
                    Console.WriteLine("Added a new empty slide with Title layout.");
                }
                else
                {
                    Console.WriteLine("No suitable layout found to add a new slide.");
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}
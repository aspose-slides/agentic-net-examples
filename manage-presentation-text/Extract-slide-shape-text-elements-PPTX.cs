using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExtractSlideShapeText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath))
                {
                    // Retrieve raw slide text using PresentationFactory (unarranged mode)
                    Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                        inputFilePath,
                        Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < presentationText.SlidesText.Length; slideIndex++)
                    {
                        Aspose.Slides.ISlideText slideText = presentationText.SlidesText[slideIndex];
                        Console.WriteLine($"Slide {slideIndex + 1} raw text:");
                        Console.WriteLine(slideText.Text);

                        // Get the corresponding slide object for shape-level extraction
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Retrieve all text frames (shapes containing text) on the slide
                        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

                        // Iterate through each text frame (shape) and output its text
                        for (int shapeIndex = 0; shapeIndex < textFrames.Length; shapeIndex++)
                        {
                            Aspose.Slides.ITextFrame textFrame = textFrames[shapeIndex];
                            Console.WriteLine($"  Shape {shapeIndex + 1} text: {textFrame.Text}");
                        }
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
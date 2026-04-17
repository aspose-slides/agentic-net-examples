using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractTextBySlide
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Extract text using a valid arranging mode (Arranged groups text per slide)
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    Aspose.Slides.TextExtractionArrangingMode.Arranged);

                ISlideText[] slidesText = presentationText.SlidesText;

                for (int i = 0; i < slidesText.Length; i++)
                {
                    string slideContent = slidesText[i].Text ?? string.Empty;

                    // Create a new presentation for each slide's text
                    using (Presentation newPres = new Presentation())
                    {
                        // Use the first (and only) slide in the new presentation
                        ISlide newSlide = newPres.Slides[0];

                        // Add a rectangle shape to hold the extracted text
                        IAutoShape textShape = (IAutoShape)newSlide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Rectangle,
                            50,
                            50,
                            600,
                            400);

                        // Insert the extracted text into the shape
                        textShape.AddTextFrame(slideContent);

                        // Save the new presentation
                        string outputFile = $"Slide_{i + 1}.pptx";
                        newPres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for the input file (PPTX)
                Console.WriteLine("The input file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for the input file (PPT)
                Console.WriteLine("The input file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
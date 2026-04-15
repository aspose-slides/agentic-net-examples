using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "template.pptx";
            string outputPath = "validated_output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define template dimensions (points)
                    float templateWidth = 960f;
                    float templateHeight = 720f;

                    // Validate each slide's size
                    int slideCount = presentation.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        // Slide size is common for all slides, retrieve from presentation
                        ISlideSize slideSize = presentation.SlideSize;
                        float currentWidth = slideSize.Size.Width;
                        float currentHeight = slideSize.Size.Height;

                        if (Math.Abs(currentWidth - templateWidth) > 0.01f || Math.Abs(currentHeight - templateHeight) > 0.01f)
                        {
                            // Adjust size to match template
                            slideSize.SetSize(templateWidth, templateHeight, SlideSizeScaleType.DoNotScale);
                            Console.WriteLine($"Slide {i + 1} size adjusted to template.");
                        }
                    }

                    // Save presentation before exit
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Format not supported (PPTX)
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                // Format not supported (PPT)
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
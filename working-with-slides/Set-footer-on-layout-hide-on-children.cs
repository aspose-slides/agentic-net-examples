using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get a layout slide (example: first layout slide of the first master)
                    ILayoutSlide layoutSlide = presentation.Masters[0].LayoutSlides[0];

                    // Set footer visibility to true on the layout slide
                    ILayoutSlideHeaderFooterManager layoutHeaderFooter = layoutSlide.HeaderFooterManager;
                    layoutHeaderFooter.SetFooterVisibility(true);

                    // Hide footers on all child slides that use this layout
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        if (slide.LayoutSlide == layoutSlide)
                        {
                            IBaseSlideHeaderFooterManager slideHeaderFooter = slide.HeaderFooterManager;
                            slideHeaderFooter.SetFooterVisibility(false);
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
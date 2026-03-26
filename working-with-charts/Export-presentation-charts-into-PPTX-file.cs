using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportChartsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory containing the input and output files
            string dataDir = @"C:\Data";
            // Path to the source presentation
            string inputPath = Path.Combine(dataDir, "source.pptx");
            // Path where the new presentation with only charts will be saved
            string outputPath = Path.Combine(dataDir, "charts_only.pptx");

            // Verify that the source presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Source presentation not found: " + inputPath);
                return;
            }

            // Load the source presentation
            using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(inputPath))
            {
                // Create a new empty presentation for the extracted charts
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Remove the default empty slide
                    destPres.Slides.RemoveAt(0);

                    // Get a blank layout slide to use for new slides
                    Aspose.Slides.ILayoutSlide blankLayout = destPres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

                    // Iterate through all slides in the source presentation
                    foreach (Aspose.Slides.ISlide srcSlide in sourcePres.Slides)
                    {
                        // Iterate through all shapes on the current slide
                        foreach (Aspose.Slides.IShape shape in srcSlide.Shapes)
                        {
                            // Check if the shape is a chart
                            if (shape is Aspose.Slides.Charts.IChart)
                            {
                                // Add a new empty slide with the blank layout
                                Aspose.Slides.ISlide newSlide = destPres.Slides.AddEmptySlide(blankLayout);
                                // Clone the chart shape onto the new slide
                                newSlide.Shapes.AddClone(shape);
                            }
                        }
                    }

                    // Save the new presentation containing only the extracted charts
                    destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            Console.WriteLine("Charts exported successfully to: " + outputPath);
        }
    }
}
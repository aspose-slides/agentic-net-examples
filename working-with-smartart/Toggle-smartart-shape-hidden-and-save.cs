using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ToggleSmartArtHidden
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the first slide using the ISlide interface (avoids CS0266)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Locate the first SmartArt shape on the slide
                    Aspose.Slides.IShape smartArtShape = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            smartArtShape = shape;
                            break;
                        }
                    }

                    if (smartArtShape != null)
                    {
                        // Toggle the Hidden property of the SmartArt shape
                        smartArtShape.Hidden = !smartArtShape.Hidden;
                    }
                    else
                    {
                        Console.WriteLine("No SmartArt shape found on the first slide.");
                    }

                    // Save the modified presentation (preserve visibility)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
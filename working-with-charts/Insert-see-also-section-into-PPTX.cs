using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSeeAlsoSection
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
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide (or any target slide)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape to hold the "See also" text
                    Aspose.Slides.IAutoShape seeAlsoShape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        50,   // X position
                        400,  // Y position
                        600,  // Width
                        100   // Height
                    );

                    // Add a text frame with the desired content
                    Aspose.Slides.ITextFrame textFrame = seeAlsoShape.AddTextFrame("See also: Related Topic 1, Related Topic 2, Related Topic 3");

                    // Optionally customize the text appearance
                    textFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 14;
                    textFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = NullableBool.True;

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
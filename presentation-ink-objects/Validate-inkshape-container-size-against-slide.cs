using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkShapeValidation
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Retrieve slide dimensions
                float slideWidth = presentation.SlideSize.Size.Width;
                float slideHeight = presentation.SlideSize.Size.Height;

                // Iterate through shapes to find Ink shapes
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.Ink.Ink inkShape)
                    {
                        // Compare Ink shape size with slide size
                        bool widthMatches = Math.Abs(inkShape.Width - slideWidth) < 0.01f;
                        bool heightMatches = Math.Abs(inkShape.Height - slideHeight) < 0.01f;

                        if (!widthMatches || !heightMatches)
                        {
                            // Adjust Ink shape size to match slide dimensions
                            inkShape.Width = slideWidth;
                            inkShape.Height = slideHeight;
                            inkShape.X = 0;
                            inkShape.Y = 0;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
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
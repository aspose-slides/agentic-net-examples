using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MoveSlideExample
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // IDs of the slides to be moved and the slide after which it should be placed
            uint sourceSlideId = 5; // slide to move
            uint targetSlideId = 3; // slide after which the source slide will be placed

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Retrieve the source and target slides by their IDs
                    IBaseSlide baseSource = presentation.GetSlideById(sourceSlideId);
                    IBaseSlide baseTarget = presentation.GetSlideById(targetSlideId);

                    // Ensure both slides are regular slides (not master or layout slides)
                    if (baseSource is ISlide sourceSlide && baseTarget is ISlide targetSlide)
                    {
                        // Determine the index after which the source slide should be placed
                        int targetIndex = presentation.Slides.IndexOf(targetSlide) + 1;

                        // Move the source slide to the new position
                        presentation.Slides.Reorder(targetIndex, sourceSlide);
                    }
                    else
                    {
                        Console.WriteLine("One of the specified IDs does not correspond to a regular slide.");
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exception
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation file format is not supported.");
            }
            // Handle any other exceptions
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
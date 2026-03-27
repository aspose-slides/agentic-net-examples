using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_cleaned.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the input file
        Presentation presentation = new Presentation(inputPath);

        // Iterate through each slide in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Retrieve all comments (including modern comments) on the current slide
            IComment[] slideComments = slide.GetSlideComments(null);

            // Remove each comment from the slide
            for (int commentIndex = 0; commentIndex < slideComments.Length; commentIndex++)
            {
                IComment comment = slideComments[commentIndex];
                comment.Remove();
            }
        }

        // Save the cleaned presentation to the output file
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}
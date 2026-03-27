using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output_no_comments.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide and remove all comments
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                var slide = presentation.Slides[slideIndex];
                var comments = slide.GetSlideComments(null);
                for (int commentIndex = 0; commentIndex < comments.Length; commentIndex++)
                {
                    comments[commentIndex].Remove();
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("All comments have been removed. Saved to: " + outputPath);
        }
    }
}
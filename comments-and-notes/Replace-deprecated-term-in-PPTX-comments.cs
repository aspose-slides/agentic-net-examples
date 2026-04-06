using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Define the deprecated term and its replacement
                string oldTerm = "DeprecatedTerm";
                string newTerm = "UpdatedTerm";

                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Get all comments on the slide (including those without a specific author)
                    IComment[] comments = slide.GetSlideComments(null);
                    foreach (IComment comment in comments)
                    {
                        // Replace the term in comment text if present
                        if (comment.Text != null && comment.Text.Contains(oldTerm))
                        {
                            comment.Text = comment.Text.Replace(oldTerm, newTerm);
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
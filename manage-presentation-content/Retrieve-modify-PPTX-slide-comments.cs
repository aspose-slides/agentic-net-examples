using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var dataDir = "C:\\Presentations\\";
            var inputPath = dataDir + "input.pptx";
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    // Retrieve all comments on the current slide
                    var comments = slide.GetSlideComments(null);
                    foreach (var comment in comments)
                    {
                        Console.WriteLine($"Slide {slide.SlideNumber} comment by {comment.Author.Name}: {comment.Text}");
                        // Example condition: remove comments containing the word "remove"
                        if (comment.Text != null && comment.Text.Contains("remove"))
                        {
                            comment.Remove();
                        }
                    }
                }

                // Save the modified presentation
                var outputPath = dataDir + "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
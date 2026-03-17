using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides in the presentation
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        // Retrieve all comments on the current slide
                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                        // Remove each comment from the slide
                        foreach (Aspose.Slides.IComment comment in comments)
                        {
                            comment.Remove();
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
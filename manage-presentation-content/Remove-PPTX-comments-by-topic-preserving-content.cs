using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Topic to match in comment text
            string topic = "Confidential";

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        // Retrieve all comments on the slide
                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                        // Remove comments that contain the specified topic
                        foreach (Aspose.Slides.IComment comment in comments)
                        {
                            if (comment.Text != null && comment.Text.Contains(topic))
                            {
                                comment.Remove();
                            }
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
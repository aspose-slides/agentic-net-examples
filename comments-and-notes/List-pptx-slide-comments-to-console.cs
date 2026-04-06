using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ListSlideComments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Retrieve all comments on the slide (null author returns all)
                        IComment[] comments = slide.GetSlideComments(null);

                        // Print comment details
                        foreach (IComment comment in comments)
                        {
                            string authorName = comment.Author != null ? comment.Author.Name : "Unknown";
                            Console.WriteLine("Slide {0} - Author: {1} - Text: {2}",
                                slide.SlideNumber, authorName, comment.Text);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
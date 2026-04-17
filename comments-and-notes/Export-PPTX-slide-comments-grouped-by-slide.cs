using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCommentsExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output report path
            string reportPath = "CommentsReport.txt";
            // Output presentation path (saved before exit)
            string outputPresentationPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    StringBuilder reportBuilder = new StringBuilder();

                    // Iterate through slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IComment[] comments = slide.GetSlideComments(null);

                        if (comments != null && comments.Length > 0)
                        {
                            reportBuilder.AppendLine($"Slide {slide.SlideNumber}:");
                            foreach (IComment comment in comments)
                            {
                                reportBuilder.AppendLine($"- Author: {comment.Author.Name}");
                                reportBuilder.AppendLine($"  Text: {comment.Text}");
                                reportBuilder.AppendLine($"  Created: {comment.CreatedTime}");
                            }
                            reportBuilder.AppendLine();
                        }
                    }

                    // Write report to file
                    File.WriteAllText(reportPath, reportBuilder.ToString());

                    // Save the presentation before exit
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
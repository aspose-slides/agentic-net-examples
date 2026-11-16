// -----------------------------------------------------------------------------
// Example: Export Slide Comments to JSON using C#
// 
// Description:
// Demonstrates how to extract all comments from each slide of a PowerPoint
// presentation and serialize them to a JSON file using Aspose.Slides for .NET.
// The program creates a sample PPTX file if it does not exist, reads comment
// data, and writes a formatted JSON file. Includes basic error handling for
// missing files and unsupported formats.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, Comments, JSON
// 
// Use Cases:
// - Automate extraction of slide comments for review or reporting.
// - Convert PowerPoint annotations to JSON for further analysis.
// - Integrate comment data into web services or databases.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace ExportComments
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "sample.pptx";
            string outputPath = "comments.json";

            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation newPresentation = new Aspose.Slides.Presentation();
                    // Add a blank slide to ensure the presentation has at least one slide
                    Aspose.Slides.ISlide blankSlide = newPresentation.Slides.AddEmptySlide(newPresentation.Slides[0].LayoutSlide);
                    newPresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    newPresentation.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                List<CommentInfo> allComments = new List<CommentInfo>();

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                    foreach (Aspose.Slides.IComment comment in comments)
                    {
                        CommentInfo info = new CommentInfo();
                        info.SlideNumber = i + 1;
                        info.AuthorName = comment.Author.Name;
                        info.AuthorInitials = comment.Author.Initials;
                        info.Text = comment.Text;
                        info.CreatedTime = comment.CreatedTime;
                        allComments.Add(info);
                    }
                }

                string json = JsonSerializer.Serialize(allComments, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputPath, json);

                // Save the presentation before exiting (no modifications made)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
                Environment.Exit(1);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }

    public class CommentInfo
    {
        public int SlideNumber { get; set; }
        public string AuthorName { get; set; }
        public string AuthorInitials { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

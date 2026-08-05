// -----------------------------------------------------------------------------
// Example: Export slide comments to JSON using C#
//
// Description:
// Demonstrates how to extract all comments from each slide of a PowerPoint
// presentation and serialize them to a JSON file using Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through slides, collects comment
// details (author, text, creation time, slide number) into a POCO, and writes
// the collection as formatted JSON. It also shows basic error handling for
// unsupported formats and missing input files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, Comments, JSON,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of slide comments for review or reporting.
// - Build tools that convert PowerPoint annotations to JSON for further analysis.
// - Integrate comment data into web services or databases.
// - Validate comment presence before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportComments
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "comments.json";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<CommentInfo> allComments = new List<CommentInfo>();

                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IComment[] comments = slide.GetSlideComments(null);
                        foreach (IComment comment in comments)
                        {
                            CommentInfo info = new CommentInfo
                            {
                                SlideNumber = i + 1,
                                AuthorName = comment.Author.Name,
                                AuthorInitials = comment.Author.Initials,
                                Text = comment.Text,
                                CreatedTime = comment.CreatedTime
                            };
                            allComments.Add(info);
                        }
                    }

                    string json = JsonSerializer.Serialize(allComments, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputPath, json);

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
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

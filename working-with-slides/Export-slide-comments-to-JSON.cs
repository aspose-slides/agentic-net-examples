using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideComments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "comments.json";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // List to hold comment information
                    List<CommentInfo> commentList = new List<CommentInfo>();

                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        // Retrieve all comments on the current slide
                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                        // Process each comment
                        foreach (Aspose.Slides.IComment comment in comments)
                        {
                            CommentInfo info = new CommentInfo
                            {
                                SlideNumber = slide.SlideNumber,
                                Author = comment.Author.Name,
                                Text = comment.Text,
                                CreatedTime = comment.CreatedTime
                            };
                            commentList.Add(info);
                        }
                    }

                    // Serialize the comment list to JSON
                    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                    string json = JsonSerializer.Serialize(commentList, options);

                    // Write JSON to the output file
                    File.WriteAllText(outputPath, json);
                    Console.WriteLine($"Comments exported to '{outputPath}'.");

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    // Helper class to represent comment data
    public class CommentInfo
    {
        public int SlideNumber { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slide comments to JSON using C#

//

// Description:

// Demonstrates how to export all slide comments from a PPTX file to a JSON

// document using C# and Aspose.Slides for .NET. The example loads a presentation,

// iterates through each comment author and their comments, collects relevant

// information, and serializes the data to a formatted JSON file. This pattern

// can be used to automate comment extraction, integrate with reporting tools,

// or perform presentation analysis in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, JSON, Slide, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of PPTX slide comments to JSON for reporting.

// - Build C# utilities for PowerPoint presentation analysis.

// - Integrate comment data into .NET applications or services.

// - Validate and audit presentation content before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Collections.Generic;

using System.Text.Json;

using Aspose.Slides;



class CommentInfo

{

    public int SlideNumber { get; set; }

    public string AuthorName { get; set; }

    public string Text { get; set; }

    public DateTime CreatedTime { get; set; }

}



class Program

{

    static void Main()

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

            using var presentation = new Presentation(inputPath);

            var commentList = new List<CommentInfo>();



            foreach (CommentAuthor author in presentation.CommentAuthors)

            {

                foreach (Comment comment in author.Comments)

                {

                    if (comment.Slide != null)

                    {

                        var info = new CommentInfo

                        {

                            SlideNumber = comment.Slide.SlideNumber,

                            AuthorName = author.Name,

                            Text = comment.Text,

                            CreatedTime = comment.CreatedTime

                        };

                        commentList.Add(info);

                    }

                }

            }



            string json = JsonSerializer.Serialize(commentList, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(outputPath, json);

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


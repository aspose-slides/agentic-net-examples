// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export comment threads to hierarchical JSON using C#

//

// Description:

// Demonstrates how to extract comment threads from a PowerPoint presentation,

// build a hierarchical structure reflecting parent‑reply relationships, and

// serialize the result to formatted JSON using Aspose.Slides for .NET. The

// example also saves a copy of the original presentation. This pattern can be

// used to automate comment analysis, migration, or reporting in .NET

// applications.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Export, Comments, Threads,

// Hierarchical JSON, Presentation Processing, Office Automation

//

// Use Cases:

// - Export PowerPoint comment threads to a structured JSON file for analysis.

// - Build tools that process or migrate presentation comments in .NET.

// - Generate reports on comment activity across slides.

// - Validate or audit presentation feedback before publishing.

// -----------------------------------------------------------------------------

using System;

using System.Collections.Generic;

using System.IO;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentExport

{

    class Program

    {

        static void Main(string[] args)

        {

            var inputPath = "input.pptx";

            var outputJsonPath = "comments.json";

            var outputPresPath = "output.pptx";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            Aspose.Slides.Presentation pres = null;

            try

            {

                pres = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to load presentation. Possible unsupported format.");

                Console.WriteLine(ex.Message);

                return;

            }



            var commentNodeMap = new Dictionary<IComment, CommentNode>();

            var rootComments = new List<CommentNode>();



            foreach (var slide in pres.Slides)

            {

                var comments = slide.GetSlideComments(null);

                foreach (var comment in comments)

                {

                    var node = new CommentNode

                    {

                        Author = comment.Author.Name,

                        Text = comment.Text,

                        Replies = new List<CommentNode>()

                    };

                    commentNodeMap[comment] = node;



                    if (comment.ParentComment == null)

                    {

                        rootComments.Add(node);

                    }

                    else

                    {

                        if (commentNodeMap.TryGetValue(comment.ParentComment, out var parentNode))

                        {

                            parentNode.Replies.Add(node);

                        }

                        else

                        {

                            // Parent not processed yet; ensure it exists in map

                            var placeholder = new CommentNode

                            {

                                Author = comment.ParentComment.Author.Name,

                                Text = comment.ParentComment.Text,

                                Replies = new List<CommentNode>()

                            };

                            commentNodeMap[comment.ParentComment] = placeholder;

                            placeholder.Replies.Add(node);

                        }

                    }

                }

            }



            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

            var json = JsonSerializer.Serialize(rootComments, jsonOptions);

            File.WriteAllText(outputJsonPath, json);

            Console.WriteLine("Comments exported to JSON: " + outputJsonPath);



            // Save presentation before exit

            pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }



        class CommentNode

        {

            public string Author { get; set; }

            public string Text { get; set; }

            public List<CommentNode> Replies { get; set; }

        }

    }

}


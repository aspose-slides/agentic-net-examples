// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Reconstruct PPTX slide comments from JSON using C#

//

// Description:

// Demonstrates how to read slide comments from a JSON file and reconstruct

// them in a new PowerPoint presentation using Aspose.Slides for .NET. The

// example creates authors, positions comments on the appropriate slides,

// and restores parent‑child comment relationships.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Comments, JSON, Reconstruction,

// Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate a PowerPoint file with comments based on external JSON data.

// - Restore comment hierarchy (replies) when migrating presentations.

// - Automate comment insertion for reporting or documentation workflows.

// - Integrate comment reconstruction into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentReconstruction

{

    class Program

    {

        // Model representing a comment in JSON

        private class JsonComment

        {

            public int Id { get; set; }

            public int? ParentId { get; set; }

            public string AuthorName { get; set; }

            public string AuthorInitials { get; set; }

            public int SlideIndex { get; set; }

            public float X { get; set; }

            public float Y { get; set; }

            public string Text { get; set; }

        }



        static void Main(string[] args)

        {

            string jsonPath = "comments.json";

            string outputPath = "output.pptx";



            // Verify input JSON file exists

            if (!File.Exists(jsonPath))

            {

                Console.WriteLine("Input JSON file not found: " + jsonPath);

                return;

            }



            // Read and deserialize JSON

            string jsonContent = File.ReadAllText(jsonPath);

            List<JsonComment> jsonComments = JsonSerializer.Deserialize<List<JsonComment>>(jsonContent);



            // Create a new presentation

            Presentation presentation = new Presentation();



            // Ensure slides exist for the highest slide index referenced

            int maxSlideIndex = 0;

            foreach (JsonComment jc in jsonComments)

            {

                if (jc.SlideIndex > maxSlideIndex)

                    maxSlideIndex = jc.SlideIndex;

            }

            while (presentation.Slides.Count <= maxSlideIndex)

            {

                presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            }



            // Dictionaries to keep track of authors and comments

            Dictionary<string, ICommentAuthor> authorMap = new Dictionary<string, ICommentAuthor>();

            Dictionary<int, IComment> commentMap = new Dictionary<int, IComment>();



            // First pass: add all comments without setting parent

            foreach (JsonComment jc in jsonComments)

            {

                // Get or create author

                string authorKey = jc.AuthorName + "|" + jc.AuthorInitials;

                ICommentAuthor author;

                if (!authorMap.TryGetValue(authorKey, out author))

                {

                    author = presentation.CommentAuthors.AddAuthor(jc.AuthorName, jc.AuthorInitials);

                    authorMap[authorKey] = author;

                }



                // Create position point

                System.Drawing.PointF position = new System.Drawing.PointF(jc.X, jc.Y);



                // Add comment to the slide

                IComment comment = author.Comments.AddComment(

                    jc.Text,

                    presentation.Slides[jc.SlideIndex],

                    position,

                    DateTime.Now);



                commentMap[jc.Id] = comment;

            }



            // Second pass: set parent relationships

            foreach (JsonComment jc in jsonComments)

            {

                if (jc.ParentId.HasValue)

                {

                    IComment child = commentMap[jc.Id];

                    IComment parent = commentMap[jc.ParentId.Value];

                    child.ParentComment = parent;

                }

            }



            // Save the presentation

            try

            {

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for saving.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);

            }



            // Dispose presentation

            presentation.Dispose();

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Import markdown comments to PPTX slides using C#

//

// Description:

// Demonstrates how to read a markdown file containing comment entries and

// import them as modern comments into a PowerPoint presentation using

// Aspose.Slides for .NET. The example creates a new presentation, adds a

// single slide, maps comment authors, and places each comment at a fixed

// position on the first slide. The resulting PPTX file is saved to disk.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Import, Markdown, Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert markdown comment lists into PowerPoint slide comments.

// - Automate documentation or review workflows that involve PPTX files.

// - Build tools that enrich presentations with author‑attributed notes.

// - Integrate markdown‑based feedback into existing PowerPoint assets.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideCommentImporter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input markdown file containing comments

            string inputPath = "comments.md";

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            // Read all lines from the markdown file

            string[] lines = File.ReadAllLines(inputPath);



            // Create a new presentation

            Presentation presentation = new Presentation();



            // Ensure there is at least one slide

            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);



            // Map to store authors to avoid duplicates

            Dictionary<string, ICommentAuthor> authorMap = new Dictionary<string, ICommentAuthor>();



            // Process each line: expected format "AuthorName|Initials|CommentText"

            foreach (string line in lines)

            {

                if (string.IsNullOrWhiteSpace(line))

                    continue;



                string[] parts = line.Split(new char[] { '|' }, 3);

                if (parts.Length != 3)

                    continue; // Skip malformed lines



                string authorName = parts[0].Trim();

                string authorInitials = parts[1].Trim();

                string commentText = parts[2].Trim();



                ICommentAuthor author;

                if (!authorMap.TryGetValue(authorName, out author))

                {

                    author = presentation.CommentAuthors.AddAuthor(authorName, authorInitials);

                    authorMap.Add(authorName, author);

                }



                // Add modern comment to the first slide at a fixed position

                author.Comments.AddModernComment(

                    commentText,

                    presentation.Slides[0],

                    null,

                    new PointF(100, 100),

                    DateTime.Now);

            }



            // Save the presentation

            string outputPath = "output.pptx";

            presentation.Save(outputPath, SaveFormat.Pptx);

            presentation.Dispose();



            Console.WriteLine("Presentation saved to: " + outputPath);

        }

    }

}


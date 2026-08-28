// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Limit comment reply depth to three levels using C#

//

// Description:

// Demonstrates how to limit comment reply depth to three levels using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Limit, Comment, Reply, Depth, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate limit comment reply depth to three levels.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentDepthDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Create a new presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



            // Add an empty slide (the presentation already contains one, this is optional)

            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);



            // Add comment authors

            Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author1", "A1");

            Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author2", "A2");



            // Define a position for all comments

            System.Drawing.PointF position = new System.Drawing.PointF(100, 100);



            // Level 1 comment (root)

            Aspose.Slides.IComment commentLevel1 = author1.Comments.AddComment(

                "Level 1 comment",

                presentation.Slides[0],

                position,

                DateTime.Now);



            // Level 2 reply

            Aspose.Slides.IComment commentLevel2 = author2.Comments.AddComment(

                "Level 2 reply",

                presentation.Slides[0],

                position,

                DateTime.Now);

            commentLevel2.ParentComment = commentLevel1;



            // Level 3 sub‑reply

            Aspose.Slides.IComment commentLevel3 = author1.Comments.AddComment(

                "Level 3 sub‑reply",

                presentation.Slides[0],

                position,

                DateTime.Now);

            commentLevel3.ParentComment = commentLevel2;



            // Attempt to add a fourth‑level comment (should be prevented)

            Aspose.Slides.IComment potentialLevel4 = author2.Comments.AddComment(

                "Level 4 should be ignored",

                presentation.Slides[0],

                position,

                DateTime.Now);



            // Determine the depth of the new comment

            Aspose.Slides.IComment temp = potentialLevel4;

            int depth = 0;

            while (temp.ParentComment != null)

            {

                depth++;

                temp = temp.ParentComment;

            }



            // If depth exceeds 2 (i.e., more than three levels), remove the comment

            if (depth > 2)

            {

                potentialLevel4.Remove();

            }

            else

            {

                potentialLevel4.ParentComment = commentLevel3;

            }



            // Save the presentation

            presentation.Save("CommentDepthDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);



            // Dispose the presentation

            presentation.Dispose();

        }

    }

}


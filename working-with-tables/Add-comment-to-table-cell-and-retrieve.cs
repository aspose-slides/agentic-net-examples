// -----------------------------------------------------------------------------
// Example: Add comment to table cell and retrieve using C#
//
// Description:
// Demonstrates how to add a comment to a specific table cell in a PowerPoint
// slide, retrieve the comment, and output its details using C# and Aspose.Slides
// for .NET. The example creates a presentation, inserts a table, adds text to a
// target cell, associates a comment with that cell, enumerates comments on the
// slide, and saves the result as a PPTX file. This pattern can be used to
// automate comment handling in presentations, validate content, or integrate
// PowerPoint workflows into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Comment, Table, Cell, Retrieve,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding comments to specific table cells in PowerPoint slides.
// - Build C# tools for extracting and processing comments from presentations.
// - Generate or modify PPTX files with table annotations in .NET applications.
// - Validate comment placement and content before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Define table dimensions
        double[] cols = new double[] { 100, 100, 100 };
        double[] rows = new double[] { 50, 50, 50 };

        // Add a table to the slide
        var table = slide.Shapes.AddTable(50, 50, cols, rows);

        // Add text to the target cell (row 1, column 1)
        table[1, 1].TextFrame.Text = "Target Cell";

        // Add a comment author
        var author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define comment position on the slide
        var position = new PointF(100, 100);

        // Add a comment associated with the slide (referencing the cell in text)
        var comment = author.Comments.AddComment("Comment on cell (1,1)", slide, position, DateTime.Now);

        // Retrieve and display comments from the slide
        var comments = slide.GetSlideComments(null);
        for (int i = 0; i < comments.Length; i++)
        {
            var c = comments[i];
            Console.WriteLine("Comment: " + c.Text + " | Author: " + c.Author.Name);
        }

        // Save the presentation
        var outputPath = "TableCommentDemo.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}

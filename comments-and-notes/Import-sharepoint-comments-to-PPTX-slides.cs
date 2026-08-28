// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Import SharePoint comments to PPTX slides using C#

//

// Description:

// Demonstrates how to import comments stored in a SharePoint list into a

// PowerPoint presentation. The example loads an existing PPTX file, creates

// comment authors, attaches comments to slides whose title matches the SharePoint

// entry, and saves the updated presentation. It uses Aspose.Slides for .NET

// and can serve as a template for automating comment import workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Import, SharePoint, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the import of SharePoint comments into PowerPoint slides.

// - Build .NET tools for enriching presentations with external feedback.

// - Integrate SharePoint comment data into PPTX files during CI/CD pipelines.

// - Validate and preview comment placement before publishing presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Collections.Generic;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output paths

        string dataDir = "Data";

        string inputPath = Path.Combine(dataDir, "input.pptx");

        string outputPath = Path.Combine(dataDir, "output.pptx");



        // Check if input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Load the presentation

        Presentation presentation = null;

        try

        {

            presentation = new Presentation(inputPath);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Failed to load presentation: " + ex.Message);

            return;

        }



        // Retrieve comments from SharePoint list (placeholder implementation)

        List<Tuple<string, string, string>> sharePointComments = new List<Tuple<string, string, string>>();

        try

        {

            // Each tuple contains: SlideTitle, AuthorName, CommentText

            sharePointComments.Add(new Tuple<string, string, string>("Title 1", "Alice", "First comment"));

            sharePointComments.Add(new Tuple<string, string, string>("Title 2", "Bob", "Second comment"));

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error accessing SharePoint: " + ex.Message);

        }



        // Create or retrieve comment authors

        Dictionary<string, ICommentAuthor> authors = new Dictionary<string, ICommentAuthor>();

        foreach (Tuple<string, string, string> item in sharePointComments)

        {

            string authorName = item.Item2;

            if (!authors.ContainsKey(authorName))

            {

                ICommentAuthor author = presentation.CommentAuthors.AddAuthor(authorName, authorName.Substring(0, 1));

                authors.Add(authorName, author);

            }

        }



        // Define comment position and timestamp

        PointF position = new PointF(0.2f, 0.2f);

        DateTime now = DateTime.Now;



        // Attach comments to slides matching the title

        foreach (ISlide slide in presentation.Slides)

        {

            string slideTitle = string.Empty;

            if (slide.Shapes.Count > 0 && slide.Shapes[0] is IAutoShape)

            {

                IAutoShape shape = (IAutoShape)slide.Shapes[0];

                if (shape.TextFrame != null)

                {

                    slideTitle = shape.TextFrame.Text;

                }

            }



            foreach (Tuple<string, string, string> item in sharePointComments)

            {

                if (item.Item1.Equals(slideTitle, StringComparison.OrdinalIgnoreCase))

                {

                    ICommentAuthor author = authors[item.Item2];

                    author.Comments.AddComment(item.Item3, slide, position, now);

                }

            }

        }



        // Save the updated presentation

        try

        {

            presentation.Save(outputPath, SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error saving presentation: " + ex.Message);

        }

        finally

        {

            if (presentation != null)

                presentation.Dispose();

        }

    }

}


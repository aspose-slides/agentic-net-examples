// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Serialize PPTX slide comments to binary using C#

//

// Description:

// Demonstrates how to create a PowerPoint presentation, add a slide comment,

// serialize all slide comments to a binary file, deserialize them into a new

// presentation, and save both presentations. The example uses Aspose.Slides for

// .NET and shows the required steps for handling slide comments in binary form.

//

// Keywords:

// C#, Aspose.Slides, PPTX, Serialize, Binary, Slide Comments, Presentation

// Processing, Office Automation, .NET

//

// Use Cases:

// - Export slide comments to a compact binary format for storage or transmission.

// - Reconstruct presentations from serialized comment data.

// - Build tools that need to backup or migrate PowerPoint comment information.

// - Automate validation of comment data in PowerPoint workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation and add a comment

        Presentation presentation = new Presentation();

        ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        author.Comments.AddComment("Sample comment", presentation.Slides[0], new PointF(0.5f, 0.5f), DateTime.Now);



        // Serialize comments to a binary file

        string binaryPath = "comments.bin";

        using (FileStream fs = new FileStream(binaryPath, FileMode.Create, FileAccess.Write))

        using (BinaryWriter writer = new BinaryWriter(fs))

        {

            writer.Write(presentation.Slides.Count);

            foreach (ISlide slide in presentation.Slides)

            {

                IComment[] comments = slide.GetSlideComments(null);

                writer.Write(comments.Length);

                foreach (IComment cmt in comments)

                {

                    writer.Write(cmt.Author.Name);

                    writer.Write(cmt.Author.Initials);

                    writer.Write(cmt.Text);

                    writer.Write(cmt.CreatedTime.Ticks);

                    writer.Write(cmt.Position.X);

                    writer.Write(cmt.Position.Y);

                }

            }

        }



        // Deserialize comments into a new presentation

        Presentation newPresentation = new Presentation();

        using (FileStream fs = new FileStream(binaryPath, FileMode.Open, FileAccess.Read))

        using (BinaryReader reader = new BinaryReader(fs))

        {

            int slideCount = reader.ReadInt32();

            while (newPresentation.Slides.Count < slideCount)

            {

                newPresentation.Slides.AddEmptySlide(newPresentation.LayoutSlides[0]);

            }



            for (int i = 0; i < slideCount; i++)

            {

                ISlide slide = newPresentation.Slides[i];

                int commentCount = reader.ReadInt32();

                for (int j = 0; j < commentCount; j++)

                {

                    string authorName = reader.ReadString();

                    string authorInitials = reader.ReadString();

                    string text = reader.ReadString();

                    long ticks = reader.ReadInt64();

                    float posX = reader.ReadSingle();

                    float posY = reader.ReadSingle();



                    ICommentAuthor desAuthor = newPresentation.CommentAuthors.AddAuthor(authorName, authorInitials);

                    desAuthor.Comments.AddComment(text, slide, new PointF(posX, posY), new DateTime(ticks));

                }

            }

        }



        // Save presentations with format handling

        try

        {

            presentation.Save("OriginalPresentation.pptx", SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Format not supported

            Console.WriteLine("Error saving original presentation: " + ex.Message);

        }



        try

        {

            newPresentation.Save("ReconstructedPresentation.pptx", SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Format not supported

            Console.WriteLine("Error saving reconstructed presentation: " + ex.Message);

        }



        // Dispose resources

        presentation.Dispose();

        newPresentation.Dispose();

    }

}


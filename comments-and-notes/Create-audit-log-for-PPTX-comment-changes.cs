// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create audit log for PPTX comment changes using C#

//

// Description:

// Demonstrates how to create audit log for PPTX comment changes using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audit, Pptx, Comment, Changes, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate create audit log for PPTX comment changes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        if (args.Length > 0)

        {

            inputPath = args[0];

        }

        string outputPath = "output.pptx";

        string logPath = "audit.log";



        using (StreamWriter logWriter = new StreamWriter(logPath, false))

        {

            Presentation presentation = null;

            try

            {

                if (File.Exists(inputPath))

                {

                    presentation = new Presentation(inputPath);

                    logWriter.WriteLine($"{DateTime.Now}: Loaded presentation '{inputPath}'.");

                }

                else

                {

                    presentation = new Presentation();

                    logWriter.WriteLine($"{DateTime.Now}: Created new presentation.");

                }



                if (presentation.Slides.Count == 0)

                {

                    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    logWriter.WriteLine($"{DateTime.Now}: Added empty slide.");

                }



                ICommentAuthor author = presentation.CommentAuthors.AddAuthor("AuditUser", "AU");

                logWriter.WriteLine($"{DateTime.Now}: Added comment author '{author.Name}'.");



                PointF position = new PointF(0.2f, 0.2f);

                IComment comment = author.Comments.AddComment("Initial comment", presentation.Slides[0], position, DateTime.Now);

                logWriter.WriteLine($"{DateTime.Now}: Added comment on slide {comment.Slide.SlideNumber} with text '{comment.Text}'.");



                comment.Text = "Modified comment text";

                logWriter.WriteLine($"{DateTime.Now}: Modified comment text to '{comment.Text}'.");



                author.Comments.Remove(comment);

                logWriter.WriteLine($"{DateTime.Now}: Deleted comment.");



                presentation.Save(outputPath, SaveFormat.Pptx);

                logWriter.WriteLine($"{DateTime.Now}: Saved presentation to '{outputPath}'.");

            }

            catch (PptxUnsupportedFormatException ex)

            {

                logWriter.WriteLine($"{DateTime.Now}: Unsupported file format. {ex.Message}");

            }

            catch (PptUnsupportedFormatException ex)

            {

                logWriter.WriteLine($"{DateTime.Now}: Unsupported file format. {ex.Message}");

            }

            catch (Exception ex)

            {

                logWriter.WriteLine($"{DateTime.Now}: Unexpected error. {ex.Message}");

            }

            finally

            {

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}


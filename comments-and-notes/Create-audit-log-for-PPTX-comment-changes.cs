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
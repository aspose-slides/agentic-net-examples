using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputXmlPath = "comments.xml";
            string outputPresentationPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                XElement root = new XElement("Comments");

                foreach (object authorObj in presentation.CommentAuthors)
                {
                    Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                    foreach (object commentObj in author.Comments)
                    {
                        Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                        XElement commentElement = new XElement("Comment",
                            new XElement("Author", author.Name),
                            new XElement("Text", comment.Text),
                            new XElement("CreatedTime", comment.CreatedTime),
                            new XElement("SlideNumber", comment.Slide.SlideNumber)
                        );
                        root.Add(commentElement);
                    }
                }

                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);
                document.Save(outputXmlPath);

                // Save the presentation before exiting (no modifications made)
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
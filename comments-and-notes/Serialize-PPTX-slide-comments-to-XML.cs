// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Serialize PPTX slide comments to XML using C#

//

// Description:

// Demonstrates how to serialize slide comments from a PPTX file into an

// XML document using C# and Aspose.Slides for .NET. The example loads a

// presentation, iterates through comment authors and their comments, writes

// comment details to an XML file, and saves a copy of the original presentation.

// This pattern can be used for reporting, auditing, or migrating comments.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Serialize, XML, Slide, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Export slide comments to XML for analysis or documentation.

// - Create tools that audit or archive PowerPoint comment data.

// - Integrate comment extraction into .NET applications or CI pipelines.

// - Transform comment information for reporting or migration purposes.

// -----------------------------------------------------------------------------

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


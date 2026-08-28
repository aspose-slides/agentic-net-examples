// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Import PPTX slide comments from XML using C#

//

// Description:

// Demonstrates how to import PPTX slide comments from an XML file using C#

// and Aspose.Slides for .NET. The example creates a new presentation, parses

// comment data from the XML, adds comments with proper authors and positions

// to the appropriate slides, and saves the result as a PPTX file. This pattern

// can be used to automate comment import workflows, integrate comment data

// from external sources, or build tools for PowerPoint presentation processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Import, XML, Slide, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate importing slide comments from XML into PowerPoint files.

// - Build C# utilities for synchronizing external comment repositories with PPTX.

// - Generate or enrich PPTX presentations with comment metadata in .NET applications.

// - Validate and test comment import processes before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using System.Xml.Linq;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentDeserializer

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths for input XML and output presentation

            string inputXmlPath = "comments.xml";

            string outputPptxPath = "output.pptx";



            // Verify that the XML file exists

            if (!File.Exists(inputXmlPath))

            {

                Console.WriteLine("Input XML file does not exist: " + inputXmlPath);

                return;

            }



            // Create a new presentation

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())

            {

                // Ensure at least one slide exists

                pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);



                // Load and parse the XML document

                XDocument xmlDoc = XDocument.Load(inputXmlPath);

                IEnumerable<XElement> commentElements = xmlDoc.Root.Elements("Comment");



                // Dictionary to reuse authors (key: name|initials)

                Dictionary<string, Aspose.Slides.ICommentAuthor> authors = new Dictionary<string, Aspose.Slides.ICommentAuthor>();



                foreach (XElement elem in commentElements)

                {

                    // Extract attributes with defaults

                    int slideIndex = (int)elem.Attribute("SlideIndex");

                    string authorName = (string)elem.Attribute("AuthorName") ?? "Author";

                    string authorInitials = (string)elem.Attribute("AuthorInitials") ?? "AU";

                    string text = (string)elem.Attribute("Text") ?? "";

                    float posX = (float?)elem.Attribute("X") ?? 0.0f;

                    float posY = (float?)elem.Attribute("Y") ?? 0.0f;

                    DateTime created = (DateTime?)elem.Attribute("Created") ?? DateTime.Now;



                    // Ensure the slide exists; add empty slides if necessary

                    while (pres.Slides.Count <= slideIndex)

                    {

                        pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

                    }



                    // Retrieve or create the comment author

                    string authorKey = authorName + "|" + authorInitials;

                    Aspose.Slides.ICommentAuthor author;

                    if (!authors.TryGetValue(authorKey, out author))

                    {

                        author = pres.CommentAuthors.AddAuthor(authorName, authorInitials);

                        authors.Add(authorKey, author);

                    }



                    // Create position point

                    System.Drawing.PointF position = new System.Drawing.PointF(posX, posY);



                    // Add the comment to the specified slide

                    author.Comments.AddComment(text, pres.Slides[slideIndex], position, created);

                }



                // Save the presentation

                try

                {

                    pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

                catch (Exception ex)

                {

                    // Handle format not supported or other save errors

                    Console.WriteLine("Error saving presentation: " + ex.Message);

                    // Format not supported comment

                    // The specified format may not be supported.

                }

            }

        }

    }

}


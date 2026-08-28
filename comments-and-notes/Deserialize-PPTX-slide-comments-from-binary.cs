// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Deserialize PPTX slide comments from binary using C#

//

// Description:

// Demonstrates how to deserialize PPTX slide comments from binary using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Deserialize, Pptx, Slide, 

// Comments, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate deserialize PPTX slide comments from binary.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentDeserializer

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the binary file containing comment data

            string inputBinaryPath = "comments.bin";



            // Verify that the input file exists

            if (!File.Exists(inputBinaryPath))

            {

                Console.WriteLine("Input binary file not found: " + inputBinaryPath);

                return;

            }



            try

            {

                // Read the binary data

                byte[] binaryData = File.ReadAllBytes(inputBinaryPath);

                using (MemoryStream memoryStream = new MemoryStream(binaryData))

                using (BinaryReader reader = new BinaryReader(memoryStream))

                {

                    // Deserialize comment text and position (example format)

                    string commentText = reader.ReadString();

                    float positionX = reader.ReadSingle();

                    float positionY = reader.ReadSingle();



                    // Create a new presentation

                    Presentation presentation = new Presentation();



                    // Add an empty slide to host the comment

                    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);



                    // Add a comment author

                    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Deserialized Author", "DA");



                    // Define comment position

                    PointF commentPosition = new PointF(positionX, positionY);



                    // Add the deserialized comment to the first slide

                    author.Comments.AddComment(commentText, presentation.Slides[0], commentPosition, DateTime.Now);



                    // Save the presentation

                    presentation.Save("DeserializedComments.pptx", SaveFormat.Pptx);



                    // Dispose the presentation

                    presentation.Dispose();

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


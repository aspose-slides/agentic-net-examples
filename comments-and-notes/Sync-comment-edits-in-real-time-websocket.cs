// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Sync comment edits in real time websocket using C#

//

// Description:

// Demonstrates how to edit an existing comment in a PowerPoint presentation

// and broadcast the change to connected clients via a WebSocket using

// Aspose.Slides for .NET. The example loads a PPTX file, modifies the first

// comment it finds, sends the updated comment text over a WebSocket connection,

// and saves the updated presentation. This pattern can be used to implement

// real‑time collaborative comment editing in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Sync, Comment, Edits, Real-time,

// WebSocket, Presentation Processing, Office Automation

//

// Use Cases:

// - Synchronize comment edits across multiple clients in real time.

// - Build C# tools for managing PowerPoint comments and notes.

// - Integrate comment synchronization into collaborative web or desktop apps.

// - Automate comment editing and broadcasting as part of PPTX workflow automation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Net;

using System.Net.WebSockets;

using System.Text;

using System.Threading;

using System.Threading.Tasks;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SyncCommentEdits

{

    class Program

    {

        static void Main(string[] args)

        {

            string presentationPath = "Comments.pptx";



            // Verify that the input file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(presentationPath))

                {

                    // Example: edit the first comment found

                    Aspose.Slides.Comment commentToEdit = null;



                    foreach (ICommentAuthor author in presentation.CommentAuthors)

                    {

                        foreach (IComment existingComment in author.Comments)

                        {

                            commentToEdit = (Aspose.Slides.Comment) existingComment;

                            break;

                        }

                        if (commentToEdit != null)

                        {

                            break;

                        }

                    }



                    if (commentToEdit != null)

                    {

                        // Update comment text

                        commentToEdit.Text = "Edited comment text via WebSocket sync";



                        // Broadcast the change to connected clients

                        BroadcastCommentEditAsync(commentToEdit).GetAwaiter().GetResult();

                    }

                    else

                    {

                        Console.WriteLine("No comments found to edit.");

                    }



                    // Save the presentation before exiting

                    presentation.Save("Comments_Updated.pptx", SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }



        // Simple WebSocket broadcast (placeholder implementation)

        private static async Task BroadcastCommentEditAsync(Aspose.Slides.Comment editedComment)

        {

            // Example WebSocket server URL (replace with actual endpoint)

            Uri serverUri = new Uri("ws://localhost:5000/commentsync");



            using (ClientWebSocket webSocket = new ClientWebSocket())

            {

                try

                {

                    await webSocket.ConnectAsync(serverUri, CancellationToken.None);



                    string message = $"CommentId:{editedComment.Slide.SlideNumber}:{editedComment.Text}";

                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                    ArraySegment<byte> buffer = new ArraySegment<byte>(messageBytes);



                    await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

                }

                catch (WebException)

                {

                    // Handle WebSocket connection errors (e.g., server not available)

                    Console.WriteLine("WebSocket connection failed. Real-time sync unavailable.");

                }

                finally

                {

                    if (webSocket.State == WebSocketState.Open)

                    {

                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);

                    }

                }

            }

        }

    }

}


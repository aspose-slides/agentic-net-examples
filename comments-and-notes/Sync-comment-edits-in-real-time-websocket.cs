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
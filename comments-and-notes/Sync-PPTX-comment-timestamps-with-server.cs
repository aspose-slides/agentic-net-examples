// -----------------------------------------------------------------------------
// Example: Sync PPTX comment timestamps with server using C#
//
// Description:
// Demonstrates how to retrieve the current UTC time from a public time API,
// synchronize it with a comment timestamp, add a modern comment to a new
// PowerPoint presentation, and save the file using Aspose.Slides for .NET.
// The example shows HTTP request handling, fallback to local time, and basic
// presentation manipulation in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Sync, Comment, Timestamps,
// Presentation Processing, Office Automation, HttpClient, Server Time
//
// Use Cases:
// - Automate synchronization of PPTX comment timestamps with a server clock.
// - Build .NET tools that add time‑stamped comments to PowerPoint files.
// - Integrate presentation comment handling into server‑based workflows.
// - Validate and generate PPTX files with accurate comment metadata.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Retrieve server time
        DateTime serverTime;
        try
        {
            HttpClient client = new HttpClient();
            Task<string> responseTask = client.GetStringAsync("http://worldtimeapi.org/api/timezone/Etc/UTC");
            responseTask.Wait();
            string json = responseTask.Result;
            int index = json.IndexOf("\"datetime\":\"");
            if (index >= 0)
            {
                int start = index + "\"datetime\":\"".Length;
                int end = json.IndexOf('"', start);
                string datetimeStr = json.Substring(start, end - start);
                serverTime = DateTime.Parse(datetimeStr, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }
            else
            {
                serverTime = DateTime.UtcNow;
            }
        }
        catch (Exception)
        {
            // Fallback to local UTC time if server request fails
            serverTime = DateTime.UtcNow;
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add an empty slide
        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("ServerUser", "SU");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

        // Add a modern comment with the synchronized timestamp
        Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
            "Synchronized comment",
            presentation.Slides[0],
            null,
            position,
            serverTime);

        // Save the presentation
        try
        {
            presentation.Save("SynchronizedComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}

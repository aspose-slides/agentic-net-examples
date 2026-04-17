using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "VideoPlaceholder.pptx";

        // Video URL components
        string videoUrlBase = "https://www.youtube.com/embed/";
        string videoId = "Tj75Arhq5ho";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a video frame that references an external streaming URL on the first slide
        Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10f, 10f, 427f, 240f, videoUrlBase + videoId);
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

        // Attempt to download and set a thumbnail for the video
        try
        {
            System.Net.WebClient client = new System.Net.WebClient();
            string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
            byte[] imageData = client.DownloadData(thumbnailUri);
            client.Dispose();
            videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(imageData);
        }
        catch (Exception ex)
        {
            // Handle any errors while downloading the thumbnail
            Console.WriteLine("Thumbnail download failed: " + ex.Message);
        }

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}
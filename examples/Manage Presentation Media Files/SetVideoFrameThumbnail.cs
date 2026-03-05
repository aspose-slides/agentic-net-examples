using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Video identifier and base URLs
        string videoId = "Tj75Arhq5ho";
        string youtubeBaseUrl = "https://www.youtube.com/embed/";
        string thumbnailBaseUrl = "http://img.youtube.com/vi/";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a video frame that references a YouTube video
        Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(
            10, 10, 427, 240, youtubeBaseUrl + videoId);
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

        // Download thumbnail image for the video
        System.Net.WebClient client = new System.Net.WebClient();
        string thumbnailUri = thumbnailBaseUrl + videoId + "/hqdefault.jpg";
        byte[] imageData = client.DownloadData(thumbnailUri);
        client.Dispose();

        // Set the downloaded image as the video frame's thumbnail
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(imageData);

        // Save the presentation in PPTX format
        pres.Save("SetVideoFrameThumbnail_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
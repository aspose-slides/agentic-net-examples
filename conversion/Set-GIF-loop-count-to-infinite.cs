using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.FrameSize = new System.Drawing.Size(960, 720);
            gifOptions.DefaultDelay = 2000;
            gifOptions.TransitionFps = 35;
            // Infinite looping is not directly exposed via GifOptions; enable looping at presentation level
            presentation.SlideShowSettings.Loop = true;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
            presentation.Dispose();

            // Verify GIF metadata for loop count (0 indicates infinite looping)
            using (Image gifImage = Image.FromFile(outputPath))
            {
                const int PropertyTagLoopCount = 0x5100;
                PropertyItem loopProperty = null;
                try
                {
                    loopProperty = gifImage.GetPropertyItem(PropertyTagLoopCount);
                }
                catch (ArgumentException)
                {
                    // Property not found
                }

                if (loopProperty != null && loopProperty.Value.Length >= 2)
                {
                    int loopCount = BitConverter.ToUInt16(loopProperty.Value, 0);
                    Console.WriteLine("Loop count in GIF metadata: " + loopCount);
                }
                else
                {
                    Console.WriteLine("Loop count property not found in GIF metadata.");
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
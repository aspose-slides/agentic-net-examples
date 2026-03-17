using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputAudioPath = "extractedAudio.mp3";
            string outputPresentationPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                bool audioFound = false;
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        IShape shape = slide.Shapes[j];
                        IHyperlink hyperlink = shape.HyperlinkClick;
                        if (hyperlink != null && hyperlink.Sound != null)
                        {
                            byte[] audioData = hyperlink.Sound.BinaryData;
                            File.WriteAllBytes(outputAudioPath, audioData);
                            audioFound = true;
                            break;
                        }
                    }
                    if (audioFound) break;
                }

                // Save the presentation before exiting
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
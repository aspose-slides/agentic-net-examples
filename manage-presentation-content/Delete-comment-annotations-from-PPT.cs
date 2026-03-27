using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: DeleteCommentsApp <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = new Presentation(inputPath);
            try
            {
                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    IComment[] comments = slide.GetSlideComments(null);
                    for (int j = 0; j < comments.Length; j++)
                    {
                        IComment comment = comments[j];
                        comment.Remove();
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
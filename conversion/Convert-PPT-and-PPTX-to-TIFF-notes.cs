using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputFiles = new string[] { "sample.ppt", "sample.pptx" };
                foreach (string inputPath in inputFiles)
                {
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                    {
                        Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
                        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
                        options.SlidesLayoutOptions = notesOptions;

                        string outputPath = System.IO.Path.ChangeExtension(inputPath, ".tiff");
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
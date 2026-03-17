using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertExternalFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Paths to external files (adjust as needed)
            string imagePath = "sample_image.jpg";
            string audioPath = "sample_audio.mp3";
            string olePath = "sample_excel.xlsx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            try
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // ---------- Insert an external picture ----------
                // Add image to presentation resources
                IPPImage pictureImage = presentation.Images.AddImage(File.ReadAllBytes(imagePath));
                // Add picture frame to the slide
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 300, 200, pictureImage);

                // ---------- Insert a linked audio file ----------
                // Add an audio frame that links to an external file
                slide.Shapes.AddAudioFrameLinked(400, 50, 50, 50, audioPath);

                // ---------- Insert an OLE object (linked) ----------
                // Add an OLE object frame that links to an external Excel file
                slide.Shapes.AddOleObjectFrame(50, 300, 300, 200, "Excel.Sheet", olePath);

                // Save the presentation
                string outPath = Path.Combine(outDir, "ExternalFilesPresentation.pptx");
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
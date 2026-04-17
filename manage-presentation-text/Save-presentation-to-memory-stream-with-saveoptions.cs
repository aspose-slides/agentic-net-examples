using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Modify the presentation (add a rectangle with text)
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                shape.TextFrame.Text = "Modified";

                // Prepare memory stream and save options to preserve text formatting
                MemoryStream memoryStream = new MemoryStream();
                Aspose.Slides.Export.PptxOptions pptxOptions = new Aspose.Slides.Export.PptxOptions();

                // Save to memory stream with options
                presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

                // Optionally write the memory stream to a file
                byte[] outputBytes = memoryStream.ToArray();
                File.WriteAllBytes("output.pptx", outputBytes);

                // Clean up
                memoryStream.Close();
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
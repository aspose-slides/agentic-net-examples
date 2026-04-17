using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(inputPath);
            MemoryStream memoryStream = new MemoryStream(fileBytes);
            try
            {
                Presentation presentation = new Presentation(memoryStream);
                ISlide slide = presentation.Slides[0];
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape is IAutoShape)
                    {
                        ((IAutoShape)shape).TextFrame.Text = "Updated Prompt";
                    }
                }

                memoryStream.Position = 0;
                presentation.Save(memoryStream, SaveFormat.Pptx);
                // Optionally write the modified presentation to a file
                File.WriteAllBytes("output.pptx", memoryStream.ToArray());

                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                memoryStream.Close();
            }
        }
    }
}
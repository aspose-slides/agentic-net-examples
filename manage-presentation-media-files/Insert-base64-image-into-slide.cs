using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertBase64Image
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base64-encoded PNG image (example; replace with a valid string)
            string base64Image = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAn8B9pV4WQAAAABJRU5ErkJggg==";

            try
            {
                // Convert Base64 string to byte array
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add image to the presentation's image collection
                    IPPImage image = presentation.Images.AddImage(imageBytes);

                    // Insert picture frame on the first slide
                    IShapeCollection shapes = presentation.Slides[0].Shapes;
                    shapes.AddPictureFrame(ShapeType.Rectangle, 50f, 50f, 300f, 200f, image);

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (FormatException ex)
            {
                // Handle invalid Base64 string
                Console.WriteLine("Invalid Base64 string: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format
                Console.WriteLine("Format not supported: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides.Export;

namespace ShapeThumbnailExample
{
    class Program
    {
        static void Main()
        {
            // Input presentation path
            string inputPath = "example.pptx";
            // Output thumbnail image path
            string outputImagePath = "shape_thumbnail.jpg";
            // Shape identifier (OfficeInteropShapeId)
            uint shapeId = 5;
            // Scaling factors
            float scaleX = 1.0f;
            float scaleY = 1.0f;

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Get the thumbnail image for the specified shape
                Aspose.Slides.IImage thumbnail = GetShapeThumbnail(inputPath, shapeId, scaleX, scaleY);
                if (thumbnail != null)
                {
                    // Save the thumbnail as JPEG
                    thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                    thumbnail.Dispose();
                }

                // Load the presentation to save (even if unchanged) before exiting
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported.
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a thumbnail image of a shape identified by its OfficeInteropShapeId.
        /// </summary>
        /// <param name="presentationPath">Path to the presentation file.</param>
        /// <param name="shapeId">OfficeInteropShapeId of the shape.</param>
        /// <param name="scaleX">Horizontal scaling factor.</param>
        /// <param name="scaleY">Vertical scaling factor.</param>
        /// <returns>IImage thumbnail or null if shape not found.</returns>
        public static Aspose.Slides.IImage GetShapeThumbnail(string presentationPath, uint shapeId, float scaleX, float scaleY)
        {
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(presentationPath);
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.OfficeInteropShapeId == shapeId)
                        {
                            // Generate thumbnail using the specified scaling factors
                            Aspose.Slides.IImage image = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);
                            return image;
                        }
                    }
                }
                return null;
            }
            finally
            {
                // Dispose the presentation if it was created
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
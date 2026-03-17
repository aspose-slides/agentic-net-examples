using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageIntoMasterHeading
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Load image bytes once
                    byte[] imageBytes = File.ReadAllBytes("headingImage.png");
                    IPPImage image = presentation.Images.AddImage(imageBytes);

                    // Iterate through each master slide
                    IMasterSlideCollection masterSlides = presentation.Masters;
                    foreach (IMasterSlide masterSlide in masterSlides)
                    {
                        // Iterate through each layout slide of the master
                        IMasterLayoutSlideCollection layoutSlides = masterSlide.LayoutSlides;
                        foreach (ILayoutSlide layoutSlide in layoutSlides)
                        {
                            // Iterate through shapes in the layout slide
                            IShapeCollection shapes = layoutSlide.Shapes;
                            foreach (IShape shape in shapes)
                            {
                                // Check if the shape is a title (heading) placeholder
                                if (shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.Title)
                                {
                                    // Insert picture frame at the placeholder position
                                    layoutSlide.Shapes.AddPictureFrame(
                                        ShapeType.Rectangle,
                                        shape.X,
                                        shape.Y,
                                        shape.Width,
                                        shape.Height,
                                        image);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
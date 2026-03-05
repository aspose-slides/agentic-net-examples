using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PlaceholderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first layout slide
                Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides[0];

                // Add a picture placeholder to the layout slide
                Aspose.Slides.IAutoShape picturePlaceholder = layout.PlaceholderManager.AddPicturePlaceholder(20f, 20f, 200f, 200f);

                // Add a new slide based on the modified layout
                Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(layout);

                // Iterate through shapes on the slide and set text for placeholders
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                    {
                        ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Placeholder Text";
                    }
                }

                // Set footer text for all slides in the presentation
                pres.HeaderFooterManager.SetAllFootersText("My Footer");

                // Save the presentation
                pres.Save("ManagedPlaceholders_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
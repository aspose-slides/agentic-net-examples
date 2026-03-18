using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertFaqSection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths (adjust as needed)
            string inputPath = "input.pptx";
            string outputPath = "output_with_faq.pptx";

            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get a blank layout slide to maintain consistency
                Aspose.Slides.ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

                // Add a new empty slide based on the blank layout
                Aspose.Slides.ISlide faqSlide = presentation.Slides.AddEmptySlide(blankLayout);

                // Add a title shape for the FAQ section
                Aspose.Slides.IAutoShape titleShape = faqSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f,   // X position
                    20f,   // Y position
                    600f,  // Width
                    50f    // Height
                );
                // Add and set the title text
                titleShape.AddTextFrame("Frequently Asked Questions");
                // Optional: center the title text
                titleShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Add a text box shape to hold the FAQ content
                Aspose.Slides.IAutoShape faqContentShape = faqSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f,    // X position
                    80f,    // Y position
                    600f,   // Width
                    400f    // Height
                );
                // Add and populate the FAQ text
                string faqText = "Q1: How do I insert a chart?\n" +
                                 "A1: Use the Shapes.AddChart method.\n\n" +
                                 "Q2: How can I add a picture?\n" +
                                 "A2: Use the Shapes.AddPictureFrame method.\n\n" +
                                 "Q3: How do I format text?\n" +
                                 "A3: Access the TextFrame and modify its Paragraphs and Portions.";
                faqContentShape.AddTextFrame(faqText);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Ensure a Title layout exists
            Aspose.Slides.ILayoutSlide titleLayout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
            if (titleLayout == null)
            {
                titleLayout = presentation.LayoutSlides.Add(masterSlide, Aspose.Slides.SlideLayoutType.Title, "Title Layout");
            }

            // Insert the first slide using the Title layout
            presentation.Slides.InsertEmptySlide(0, titleLayout);
            Aspose.Slides.ISlide faqSlide = presentation.Slides[0];

            // Set the title text
            if (faqSlide.Shapes[0] is Aspose.Slides.IAutoShape titleShape)
            {
                titleShape.TextFrame.Text = "Frequently Asked Questions";
            }

            // Ensure a Title and Object layout exists for content slides
            Aspose.Slides.ILayoutSlide contentLayout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
            if (contentLayout == null)
            {
                contentLayout = presentation.LayoutSlides.Add(masterSlide, Aspose.Slides.SlideLayoutType.TitleAndObject, "Content Layout");
            }

            // FAQ data
            string[] questions = new string[]
            {
                "What is Aspose.Slides?",
                "How to create a presentation?",
                "How to add a chart?"
            };

            string[] answers = new string[]
            {
                "Aspose.Slides is a .NET library for working with PowerPoint files.",
                "Instantiate the Presentation class and use its API to add slides.",
                "Use the Charts collection on a slide to add and configure charts."
            };

            // Add a slide for each FAQ entry
            for (int i = 0; i < questions.Length; i++)
            {
                // Insert a new empty slide at the end using the content layout
                presentation.Slides.InsertEmptySlide(presentation.Slides.Count, contentLayout);
                Aspose.Slides.ISlide slide = presentation.Slides[presentation.Slides.Count - 1];

                // Set the question as the title
                if (slide.Shapes[0] is Aspose.Slides.IAutoShape questionShape)
                {
                    questionShape.TextFrame.Text = questions[i];
                }

                // Set the answer as the content (second placeholder)
                if (slide.Shapes.Count > 1 && slide.Shapes[1] is Aspose.Slides.IAutoShape answerShape)
                {
                    answerShape.TextFrame.Text = answers[i];
                }
            }

            // Save the presentation
            presentation.Save("FAQPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
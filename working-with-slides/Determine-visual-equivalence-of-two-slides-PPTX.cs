using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the presentations to compare
                string presentationPath1 = "Presentation1.pptx";
                string presentationPath2 = "Presentation2.pptx";

                // Load the first presentation
                using (Aspose.Slides.Presentation presentation1 = new Aspose.Slides.Presentation(presentationPath1))
                {
                    // Load the second presentation
                    using (Aspose.Slides.Presentation presentation2 = new Aspose.Slides.Presentation(presentationPath2))
                    {
                        // Get the first slide from each presentation
                        Aspose.Slides.ISlide slide1 = presentation1.Slides[0];
                        Aspose.Slides.ISlide slide2 = presentation2.Slides[0];

                        // Compare the slides using the Equals method defined on BaseSlide/IBaseSlide
                        bool slidesAreEqual = slide1.Equals(slide2);

                        // Output the comparison result
                        Console.WriteLine("Slides are equal: " + slidesAreEqual);

                        // Save the presentations before exiting
                        presentation1.Save("Presentation1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                        presentation2.Save("Presentation2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
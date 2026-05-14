using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to source and destination presentations
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation srcPres = new Presentation(sourcePath))
                {
                    // Create destination presentation (empty)
                    using (Presentation destPres = new Presentation())
                    {
                        // Clone the first slide from source to destination
                        ISlide sourceSlide = srcPres.Slides[0];
                        ISlide clonedSlide = destPres.Slides.AddClone(sourceSlide);

                        // Rename the title shape text if it exists
                        foreach (IShape shape in clonedSlide.Shapes)
                        {
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null && autoShape.Placeholder != null && autoShape.Placeholder.Type == PlaceholderType.Title)
                            {
                                autoShape.TextFrame.Text = "New Title for Cloned Slide";
                                break;
                            }
                        }

                        // Save the destination presentation
                        destPres.Save(destinationPath, SaveFormat.Pptx);
                    }
                }

                Console.WriteLine("Slide cloned and title renamed successfully.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
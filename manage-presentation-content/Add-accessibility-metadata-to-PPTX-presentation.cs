using System;
using System.IO;
using Aspose.Slides.Export;

namespace AccessibilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_accessible.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Check presentation protection without loading the full presentation
            Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
            bool isWriteProtected = presentationInfo.IsWriteProtected == Aspose.Slides.NullableBool.True;
            bool isPasswordProtected = presentationInfo.IsPasswordProtected;

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // If the presentation is write-protected, attempt to remove protection (example password)
                if (isWriteProtected)
                {
                    string writePassword = "writePass"; // replace with actual password if known
                    bool isCorrect = presentationInfo.CheckWriteProtection(writePassword);
                    if (isCorrect)
                    {
                        presentation.ProtectionManager.RemoveWriteProtection();
                    }
                }

                // Set read-only recommendation to aid accessibility
                presentation.ProtectionManager.ReadOnlyRecommended = true;

                // Access and set built-in document properties for accessibility metadata
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
                docProps.Title = "Accessible Presentation";
                docProps.Subject = "Demonstrates accessibility features";
                docProps.Author = "Accessibility Team";
                docProps.Comments = "Presentation prepared with accessibility compliance";

                // Add alternative text to all shapes on each slide
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        shape.AlternativeText = "Descriptive text for shape";
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
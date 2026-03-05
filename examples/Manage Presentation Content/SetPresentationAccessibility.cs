using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Recommend the file as read‑only
            presentation.ProtectionManager.ReadOnlyRecommended = true;

            // Apply write protection with a password
            presentation.ProtectionManager.SetWriteProtection("writePass123");

            // Encrypt the presentation with a password
            presentation.ProtectionManager.Encrypt("encryptPass123");

            // Save the presentation before exiting
            presentation.Save("AccessiblePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
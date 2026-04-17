using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Data to encrypt
        string plainText = "Sensitive data";
        string password = "StrongPassword123";

        // AES encryption
        byte[] encryptedBytes;
        byte[] iv;
        using (Aes aes = Aes.Create())
        {
            aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            aes.GenerateIV();
            iv = aes.IV;
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
        }

        // Combine IV and encrypted data
        byte[] combined = new byte[iv.Length + encryptedBytes.Length];
        Buffer.BlockCopy(iv, 0, combined, 0, iv.Length);
        Buffer.BlockCopy(encryptedBytes, 0, combined, iv.Length, encryptedBytes.Length);
        string encryptedBase64 = Convert.ToBase64String(combined);

        // Create presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a textbox with encrypted data
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        shape.TextFrame.Text = encryptedBase64;

        // Encrypt presentation
        presentation.ProtectionManager.EncryptDocumentProperties = false;
        presentation.ProtectionManager.Encrypt(password);

        // Save presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EncryptedPresentation.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace Blazor_Barcodes.ViewModels
{
    public class BarCodeViewModel
    {
        public bool Opened { get; set; } = false;
        public string InputText { get; set; } = "";
        public string QRCodeStr { get; set; }
        public BarCodeViewModel()
        {
            
        }

        public void CreateQRCode()
        {
            if (!string.IsNullOrWhiteSpace(InputText))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator codeGenerator = new QRCodeGenerator();
                    QRCodeData data = codeGenerator.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.H);
                    QRCode qrCode = new QRCode(data);
                    using (Bitmap bitmap = qrCode.GetGraphic(20))
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        QRCodeStr = $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
                    }
                }
            }
        }
        
    }
}

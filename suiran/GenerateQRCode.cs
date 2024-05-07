using QRCoder;
namespace suiran;

public static class GenerateQRCode
{
    public static string GenerateQR(string input)
    {
        QRCodeGenerator qrGenerator = new();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.M);
        PngByteQRCode qrCode = new(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);
        var qrString = "data:image/png;base64," + Convert.ToBase64String(qrCodeImage.ToArray());
        return qrString;
    }
}

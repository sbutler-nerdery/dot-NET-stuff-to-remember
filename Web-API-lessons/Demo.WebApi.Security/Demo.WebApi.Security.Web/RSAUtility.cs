using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Demo.WebApi.Security.Web
{
    public class RSAUtility
    {
        private static string _privateKey = "<RSAKeyValue><Modulus>3xT8KbVcGK44aKMV+xLc4ZQNTKVg4B9gTVaAqly+iVseQUOFXS0yLTQEubttN9SAk+ZFhb0IyrW8bPh1SZvgJX6gFLrr3jX/V9xmAGTD1YV0M8S0sfQ+4d/hw/jvpWnTVSX/y03dLC9KzT56UB6OzTXuQ4iIT6UGlcehC/YrgZ0=</Modulus><Exponent>AQAB</Exponent><P>9F0QY/2HrSkj6TFUFEELHCQlZ1EMYPuzhX0cd3dzjsHfi0jNMKZrM35BGRCoqhybLwFrr8axxTTmtNRsiz7XBQ==</P><Q>6bR8d4hMUtNCjUV9Pi1EjetLVShMmAcDLGOePENTpy/u75CBPwq1ww2hBbjinaZDI8Vqd9NojPE4pOOltLXTuQ==</Q><DP>s+NSrpkz6PhxNDiZEbP0Lso5Mr6KY1bHiExayWOJER2Np+Z3DwpjvmuCFqaZ02jtoIPmN2cI9QkFkTcTlMo01Q==</DP><DQ>TiuZql3DsbyKOTiyELcRhCrc0soc/Ijz7cgQaHXYqEZnNGhwYsbRT0Hix0g1PKgdMvzYhOYIxYP1/2lJxu0+uQ==</DQ><InverseQ>M9nkTO5ibpHbDbsMrGsHUb1CzmttiS5xbZwRtEE7AszhKkMdzVTzDB5CwzO5tY1d5pi9iVwB3ruPo87Dizh1FQ==</InverseQ><D>w5eNpDAcSJNwZ+Yd3p5iRfJeWsZhkwBPml9uvnBEqv/WHhjKdLCs3s9OGV7I2vuZpJNwf1sHu1vukoihpWFi+znJ3j20JN3IZMkgFmB31b5PsWSlTFYzIhTa2brxKKXKZh3nx/GwIkKluld10JAYDCLkLdWf5eb9YTjq3Q6zNGE=</D></RSAKeyValue>";
        private static string _publicKey = "<RSAKeyValue><Modulus>3xT8KbVcGK44aKMV+xLc4ZQNTKVg4B9gTVaAqly+iVseQUOFXS0yLTQEubttN9SAk+ZFhb0IyrW8bPh1SZvgJX6gFLrr3jX/V9xmAGTD1YV0M8S0sfQ+4d/hw/jvpWnTVSX/y03dLC9KzT56UB6OzTXuQ4iIT6UGlcehC/YrgZ0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        public static string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        public static string Encrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_publicKey);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }
    }
}


using System;

namespace Blend.IT.CrossCutting.Util
{
    public static class StringExtension
    {
        /// <summary>
        /// Passar a url "Suja"
        /// </summary>
        /// <param name="urlSuja"></param>
        /// <returns></returns>
        public static string LimparUrl(this string urlSuja)
        {
            string urlLimpa = string.Empty;

            urlLimpa = urlSuja.Replace("?", "").Replace(" ", "-").Replace("'", "")
                .Replace("\"", "").Replace(".", "").Replace("!", "").Replace(",", "")
                .Replace(":", "").Replace("/", "-").Replace("ø", "").Replace("(", "")
                .Replace(")", "").Replace("¥", "").Replace("`", "").Replace("∫", "")
                .Replace("™", "").Replace(";", "").Replace("°", "").Replace("%", "")
                .Replace("&", "-e-").Replace("---", "-").Replace("--", "-");

            return urlLimpa;
        }

        /// <summary>
        /// Remove acentuaÁ„o da string
        /// </summary>
        /// <param name="palavra"></param>
        /// <returns></returns>
        public static string TirarAcento(this string palavra)
        {
            string palavraSemAcento = "";
            string caracterComAcento = "·‡„‚‰ÈËÍÎÌÏÓÔÛÚıÙˆ˙˘˚¸Á¡¿√¬ƒ…» ÀÕÃŒœ”“’÷‘⁄Ÿ€‹«—Ò";
            string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUCNn";

            if (palavra != null)
            {

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                    {
                        int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                        palavraSemAcento += caracterSemAcento.Substring(car, 1);
                    }
                    else
                    {
                        palavraSemAcento += palavra.Substring(i, 1);
                    }
                }
            }

            return palavraSemAcento;
        }
    }
}

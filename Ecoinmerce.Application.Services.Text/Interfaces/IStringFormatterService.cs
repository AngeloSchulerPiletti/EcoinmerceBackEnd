namespace Ecoinmerce.Application.Services.Text.Interfaces
{
    public interface IStringFormatterService
    {
        /// <summary>
        /// Formats a string to only numbers, non-accented letters and hyphen <br/>
        /// Example: <br/>
        /// INPUT: Maçã do amor. A máxima da branca de neve. COD.1265 <br/>
        /// OUTPUT: maca-do-amor-a-maxima-da-branca-de-neve-cod1265
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string FormatLowerNeutralString(string str);

        /// <summary>
        /// Removes the words accents. <br/>
        /// Example: ç => c | ã => a | Ô => O 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string RemoveAccent(string str);
    }
}

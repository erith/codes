    /// <summary>
    /// 구분자로 join, split을 하고, escape문자를 지원합니다.
    /// character.
    /// </summary>
    public static class DelimiterStringHelper
    {
        const string DELIMITER_STR = ",";
        const char DELIMITER_CHAR = ',';

        // 이스케이프 문자로 하나의 \ (역슬래시)를 사용하고, 소스 코드에서 모든 이스케이프 문자를 이스케이프 처리해야 하는 / (역슬래시)를 피하세요.
        const char ESCAPE_CHAR = '\\';
        const string ESCAPE_STR = "\\";

        /// <summary>
        /// 문자열을 구분자(delimiter)로 결합하고 문자열 내에서 구분자와 이스케이프(escape) 문자의 발생을 방지하기 위해 이스케이프 처리를 합니다.
        /// </summary>
        /// <param name="strings">Strings to join</param>
        /// <returns>Joined string</returns>
        public static string Join(params string[] strings)
        {
            return string.Join(
              DELIMITER_STR,
              strings.Select(
                s => s
                .Replace(ESCAPE_STR, ESCAPE_STR + ESCAPE_STR)
                .Replace(DELIMITER_STR, ESCAPE_STR + DELIMITER_STR)));
        }

        /// <summary>
        /// 문자열을 구분자(delimiter)로 나누되, 만약 구분자 문자가 이스케이프 처리되었다면 그를 고려하여 나눕니다
        /// </summary>
        /// <param name="source">Joined string from <see cref="Join(string[])"/></param>
        /// <returns>Unescaped, split strings</returns>
        public static string[] Split(string source)
        {
            var result = new List<string>();

            int segmentStart = 0;
            for (int i = 0; i < source.Length; i++)
            {
                bool readEscapeChar = false;
                if (source[i] == ESCAPE_CHAR)
                {
                    readEscapeChar = true;
                    i++;
                }

                if (!readEscapeChar && source[i] == DELIMITER_CHAR)
                {
                    result.Add(UnEscapeString(
                      source.Substring(segmentStart, i - segmentStart)));
                    segmentStart = i + 1;
                }

                if (i == source.Length - 1)
                {
                    result.Add(UnEscapeString(source.Substring(segmentStart)));
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// 문자열 Escape 처리
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        static string UnEscapeString(string src)
        {
            return src.Replace(ESCAPE_STR + DELIMITER_STR, DELIMITER_STR)
              .Replace(ESCAPE_STR + ESCAPE_STR, ESCAPE_STR);
        }
    }

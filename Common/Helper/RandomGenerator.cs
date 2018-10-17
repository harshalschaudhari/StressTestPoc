using System;
using System.Linq;

namespace StressTestPoc.Common.Helper {
    public class RandomGenerator {

        public static string RandomString(int length = 8) {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomNumber(int min = 1, int max = 9) {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string FileToBase64String(string filePath) {
            string fileContent = string.Empty;
            try {
                Byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                fileContent = Convert.ToBase64String(bytes);
            } catch(Exception Ex) {
                Console.WriteLine(string.Format("Stress Test Error: {0}", Ex.Message));
            }
            return fileContent;
        }

        public static DateTime UnixTimeStampToDateTime() {
            double unixTimeStamp = GetUnixTimeStamp();
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Get Unix timestamp is seconds past epoch
        /// </summary>
        /// <returns></returns>
        public static double GetUnixTimeStamp() {
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            return t.TotalSeconds;
        }
    }
}

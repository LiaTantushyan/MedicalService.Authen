using System.Text;

namespace MedicalService.Authen.Helpers
{
    public static class TextGenerator
    {
        private const string Chars = "[|`~ABCDEFGHIJKLMNOPQRSTUVWXYZ^&*()_-+>0123456789!@#$%abcdefghijklmnopqrstuvwxyz.<,/?'}]{";

        public static string GenerateRandomText(int length = 12)
        {
            var random = new Random();
            var builder = new StringBuilder();
            var usedCharIndexes = new List<int>();

            while (length > 0)
            {
                var charIndex = 0;
                while (usedCharIndexes.Count(i => i == charIndex) >= 2)
                {
                    charIndex = random.Next(0, Chars.Length);
                }

                builder.Append(Chars[charIndex]);
                usedCharIndexes.Add(charIndex);
                length--;
            }

            return builder.ToString();
        }
    }
}

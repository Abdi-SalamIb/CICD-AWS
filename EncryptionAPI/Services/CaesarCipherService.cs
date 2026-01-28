namespace EncryptionAPI.Services
{
    public class CaesarCipherService : ICryptoService
    {
        // Svenska alfabetet (29 bokstäver)
        private const string SwedishAlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
        private const string SwedishAlphabetLower = "abcdefghijklmnopqrstuvwxyzåäö";
        private const int AlphabetLength = 29;

        public string Encrypt(string text, int shift)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                // Kontrollera svenska versaler
                int upperIndex = SwedishAlphabetUpper.IndexOf(letter);
                if (upperIndex != -1)
                {
                    int newIndex = ((upperIndex + shift) % AlphabetLength
                                   + AlphabetLength) % AlphabetLength;
                    buffer[i] = SwedishAlphabetUpper[newIndex];
                    continue;
                }

                // Kontrollera svenska gemener
                int lowerIndex = SwedishAlphabetLower.IndexOf(letter);
                if (lowerIndex != -1)
                {
                    int newIndex = ((lowerIndex + shift) % AlphabetLength
                                   + AlphabetLength) % AlphabetLength;
                    buffer[i] = SwedishAlphabetLower[newIndex];
                }

                // Övriga tecken förblir oförändrade
            }

            return new string(buffer);
        }

        public string Decrypt(string text, int shift)
        {
            return Encrypt(text, -shift);
        }
    }
}

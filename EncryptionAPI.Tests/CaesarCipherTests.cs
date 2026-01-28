using Xunit;
using EncryptionAPI.Services;

namespace EncryptionAPI.Tests
{
    public class CaesarCipherTests
    {
        private readonly CaesarCipherService _service;

        public CaesarCipherTests()
        {
            _service = new CaesarCipherService();
        }

        [Fact]
        public void Encrypt_WithShift3_ReturnsCorrectResult()
        {
            // Förbered
            string input = "ABC";
            int shift = 3;

            // Agera
            string result = _service.Encrypt(input, shift);

            // Kontrollera
            Assert.Equal("DEF", result);
        }

        [Fact]
        public void Decrypt_WithShift3_ReturnsCorrectResult()
        {
            // Förbered
            string input = "DEF";
            int shift = 3;

            // Agera
            string result = _service.Decrypt(input, shift);

            // Kontrollera
            Assert.Equal("ABC", result);
        }

        [Fact]
        public void Encrypt_ThenDecrypt_ReturnsOriginalText()
        {
            // Förbered
            string original = "Hej Världen";
            int shift = 5;

            // Agera
            string encrypted = _service.Encrypt(original, shift);
            string decrypted = _service.Decrypt(encrypted, shift);

            // Kontrollera
            Assert.Equal(original, decrypted);
        }

        [Fact]
        public void Encrypt_WithEmptyString_ReturnsEmptyString()
        {
            // Förbered
            string input = "";
            int shift = 3;

            // Agera
            string result = _service.Encrypt(input, shift);

            // Kontrollera
            Assert.Equal("", result);
        }

        [Fact]
        public void Encrypt_PreservesNonLetterCharacters()
        {
            // Förbered
            string input = "Hej, Världen! 123";
            int shift = 3;

            // Agera
            string result = _service.Encrypt(input, shift);

            // Kontrollera - H->K, e->h, j->m, V->Y, ä->ö, osv.
            Assert.Equal("Khm, Ybuoghq! 123", result);
        }

        [Fact]
        public void Encrypt_HandlesSwedishCharacters()
        {
            // Förbered - Testa Å, Ä, Ö
            string input = "ÅÄÖ";
            int shift = 1;

            // Agera
            string result = _service.Encrypt(input, shift);

            // Kontrollera - Å->Ä, Ä->Ö, Ö->A (varv runt)
            Assert.Equal("ÄÖA", result);
        }

        [Fact]
        public void Encrypt_HandlesWrapAround()
        {
            // Förbered - Ö är sista bokstaven, shift 1 ska bli A
            string input = "Ö";
            int shift = 1;

            // Agera
            string result = _service.Encrypt(input, shift);

            // Kontrollera
            Assert.Equal("A", result);
        }

        [Fact]
        public void Decrypt_HandlesSwedishCharacters()
        {
            // Förbered
            string input = "ÄÖA";
            int shift = 1;

            // Agera
            string result = _service.Decrypt(input, shift);

            // Kontrollera
            Assert.Equal("ÅÄÖ", result);
        }
    }
}

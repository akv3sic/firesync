using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace FireSync.Helpers
{
    /// <summary>
    /// Provides functionality to generate random passwords.
    /// </summary>
    public static class PasswordGenerator
    {
        private static readonly char[] AllowedChars = "23456789BCDFGHJKMNPQRTVWXYbcdfghjkmnpqrtvwxy".ToCharArray();
        private static readonly char[] SpecialChars = "!@#$%^&*".ToCharArray();
        private static readonly int PasswordLength = 8;

        /// <summary>
        /// Generates a random password containing at least one non-alphanumeric character.
        /// </summary>
        /// <returns>A randomly generated password.</returns>
        public static string GeneratePassword()
        {
            return GetRandomPassword() + "1a!A"; // This is a temp fix to ensure password complexity
        }

        /// <summary>
        /// Creates a random password string.
        /// </summary>
        /// <returns>A randomly generated password string.</returns>
        private static string GetRandomPassword()
        {
            return string.Create(PasswordLength, 0, (buffer, _) =>
            {
                for (int i = 0; i < PasswordLength - 1; i++)
                {
                    buffer[i] = GetRandomAllowedChar();
                }

                // Ensure at least one special character is included
                buffer[PasswordLength - 1] = GetRandomSpecialChar();
            });
        }

        /// <summary>
        /// Gets a random character from the allowed alphanumeric characters.
        /// </summary>
        /// <returns>A randomly selected alphanumeric character.</returns>
        private static char GetRandomAllowedChar()
        {
            uint range = (uint)AllowedChars.Length;
            uint mask = range - 1;

            while ((mask & (mask + 1)) != 0)
            {
                mask |= mask >> 1;
            }

            Span<uint> resultBuffer = stackalloc uint[1];
            uint result;

            do
            {
                RandomNumberGenerator.Fill(MemoryMarshal.AsBytes(resultBuffer));
                result = mask & resultBuffer[0];
            }
            while (result >= range);

            return AllowedChars[(int)result];
        }

        /// <summary>
        /// Gets a random character from the allowed special characters.
        /// </summary>
        /// <returns>A randomly selected special character.</returns>
        private static char GetRandomSpecialChar()
        {
            uint range = (uint)SpecialChars.Length;
            uint mask = range - 1;

            while ((mask & (mask + 1)) != 0)
            {
                mask |= mask >> 1;
            }

            Span<uint> resultBuffer = stackalloc uint[1];
            uint result;

            do
            {
                RandomNumberGenerator.Fill(MemoryMarshal.AsBytes(resultBuffer));
                result = mask & resultBuffer[0];
            }
            while (result >= range);

            return SpecialChars[(int)result];
        }
    }
}

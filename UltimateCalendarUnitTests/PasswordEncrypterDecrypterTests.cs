using System;
using UltimateCalendar.Models;
using NUnit.Framework;
using NUnit;

namespace UltimateCalendarUnitTests
{
    [TestFixture]
    public class PasswordEncrypterDecrypterTests
    {
        [TestCase("abcde", "fghij")]
        public void Encrypt_SomePassword_ExpectedResult(string passwordToEncrypt, string ExpectedResult)
        {
            //arrange
            var encrypter = new PasswordEncrypter();

            //act
            var result = encrypter.encryptPassword(passwordToEncrypt);

            //assert
            Assert.AreEqual(ExpectedResult,result);
        }

        [TestCase("fghij", "abcde")]
        public void Decrypt_SomePassword_ExpectedResult(string passwordToDecrypt, string ExpectedResult)
        {
            //arrange
            var decrypter = new PasswordDecrypter();

            //act
            var result = decrypter.decryptPassword(passwordToDecrypt);

            //assert
            Assert.AreEqual(ExpectedResult, result);
        }
    }
}

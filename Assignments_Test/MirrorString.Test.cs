using System;
using MirrorString;
using NUnit.Framework;
using Shouldly;


namespace Assignments_Test
{
    [TestFixture]
    public class MirrorStringTest
    {
        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public void GivenNullOrEmptyOrWhiteSpace_ShouldReturnEmptyResult(string input)
        {
            //Arr
            Solution solution = new Solution();

            //Act
            var result = solution.MirrorString(input);

            //Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void GivenInputOnlyOneChar_ShouldReturnEmptyResult()
        {
            //Arr
            string input = "a";
            Solution solution = new Solution();

            //Act
            var result = solution.MirrorString(input);

            //Assert
            Assert.AreEqual("", result);
            Assert.AreEqual(1, input.Length);
        }

        [Test]
        [TestCase("ABC")]
        [TestCase("ABa")]
        [TestCase("AAD")]
        [TestCase("aBA")]
        public void GivenInputWithDifferentHeadAndTailInTheBeginning_ShouldReturnEmptyResult(string input)
        {
            //Arr
            Solution solution = new Solution();

            //Act
            var result = solution.MirrorString(input);

            //Assert
            Assert.AreEqual("", result);
        }

        [Test]
        [TestCase(new object[] { "xyzABCDFzyx", "xyz" })]
        [TestCase(new object[] { "XYZabcdefZYX", "XYZ" })]
        [TestCase(new object[] { "aXYZa", "a" })]
        [TestCase(new object[] { "aaYaa", "aa" })]
        [TestCase(new object[] { "aaaaa", "aa" })]
        [TestCase(new object[] { "aaaaaa", "aaa" })]
        [TestCase(new object[] { "XaYaX", "Xa" })]
        [TestCase(new object[] { "X   X", "X " })]
        [TestCase(new object[] { "XX", "X" })]
        [TestCase(new object[] { " XX ", " X" })]
        [TestCase(new object[] { " X A X ", " X " })]
        [TestCase(new object[] { " X ABA X ", " X A" })]
        [TestCase(new object[] { " X A b A X ", " X A " })]
        public void GivenMirrorStringInput_ShouldReturnExpectedResult(string input, string expectedResult)
        {
            //Arr
            Solution solution = new Solution();

            //Act
            var result = solution.MirrorString(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

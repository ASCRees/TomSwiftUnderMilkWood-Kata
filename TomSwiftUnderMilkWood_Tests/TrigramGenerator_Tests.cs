namespace TomSwiftUnderMilkWood.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using TomSwiftUnderMilkWood.Interfaces;

    [TestFixture()]
    public class TrigramGenerator_Tests
    {
        ITrigramGenerator trigram;
        string startingString = "I wish I may I wish I might";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            trigram = new TrigramGenerator();
        }

        [Test]
        public void Test_BuildTrigram()
        {

            // Act
            var resultDictionary = trigram.BuildTrigram(startingString);

            // Assert
            resultDictionary.Count.Should().BeGreaterThan(0);
        }



        [Test]
        public void Test_FindWords_First_Word_Key()
        {

            // Act
            var resultTuple = trigram.FindWords(startingString,0);

            // Assert
            resultTuple.key.Should().Be("I wish");
        }

        [Test]
        public void Test_FindWords_First_Words_Value()
        {
            // Act
            var resultTuple = trigram.FindWords(startingString, 0);

            // Assert
            resultTuple.value.Should().Be("I");
        }

        [Test]
        public void Test_FindWords_First_Last_Two_Words()
        {

            // Act
            var resultTuple = trigram.FindWords(startingString, 7);

            // Assert
            resultTuple.key.Should().Be(string.Empty);

        }




    }
}

using SharedLibrary.Exceptions;

namespace UnitTests.SharedLibraryTests
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void ErrorMessage_MessageIsCorrect()
        {
            ErrorMessage errorMessage = new ErrorMessage("Test");

            Assert.That(errorMessage.Message == "Test");
        }

        [Test]
        public void GameFullException_MessageIsCorrect()
        {
            GameFullException exception = new GameFullException();

            Assert.That(exception.Message == "Game is full!");
        }

        [Test]
        public void GameNotFound_MessageIsCorrect()
        {
            GameNotFoundException exception = new GameNotFoundException();

            Assert.That(exception.Message == "Game not found!");
        }

        [Test]
        public void InvalidPasswordException_MessageIsCorrect()
        {
            InvalidPasswordException exception = new InvalidPasswordException();

            Assert.That(exception.Message == "Invalid password!");
        }

        [Test]
        public void ServerNameTakenException_MessageIsCorrect()
        {
            ServerNameTakenException exception = new ServerNameTakenException();

            Assert.That(exception.Message == "Server name taken!");
        }
    }
}

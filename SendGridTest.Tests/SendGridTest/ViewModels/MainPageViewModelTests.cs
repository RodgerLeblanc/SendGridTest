using SendGridTest.ViewModels;
using Xunit;

namespace SendGridTest.Tests.SendGridTest.ViewModels
{
    /// <summary>
    /// MainPageViewModelTests
    /// </summary>
    public class MainPageViewModelTests
    {
        /// <summary>
        /// Private reference to an empty MainPageViewModel being tested
        /// </summary>
        private MainPageViewModel _viewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPageViewModelTests()
        {
            _viewModel = new MainPageViewModel();
        }

        [Fact]
        public void ToSubjectAndBody_NotEmpty_MustBeAbleToCallSendEmailCommand()
        {
            //Arrange

            //Act
            _viewModel.To = "to";
            _viewModel.Subject = "subject";
            _viewModel.Body = "body";

            //Assert
            Assert.True(_viewModel.SendEmailCommand.CanExecute(null));
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("", "", "body")]
        [InlineData("", "subject", "body")]
        [InlineData("to", "", "")]
        [InlineData("to", "subject", "")]
        [InlineData("to", "", "body")]
        [InlineData("", "subject", "")]
        public void ToSubjectAndBody_WhenAnyEmpty_MustNotBeAbleToCallSendEmailCommand(string to, string subject, string body)
        {
            //Arrange

            //Act
            _viewModel.To = to;
            _viewModel.Subject = subject;
            _viewModel.Body = body;

            //Assert
            Assert.False(_viewModel.SendEmailCommand.CanExecute(null));
        }
    }
}

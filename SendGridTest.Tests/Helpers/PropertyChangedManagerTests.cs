using Moq;
using SendGridTest.Helpers;
using SendGridTest.ViewModels;
using System;
using Xunit;

namespace SendGridTest.Tests.Helpers
{
    /// <summary>
    /// PropertyChangedManagerTests
    /// </summary>
    public class PropertyChangedManagerTests
    {
        [Fact]
        public void AddPropertyChanged_WhenCalledWithNullCallback_ShouldThrowArgumentNullException()
        {
            //Arrange
            Mock<PropertyChangedManager<BaseViewModel>> mock = new Mock<PropertyChangedManager<BaseViewModel>>();

            //Act
            Action invalidAction = () => mock.Object.AddPropertyChanged(vm => vm.Title, null);

            //Assert
            Assert.Throws<ArgumentNullException>(invalidAction);
        }

        [Fact]
        public void AddPropertyChanged_WhenCalledWithExpressionToMethod_ShouldThrowInvalidOperationException()
        {
            //Arrange
            Mock<PropertyChangedManager<BaseViewModel>> mock = new Mock<PropertyChangedManager<BaseViewModel>>();

            //Act
            Action invalidAction = () => mock.Object.AddPropertyChanged(vm => vm.ToString(), (s, e) => { });

            //Assert
            Assert.Throws<InvalidOperationException>(invalidAction);
        }

        [Fact]
        public void AddPropertyChanged_WhenCalledWithExpressionToNew_ShouldThrowInvalidOperationException()
        {
            //Arrange
            Mock<PropertyChangedManager<BaseViewModel>> mock = new Mock<PropertyChangedManager<BaseViewModel>>();

            //Act
            Action invalidAction = () => mock.Object.AddPropertyChanged(vm => new { }, (s, e) => { });

            //Assert
            Assert.Throws<InvalidOperationException>(invalidAction);
        }
    }
}

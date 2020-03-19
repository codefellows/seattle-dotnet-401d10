using System;
using Xunit;
using UnitTestingReview;

namespace XUnitTestProject1
{

    public class UnitTest1
    {
        [Fact]
        public void ArrayIsPopulated()
        {
            // We are going to make a call out to the populate method and make sure
            // that the array populated is the same length as the number we sent it. 

            // Arrange & Act
            int arraySize = 7;
            int[] myArray = Program.Populate(arraySize);

            // Assert
            Assert.Equal(arraySize, myArray.Length);
            Assert.NotEmpty(myArray);
        }

        [Fact]
        public void CanChangeValuesInArray()
        {
            int arraySize = 5;
            int[] myArray = Program.Populate(arraySize);
            int[] answer = Program.ChangeValue(4, 123, myArray);
            Assert.Equal(123, answer[4]);

        }
    }
}

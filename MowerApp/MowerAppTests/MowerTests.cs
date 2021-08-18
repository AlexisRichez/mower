using MowerApp.Models;

using NUnit.Framework;

namespace MowerAppTests
{
    public class MowerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckMowerOrientation_WhenChangeToRight()
        {
            //Arrange
            var initialMowerLocation = new Location
            {
                Orientation = Orientation.N,
                Position = new Position
                {
                    X = 0,
                    Y = 0
                }
            };

            var mower = new Mower(initialMowerLocation);

            //Act
            mower.ToRight();
            //Assert
            Assert.AreEqual(Orientation.E, mower.Location.Orientation);

            //Act
            mower.ToRight();
            //Assert
            Assert.AreEqual(Orientation.S, mower.Location.Orientation);

            //Act
            mower.ToRight();
            //Assert
            Assert.AreEqual(Orientation.W, mower.Location.Orientation);

            //Act
            mower.ToRight();
            //Assert
            Assert.AreEqual(Orientation.N, mower.Location.Orientation);
        }

        [Test]
        public void CheckMowerOrientation_WhenChangeToLeft()
        {
            //Arrange
            var initialMowerLocation = new Location
            {
                Orientation = Orientation.N,
                Position = new Position
                {
                    X = 0,
                    Y = 0
                }
            };

            var mower = new Mower(initialMowerLocation);

            //Act
            mower.ToLeft();
            //Assert
            Assert.AreEqual(Orientation.W, mower.Location.Orientation);

            //Act
            mower.ToLeft();
            //Assert
            Assert.AreEqual(Orientation.S, mower.Location.Orientation);

            //Act
            mower.ToLeft();
            //Assert
            Assert.AreEqual(Orientation.E, mower.Location.Orientation);

            //Act
            mower.ToLeft();
            //Assert
            Assert.AreEqual(Orientation.N, mower.Location.Orientation);
        }
    }
}
using System.Collections.Generic;

using MowerApp.Models;

using NUnit.Framework;

namespace MowerAppTests
{
    public class MowerManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetFinalMowerPosition_WhenBottomLimitIsReached()
        {
            //Arrange
            var configuration = new Configuration
            {
                Surface = new SurfaceConfiguration
                {
                    TopRightLimit = new Position
                    {
                        X = 5,
                        Y = 5
                    }
                },
                Mowers = new System.Collections.Generic.List<MowerConfiguration>()
            };

            configuration.Mowers.Add(new MowerConfiguration
            {
                Location = new Location
                {
                    Orientation = Orientation.S,
                    Position = new Position
                    {
                        X = 0,
                        Y = 0
                    }
                },
                Movements = new List<Movement>
                {
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F
                }
            });

            var manager = new MowerApp.MowerManager(configuration);

            //Act
            manager.Run();

            //Assert
            Assert.AreEqual(1, manager.Mowers.Count);
            Assert.AreEqual(0, manager.Mowers[0].Location.Position.X);
            Assert.AreEqual(0, manager.Mowers[0].Location.Position.Y);
        }

        [Test]
        public void GetFinalMowerPosition_WhenLeftBottomLimitIsReached()
        {
            //Arrange
            var configuration = new Configuration
            {
                Surface = new SurfaceConfiguration
                {
                    TopRightLimit = new Position
                    {
                        X = 5,
                        Y = 5
                    }
                },
                Mowers = new System.Collections.Generic.List<MowerConfiguration>()
            };

            configuration.Mowers.Add(new MowerConfiguration
            {
                Location = new Location
                {
                    Orientation = Orientation.W,
                    Position = new Position
                    {
                        X = 0,
                        Y = 0
                    }
                },
                Movements = new List<Movement>
                {
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F
                }
            });

            var manager = new MowerApp.MowerManager(configuration);

            //Act
            manager.Run();

            //Assert
            Assert.AreEqual(1, manager.Mowers.Count);
            Assert.AreEqual(0, manager.Mowers[0].Location.Position.X);
            Assert.AreEqual(0, manager.Mowers[0].Location.Position.Y);
        }

        [Test]
        public void GetFinalMowerPosition_WhenTopLimitIsReached()
        {
            //Arrange
            var configuration = new Configuration
            {
                Surface = new SurfaceConfiguration
                {
                    TopRightLimit = new Position
                    {
                        X = 5,
                        Y = 5
                    }
                },
                Mowers = new System.Collections.Generic.List<MowerConfiguration>()
            };

            configuration.Mowers.Add(new MowerConfiguration
            {
                Location = new Location
                {
                    Orientation = Orientation.N,
                    Position = new Position
                    {
                        X = 0,
                        Y = 0
                    }
                },
                Movements = new List<Movement>
                {
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F
                }
            });

            var manager = new MowerApp.MowerManager(configuration);

            //Act
            manager.Run();

            //Assert
            Assert.AreEqual(1, manager.Mowers.Count);
            Assert.AreEqual(0, manager.Mowers[0].Location.Position.X);
            Assert.AreEqual(5, manager.Mowers[0].Location.Position.Y);
        }

        [Test]
        public void GetFinalMowerPosition_WhenRightTopLimitIsReached()
        {
            //Arrange
            var configuration = new Configuration
            {
                Surface = new SurfaceConfiguration
                {
                    TopRightLimit = new Position
                    {
                        X = 5,
                        Y = 5
                    }
                },
                Mowers = new System.Collections.Generic.List<MowerConfiguration>()
            };

            configuration.Mowers.Add(new MowerConfiguration
            {
                Location = new Location
                {
                    Orientation = Orientation.E,
                    Position = new Position
                    {
                        X = 0,
                        Y = 0
                    }
                },
                Movements = new List<Movement>
                {
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F,
                    Movement.F
                }
            });

            var manager = new MowerApp.MowerManager(configuration);

            //Act
            manager.Run();

            //Assert
            Assert.AreEqual(1, manager.Mowers.Count);
            Assert.AreEqual(5, manager.Mowers[0].Location.Position.X);
            Assert.AreEqual(0, manager.Mowers[0].Location.Position.Y);
        }
    }
}

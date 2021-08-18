using System;
using System.Collections.Generic;

using MowerApp;
using MowerApp.Models;

using TechTalk.SpecFlow;

using Xunit;

namespace MowerAppBddTests.Steps
{
    [Binding]
    public sealed class MowerAppStepDefinitions
    {
        private readonly Configuration _configuration;

        private MowerManager _manager;

        public MowerAppStepDefinitions()
        {
            _configuration = new Configuration
            {
                Surface = new SurfaceConfiguration
                {
                    TopRightLimit = new Position
                    {
                        X = 0,
                        Y = 0
                    }
                },
                Mowers = new List<MowerConfiguration>()
            };
        }

        [Given(@"a working surface with a top right limit position with X equal to (.*) and Y equal to (.*)")]
        public void GivenAWorkingSurfaceWithATopRightLimitPositionOfXEqualToAndYEqualTo(int p0, int p1)
        {
            _configuration.Surface.TopRightLimit = new Position
            {
                X = p0,
                Y = p1
            };
        }

        [Given(@"a mower is initially oriented to (.*)")]
        public void GivenAMowerIsInitiallyOrientedTo(string p0)
        {
            _configuration.Mowers.Add(new MowerConfiguration
            {
                Location = new Location
                {
                    Orientation = (Orientation)Enum.Parse(typeof(Orientation), p0)
                },
                Movements = new List<Movement>()
            });
        }

        [Given(@"with a position with X equal to (.*) and Y equal to (.*)")]
        public void GivenWithAPositionOfXEqualToAndYEqualTo(int p0, int p1)
        {
            _configuration.Mowers[0].Location.Position = new Position
            {
                X = p0,
                Y = p1
            };
        }

        [When(@"movements sequence (.*) is sent to the mower")]
        public void WhenMovementsSequenceIsSentToTheMower(string p0)
        {
            char[] moves = p0.ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                _configuration.Mowers[0].Movements.Add((Movement)Enum.Parse(typeof(Movement), moves[i].ToString()));
            }
        }

        [When(@"treatment is launched")]
        public void WhenProcessIsLaunched()
        {
            _manager = new MowerManager(_configuration);
            _manager.Run();
        }

        [Then(@"the mower is finally oriented to (.*)")]
        public void ThenTheMowerIsFinallyOrientedTo(string p0)
        {
            var mower = _manager.Mowers[0];
            Assert.Equal(mower.Location.Orientation, (Orientation)Enum.Parse(typeof(Orientation), p0));
        }

        [Then(@"is having a final position of X equal to (.*) and Y equal to (.*)")]
        public void ThenWithAFinalPositionOfXEqualToAndYEqualTo(int p0, int p1)
        {
            var mower = _manager.Mowers[0];
            Assert.Equal(mower.Location.Position.X, p0);
            Assert.Equal(mower.Location.Position.Y, p1);
        }
    }
}

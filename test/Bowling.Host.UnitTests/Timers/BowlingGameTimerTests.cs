﻿using System;
using System.Timers;
using Bowling.Application.UseCases;
using Bowling.Domain.Entities;
using Bowling.Host.Ambient;
using Bowling.Host.Timers;
using Bowling.Host.Wrappers;
using Moq;
using Xunit;

namespace Bowling.Host.UnitTests.Timers
{
    public class BowlingGameTimerTests : IDisposable
    {
        private readonly Mock<ITimer> _timerMock;
        private readonly int _interval = 2000;
        private readonly Mock<IConsole> _consoleMock;
        private readonly Mock<IEventWaitHandle> _eventWaitHandle;
        private readonly Mock<IRequestHandler<string, Score>> _getBowlerScoreUseCase;
        private readonly Mock<IRequestHandler<Score, bool>> _saveBowlerScoreUseCase;

        public BowlingGameTimerTests()
        {
            _getBowlerScoreUseCase = new Mock<IRequestHandler<string, Score>>();
            _getBowlerScoreUseCase.Setup(g => g.Handle(It.IsAny<string>())).Returns(new Score(0));
            _saveBowlerScoreUseCase = new Mock<IRequestHandler<Score, bool>>();
            _eventWaitHandle = new Mock<IEventWaitHandle>();
            _timerMock = new Mock<ITimer>();
            _consoleMock = new Mock<IConsole>();

            BowlingContext.Current.EventWaitHandle = _eventWaitHandle.Object;

            new BowlingGameTimer(_interval, _timerMock.Object, _consoleMock.Object,
                _getBowlerScoreUseCase.Object, _saveBowlerScoreUseCase.Object);
        }

        public void Dispose()
        {
            BowlingContext.ResetToDefault();
        }

        [Fact]
        public void BowlingGameTimer_StartTimer_WithIntervalParameter()
        {
            //Assert
            _timerMock.Verify(t => t.Start(_interval), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_ShouldDisplayChoice_WhenTriggered()
        {
            //Arrange
            var firstMessage = "It is a bowling game. Do your choice please.";
            var secondMessage = "To send score player, press 's'";
            var thirdMessage = "To quit application, press 'q'";

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _consoleMock.Verify(c => c.WriteLine(firstMessage), Times.Once);
            _consoleMock.Verify(c => c.WriteLine(secondMessage), Times.Once);
            _consoleMock.Verify(c => c.WriteLine(thirdMessage), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_GetChoice_WhenTriggered()
        {
            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _consoleMock.Verify(c => c.ReadLine(), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_SetEventWaitHandle_WhenCharPressedIsEqualQ()
        {
            //Arrange
            _consoleMock.Setup(c => c.ReadLine()).Returns("q");

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _eventWaitHandle.Verify(c => c.Set(), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_StopTimer_WhenCharPressedIsEqualQ()
        {
            //Arrange
            _consoleMock.Setup(c => c.ReadLine()).Returns("q");

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _timerMock.Verify(c => c.Stop(), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_DoNothing_WhenLineIsNull()
        {
            //Arrange
            string line = null;
            _consoleMock.Setup(c => c.ReadLine()).Returns(line);

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _timerMock.Verify(c => c.Stop(), Times.Never);
            _eventWaitHandle.Verify(c => c.Set(), Times.Never);
        }

        [Fact]
        public void OnElapsedEvent_ShouldAskForScoring_WhenCharPressedIsEqualSTheFirstTime()
        {
            //Arrange
            var scoringMessage = "Please enter score.";
            _consoleMock.Setup(c => c.ReadLine()).Returns("s");

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _consoleMock.Verify(c => c.WriteLine(scoringMessage), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_ShouldReadLineTwice_WhenCharPressedIsEqualS()
        {
            //Arrange
            _consoleMock.Setup(c => c.ReadLine()).Returns("s");

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _consoleMock.Verify(c => c.ReadLine(), Times.Exactly(2));
        }

        [Fact]
        public void OnElapsedEvent_ShouldCallGetScoreUseCase_WhenCharPressedIsEqualS()
        {
            //Arrange
            var playerScore = "X X X X X X X X X X";
            _consoleMock
                .SetupSequence(c => c.ReadLine())
                    .Returns("s")
                    .Returns(playerScore);

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _getBowlerScoreUseCase.Verify(c => c.Handle(playerScore), Times.Exactly(1));
        }

        [Fact]
        public void OnElapsedEvent_ShouldDisplayBowlerScore_WhenCharPressedIsEqualS()
        {
            //Arrange
            var playerScore = "X X X X X X X X X X";
            _consoleMock
                .SetupSequence(c => c.ReadLine())
                .Returns("s")
                .Returns(playerScore);
            var score = new Score(1);
            _getBowlerScoreUseCase
                .Setup(g => g.Handle(It.IsAny<string>()))
                .Returns(score);
            var displayMessageScore = $"Bowler have a score equals to {score.Value}";

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _consoleMock.Verify(c => c.WriteLine(displayMessageScore), Times.Once);
        }

        [Fact]
        public void OnElapsedEvent_ShouldSaveBowlerScore_WhenCharPressedIsEqualS()
        {
            //Arrange
            var playerScore = "X X X X X X X X X X";
            _consoleMock
                .SetupSequence(c => c.ReadLine())
                .Returns("s")
                .Returns(playerScore);
            var score = new Score(1);
            _getBowlerScoreUseCase
                .Setup(g => g.Handle(It.IsAny<string>()))
                .Returns(score);

            //Act
            _timerMock.Raise(t => t.Elapsed += null, new EventArgs() as ElapsedEventArgs);

            //Assert
            _saveBowlerScoreUseCase.Verify(s => s.Handle(score), Times.Once);
        }
    }
}
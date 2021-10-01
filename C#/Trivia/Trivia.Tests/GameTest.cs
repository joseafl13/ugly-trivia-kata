using ApprovalTests;
using ApprovalTests.Reporters;
using System;
using System.IO;
using Xunit;

namespace Trivia.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GameTest
    {
        [Fact]
        public void check_game_runner_console_output() {
            string gameOutput = null;

            using (var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                
                var aGivenGame = new Game();
                aGivenGame.Add("Chet");
                aGivenGame.Add("Pat");
                aGivenGame.Add("Sue");
                var gameRunner = new GameRunner();

                gameRunner.Run(aGivenGame, new RandomTestable());

                gameOutput = stringWriter.ToString();
                stringWriter.Flush();
            }

            Approvals.Verify(gameOutput);
        }

        public class RandomTestable : Random
        {
            public override int Next(int maxValue) {
                return 2;
            }
        }
    }
}
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

            using (var sw = new StringWriter()) {
                Console.SetOut(sw);
                
                var aGame = new Game();
                aGame.Add("Chet");
                aGame.Add("Pat");
                aGame.Add("Sue");
                var game = new GameRunner();

                game.Run(aGame, new RandomTestable());

                gameOutput = sw.ToString();
                sw.Flush();
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
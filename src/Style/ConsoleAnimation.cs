using System;
using System.Text;

namespace ConsoleApplication
{
    public class ConsoleAnimation
    {
        public int currentAnimationFrame { get; set; }

        public int lineLength { get; } = 12;

        public int animatedChar { get; set; }

            // public static readonly string[] SpinnerAnimationFrames = new[] 
            // {
            //     "....................",
            //     "|...................",
            //     "||..................",
            //     "|||.................",
            //     "||||................",
            //     "|||||...............",
            //     "||||||..............",
            //     "|||||||.............",
            //     "||||||||............",
            //     "|||||||||...........",
            //     "||||||||||..........",
            //     "|||||||||||.........",
            //     "||||||||||||........",
            //     "|||||||||||||.......",
            //     "||||||||||||||......",
            //     "|||||||||||||||.....",
            //     "||||||||||||||||....",
            //     "|||||||||||||||||...",
            //     "||||||||||||||||||..",
            //     "|||||||||||||||||||.",
            //     "||||||||||||||||||||"
            // };
        // }

        private void printAnimationLine(int lineIndex)
        {
            StringBuilder sb = new StringBuilder(String.Empty);

            for (int count = 0; count < lineIndex; ++count)
            {
                sb.Append(animatedChar);
            }

            for (int count = 0; count < lineLength-lineIndex; ++count)
            {
                sb.Append('.');
            }

            Console.WriteLine(sb.ToString());
        }
        
        private bool animation()
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Yellow;

            printAnimationLine(currentAnimationFrame);

            Console.ForegroundColor = ConsoleColor.White;

            ++currentAnimationFrame;

            if (currentAnimationFrame == lineLength)
            {
                currentAnimationFrame = 0;
            }

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);

            return currentAnimationFrame > 0 ? true : false;
        }

        public void play(int duration)
        {
            bool playingAnimation = true;

            currentAnimationFrame = 0;

            while (playingAnimation)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(duration);
                playingAnimation = this.animation();
            }
        }
    }
}
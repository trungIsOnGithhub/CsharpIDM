using System;

namespace ConsoleApplication
{
    public class ConsoleAnimation
    {
        private int currentAnimationFrame;

        // public ConsoleAnimation()
        // {
            public static readonly string[] SpinnerAnimationFrames = new[] 
            {
                "....................",
                "|...................",
                "||..................",
                "|||.................",
                "||||................",
                "|||||...............",
                "||||||..............",
                "|||||||.............",
                "||||||||............",
                "|||||||||...........",
                "||||||||||..........",
                "|||||||||||.........",
                "||||||||||||........",
                "|||||||||||||.......",
                "||||||||||||||......",
                "|||||||||||||||.....",
                "||||||||||||||||....",
                "|||||||||||||||||...",
                "||||||||||||||||||..",
                "|||||||||||||||||||.",
                "||||||||||||||||||||"
            };
        // }
        
        public bool animation()
        {
            Console.CursorVisible = false;

            var left = Console.CursorLeft;
            var top = Console.CursorTop;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(SpinnerAnimationFrames[currentAnimationFrame]);
            Console.ForegroundColor = ConsoleColor.White;

            currentAnimationFrame++;
            if(currentAnimationFrame == SpinnerAnimationFrames.Length)
            {
                currentAnimationFrame = 0;
            }

            Console.SetCursorPosition(left, top);

            return currentAnimationFrame > 0 ? true : false;
        }
    }
}
using System.Collections.Generic;

namespace Events
{
    class KeyBoardEventSubcriber
    {
        private KeyBoardEventPublisher publisher;

        public KeyBoardEventSubcriber(KeyBoardEventPublisher publisher)
        {
            this.publisher = publisher;
        }

        public void SubcribeEvent()
        {
            publisher.KeyBoardEvent += this.EventHandler;
        }

        public void UnSubcribeEvent()
        {
            publisher.KeyBoardEvent -= this.EventHandler;
        }



        public void EventHandler(object sender, EventArgs eArgs)
        {
            if (sender == null)
            {
                Console.WriteLine("Null Sender of Event");
                return;
            }
            
            Console.WriteLine(generateRandomNumber(1, 100));
        }

        private int generateRandomNumber(int lowerBound, int upperBound)
        {
            return (new Random()).Next(lowerBound, upperBound+1);
        }
    }
}
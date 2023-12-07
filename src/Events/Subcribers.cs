using System.Collections.Generic;

namespace Events
{
    class KeyBoardEventSubcriber
    {
        private SpaceKeyEventPublisher spaceKeyPublisher;
        private EnterKeyEventPublisher enterKeyPublisher;

        public KeyBoardEventSubcriber(
                SpaceKeyEventPublisher spaceKeyPublisher,
                EnterKeyEventPublisher enterKeyPublisher )
        {
            this.spaceKeyPublisher = spaceKeyPublisher;
            this.enterKeyPublisher = enterKeyPublisher;
        }

        public void SubcribeEventSpaceKey()
        {
            this.spaceKeyPublisher.KeyEvent += this.PrintIfSpacePress;
        }

        public void UnSubcribeEventSpaceKey()
        {
            this.spaceKeyPublisher.KeyEvent -= this.PrintIfSpacePress;
        }


        public void SubcribeEventEnterKey()
        {
            this.enterKeyPublisher.KeyEvent += this.PrintIfEnterPress;
        }

        public void UnSubcribeEventEnterKey()
        {
            this.enterKeyPublisher.KeyEvent -= this.PrintIfEnterPress;
        }


        public void PrintIfEnterPress(object sender, EnterKeyEventArgs eArgs)
        {
            if (sender == null)
            {
                Console.WriteLine("Undefined Events");
                return;
            }

            Console.WriteLine($"{eArgs.Message}after pressing Enter!");
        }

        public void PrintIfSpacePress(object sender, SpaceKeyEventArgs eArgs)
        {
            if (sender == null)
            {
                Console.WriteLine("Undefined Events");
                return;
            }

            Console.WriteLine($"{eArgs.Message}after pressing Space!");
        }
    }
}
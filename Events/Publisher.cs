
namespace Events
{
    public delegate void KeyboardEventHandler (object sender, EventArgs eArgs);
    // class KeyBoardEvent
    // {
    //     public event KeyboardEventHandler KeyboardEvent
    //     {
    //         add
    //         {
    //             Console.WriteLine("+1 subcriber");
    //         }
    //         remove
    //         {
    //             Console.WriteLine("-1 subcriber");
    //         }
    //     }
    // }

    class KeyBoardEventPublisher
    {
        public event KeyboardEventHandler KeyBoardEvent;

        protected virtual void OnChanged(EventArgs eArgs)
        {
            if (KeyBoardEvent != null)
            {
                KeyBoardEvent(this, eArgs);
            }
        }

        public void ReceiveKeyEntered(char key)
        {
            Console.WriteLine(key);
            OnChanged(EventArgs.Empty);
        }
    }
}
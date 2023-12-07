
namespace Events
{
    public delegate void EnterKeyEventHandler (object sender, EnterKeyEventArgs eArgs);
    public delegate void SpaceKeyEventHandler (object sender, SpaceKeyEventArgs eArgs);

    abstract class KeyEventPublisher
    {
        public abstract void ReceiveKey();
    }

    class EnterKeyEventPublisher : KeyEventPublisher
    {
        public event EnterKeyEventHandler KeyEvent;

        protected virtual void OnKeyPressed(EnterKeyEventArgs eArgs)
        {
            if (KeyEvent != null)
            {
                KeyEvent(this, eArgs);
            }
        }

        public override void ReceiveKey()
        {
            OnKeyPressed(new EnterKeyEventArgs());
        }
    }

    class SpaceKeyEventPublisher : KeyEventPublisher
    {
        public event SpaceKeyEventHandler KeyEvent;

        protected virtual void OnKeyPressed(SpaceKeyEventArgs eArgs)
        {
            if (KeyEvent != null)
            {
                KeyEvent(this, eArgs);
            }
        }

        public override void ReceiveKey()
        {
            OnKeyPressed(new SpaceKeyEventArgs());
        }
    }

    public class EnterKeyEventArgs : EventArgs
    {
        private static string message = $"{Environment.NewLine}Trung Dep Trai{Environment.NewLine}";

        public string Message
        {
            get { return message; }
        }
    }

    public class SpaceKeyEventArgs : EventArgs
    {
        private static string message = $"{Environment.NewLine}Trung Vui Ve{Environment.NewLine}";

        public string Message
        {
            get { return message; }
        }
    }
}
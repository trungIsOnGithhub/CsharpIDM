using Events;

class Program
{
    static void Main(string[] args) {
        KeyBoardEventPublisher publisher = new();
        KeyBoardEventSubcriber subcriber = new(publisher);

        subcriber.SubcribeEvent();

        publisher.ReceiveKeyEntered('c');
        publisher.ReceiveKeyEntered('a');
        publisher.ReceiveKeyEntered('c');

        subcriber.UnSubcribeEvent();

        publisher.ReceiveKeyEntered('c');
        publisher.ReceiveKeyEntered('a');
        publisher.ReceiveKeyEntered('c');
    }
}

namespace Messages
{
    public class Message
    {
        public string Jinchuriki {get; set;}
        public int TailedBeast {get; set;}
        public float CoordinateX {get; set;}
        public float CoordinateY {get; set;}

        public Message(string jinchuriki, int tailedBeast, float x, float y)
        {
            Jinchuriki = jinchuriki;
            TailedBeast = tailedBeast;
            CoordinateX = x;
            CoordinateY = y;
        }

        public void Display()
        {
            Console.WriteLine($"[Intel] Target Jinchuriki: {Jinchuriki} (Tails: {TailedBeast}) at Coordinates: ({CoordinateX}, {CoordinateY})");
        }
    }
}
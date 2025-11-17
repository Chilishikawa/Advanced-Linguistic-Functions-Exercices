using System.Xml;

namespace InteractiveMusicPlayer
{
    public delegate void MusicPlayerDelegate(string message);

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter song title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the action you wish to perform: (play, pause, stop, skip)");
            string action = Console.ReadLine();

            switch (action)
            {
                case "play":
                    var player1 = new Subscriber(MusicPlayer.SongPlayed);
                    player1.EjecuteAction(name,title);
                    break;
                case "pause":
                    var player2 = new Subscriber(MusicPlayer.SongPaused);
                    player2.EjecuteAction(name, title);
                    break;
                case "stop":
                    var player3 = new Subscriber(MusicPlayer.SongStopped);
                    player3.EjecuteAction(name, title);
                    break;
                case "skip":
                    var player4 = new Subscriber(MusicPlayer.SongSkipped);
                    player4.EjecuteAction(name, title);
                    break;
            }
            
        }
    }

    public class MusicPlayer
    {
        public static void SongPlayed(string message)
        {
            Console.WriteLine($"SongPlayed: {message}");
        }

        public static void SongPaused(string message)
        {
            Console.WriteLine($"SongPaused: {message}");
        }

        public static void SongStopped(string message)
        {
            Console.WriteLine($"SongStopped: {message}");
        }

        public static void SongSkipped(string message)
        {
            Console.WriteLine($"SongSkipped: {message}");
        }
    }

    public class Subscriber
    {
        private readonly MusicPlayerDelegate _musicPlayerDelegate;

        public Subscriber(MusicPlayerDelegate musicPlayerDelegate)
        {
            _musicPlayerDelegate = musicPlayerDelegate;
        }

        public void EjecuteAction(string name, string title)
        {
            _musicPlayerDelegate($"{title}, user: {name}");
        }
    }
}

using CreateAttribute;
using System;

namespace AuthorProblem
{
    [Author("Lybeti")]
    public class StartUp
    {
        [Author("Peshko")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}

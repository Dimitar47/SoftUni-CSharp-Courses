using Handball.Core;
using Handball.Core.Contracts;

namespace Handball
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();            
        }
    }
}

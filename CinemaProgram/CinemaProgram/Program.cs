using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await ConsoleProgram.LoginRegisterAsync();
        }
    }
}

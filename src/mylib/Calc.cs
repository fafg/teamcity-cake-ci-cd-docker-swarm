using System.Threading.Tasks;

namespace mylib
{
    public class Calc : ICalc
    {
        public async Task<int> AddAsync(int a, int b)
        {
            return await Task.Run(() =>
            {
                return a + b;
            }).ConfigureAwait(false);
        }
    }
}

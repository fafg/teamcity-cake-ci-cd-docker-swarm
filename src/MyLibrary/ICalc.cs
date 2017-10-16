using System.Threading.Tasks;

namespace mylib
{
    public interface ICalc
    {
        Task<int> AddAsync(int a, int b);
    }
}

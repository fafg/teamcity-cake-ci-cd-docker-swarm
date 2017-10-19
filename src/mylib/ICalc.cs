namespace mylib
{
    using System.Threading.Tasks;

    public interface ICalc
    {
        Task<int> AddAsync(int a, int b);
    }
}

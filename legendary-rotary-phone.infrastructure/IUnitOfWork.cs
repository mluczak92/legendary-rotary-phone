using System.Threading.Tasks;

namespace legendary_rotary_phone.infrastructure
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}

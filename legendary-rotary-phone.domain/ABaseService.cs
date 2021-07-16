using AutoMapper;
using legendary_rotary_phone.infrastructure;

namespace legendary_rotary_phone.domain
{
    public abstract class ABaseService
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public ABaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}

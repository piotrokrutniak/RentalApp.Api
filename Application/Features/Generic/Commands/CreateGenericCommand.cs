using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Features.Generic.Commands
{
    public partial class CreateGenericCommand<IEntity> : IRequest<Response<int>>
    {

    }
    public partial class CreateGenericCommandHandler<IEntity> : IRequestHandler<CreateGenericCommand<AuditableBaseEntity>, Response<int>>
    {
        private readonly IGenericRepositoryAsync<AuditableBaseEntity> _genericRepository;
        private readonly IMapper _mapper;

        public CreateGenericCommandHandler(IGenericRepositoryAsync<AuditableBaseEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGenericCommand<AuditableBaseEntity> request, CancellationToken cancellationToken)
        {
            AuditableBaseEntity generic = _mapper.Map<AuditableBaseEntity>(request);

            await _genericRepository.AddAsync(generic);

            return new Response<int>(generic.Id);
        }
    }
}

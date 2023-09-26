using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.Actor;
using Sakila.Application.Feature.Actor.Requests;
using FluentValidation;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Ententions;

namespace Sakila.Application.Feature.Actor.Handlers
{
    public class CreateActorHandler : IRequestHandler<CreateActorRequest, BaseResponse<Dtos.Actors.ActorDto>>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Dtos.Actors.CreateActor> _validator;

        public CreateActorHandler(IActorRepository actorRepository, IMapper mapper, IValidator<Dtos.Actors.CreateActor> validator)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<Dtos.Actors.ActorDto>> Handle(CreateActorRequest request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request.ActorDto);
            var rep = new BaseResponse<Dtos.Actors.ActorDto>();
            if (!result.IsValid)
            {
                return MessageExtention<Dtos.Actors.ActorDto>.ResultErrorValidator(result);
            }
            var data = await _actorRepository.Add(_mapper.Map<Domain.Actor>(request.ActorDto));
            await _actorRepository.SaveChange();
            var dataDto = _mapper.Map<Dtos.Actors.ActorDto>(data);
            return MessageExtention<Dtos.Actors.ActorDto>.ResultOK(dataDto);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.UnitOfWork;

namespace TaskManager.Application.Commands.UserCommands.Queries
{
    public class SearchUserBySpecificationQueryHandler : IRequestHandler<SearchUserBySpecificationQuery, NotificationResult<IList<UserDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchUserBySpecificationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NotificationResult<IList<UserDTO>>> Handle(SearchUserBySpecificationQuery request, CancellationToken cancellationToken)
        {
            var searchUsers = await _unitOfWork.UserRepository.SearchUsers(request.Search);

            var allUsersDTO = _mapper.Map<IList<UserDTO>>(searchUsers);

            return new NotificationResult<IList<UserDTO>>(true,
                                                          new DomainNotification($"{allUsersDTO.Count()} usuário(s) encontrado(s).", 
                                                                                  System.Net.HttpStatusCode.Found),
                                                          allUsersDTO);
        }
    }
}
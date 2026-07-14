using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.Users.Input;
using src.Modules.Dtos.Users.Output;

namespace src.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IReadOnlyList<UserOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default);
        public Task<UserOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default);
        public Task<CreateUserOutputDto> CreateAsync(CreateUserInputDto createUserDto,
            CancellationToken cancellationToken = default);
        public Task<UpdateUserOutputDto> UpdateAsync(Guid id, UpdateUserInputDto updateUserDto,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
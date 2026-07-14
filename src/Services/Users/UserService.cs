using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using metvagas.src.Modules.Mappers;
using src.Data.Interfaces;
using src.Modules.Dtos.Users.Input;
using src.Modules.Dtos.Users.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<IReadOnlyList<UserOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return [.. (await userRepository.GetAllAsync(cancellationToken))
                .Select(x => x.MapToDto())];
        }

        public async Task<UserOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Usuário {id} não encontrado.");
            return user.MapToDto();
        }

        public async Task<CreateUserOutputDto> CreateAsync(CreateUserInputDto createUserDto,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.Name))
                throw new ArgumentException("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(createUserDto.Email))
                throw new ArgumentException("Email é obrigatório.");

            var newUser = createUserDto.MapToEntity();
            await userRepository.CreateAsync(newUser, cancellationToken);
            var userWithRelations = await userRepository.GetByIdAsync(newUser.Id, cancellationToken); // 👈
            return userWithRelations.MapToCreateDto();
        }

        public async Task<UpdateUserOutputDto> UpdateAsync(Guid id, UpdateUserInputDto updateUserDto,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Usuário {id} não encontrado.");

            user.MapToEntity(updateUserDto);

            await userRepository.UpdateAsync(user, cancellationToken);

            var userWithRelations = await userRepository.GetByIdAsync(user.Id, cancellationToken); // 👈
            return userWithRelations.MapToUpdateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken)
               ?? throw new KeyNotFoundException($"Usuário {id} não encontrado.");

            await userRepository.DeleteAsync(user, cancellationToken);
        }
    }
}
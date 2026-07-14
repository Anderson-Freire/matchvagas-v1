using System;

namespace src.Modules.Dtos
{
    public abstract class BaseDto
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Models.Contracts
{
    public interface ISoftDeletable
    {
        [Comment("Is the entity active or not.")]
        bool IsActive { get; set; }

        [Comment("The date and time when the entity was deleted.")]
        DateTime? DeletedAt { get; set; }
    }
}

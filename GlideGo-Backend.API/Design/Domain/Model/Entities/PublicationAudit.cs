using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace GlideGo_Backend.API.Design.Domain.Model.Entities;

public partial class Publication : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAdt")]
    public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAdt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}
using System;
namespace Lab_06.Models
{
    public interface IBaseModel
    {
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}

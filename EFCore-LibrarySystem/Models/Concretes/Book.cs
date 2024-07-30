using EFCore_LibrarySystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_LibrarySystem.Models.Concretes;

public class Book : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Author? Authors { get; set; }
    public int AuthoursId { get; set; }
    public int ReadsCount { get; set; }
    public int Quantity { get; set; }


    public Book Clone() => new() { Name = Name, Description = Description, Authors = Authors, AuthoursId = AuthoursId, ReadsCount = ReadsCount };

    public override string ToString() => $"{Name}";
}

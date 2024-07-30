using EFCore_LibrarySystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_LibrarySystem.Models.Concretes;

public class Author : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public Book? Book { get; set; }
    public int BookId { get; set; }
}

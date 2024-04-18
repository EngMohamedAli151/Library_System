using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DB.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        public int BookId { get; set; }
        [ForeignKey("BookId")]
       // public Book Book { get; set; } = null!;
        public DateTime StartDate { get; set; }= DateTime.Now;
        public DateTime EndtDate { get; set; }
    }
}

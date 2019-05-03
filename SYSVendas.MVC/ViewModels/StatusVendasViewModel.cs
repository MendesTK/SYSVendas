
using System.ComponentModel.DataAnnotations;

namespace SYSVendas.MVC.ViewModels
{
    public class StatusVendasViewModel
    {
        [Key]
        public int StatusId { get; set; }

        public string Status { get; set; }
    }
}
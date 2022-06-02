using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee
{
    public class PaginaONGFlyoutMenuItem
    {
        public PaginaONGFlyoutMenuItem()
        {
            TargetType = typeof(PaginaONGFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
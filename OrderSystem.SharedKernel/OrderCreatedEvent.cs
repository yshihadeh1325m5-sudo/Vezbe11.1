using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.SharedKernel
{
    public class OrderCreatedEvent
    {
        public string Custumer {  get; set; }   
        public decimal Total { get; set; }
    }
}

using System.Collections.Generic;

namespace ZooLander
{
    // Класс для представления квитанции
    class Invoice
    {
        public double TotalCost { get; set; }
        public List<string> Services { get; set; }
    }
}
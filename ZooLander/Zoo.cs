using System;
using System.Collections.Generic;

namespace ZooLander
{
    // Класс для управления зоопарком
    class Zoo
    {
        public List<Animal> Animals { get; set; }
        public List<Employee> Employees { get; set; }

        public Zoo()
        {
            Animals = new List<Animal>();
            Employees = new List<Employee>();
        }

        // Методы для управления списком животных
        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }

        // Методы для управления списком сотрудников
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        // Метод для расчета стоимости посещения
        public Invoice CalculateVisitCost(Ticket.TicketType ticketType, List<string> services)
        {
            double basePrice = GetTicketPrice(ticketType);
            double additionalCost = GetAdditionalServicesCost(services);

            double totalCost = basePrice + additionalCost;

            Invoice invoice = new Invoice
            {
                TotalCost = totalCost,
                Services = services
            };

            return invoice;
        }

        // Вспомогательные методы для расчета стоимости
        private double GetTicketPrice(Ticket.TicketType ticketType)
        {
            switch (ticketType)
            {
                case Ticket.TicketType.Adult:
                    return 10.0;
                case Ticket.TicketType.Child:
                    return 5.0;
                case Ticket.TicketType.Discounted:
                    return 7.0;
                default:
                    throw new ArgumentException("Invalid ticket type");
            }
        }

        private double GetAdditionalServicesCost(List<string> services)
        {
            double totalCost = 0.0;

            foreach (string service in services)
            {
                // Пример услуг и их стоимости
                switch (service)
                {
                    case "Excursion":
                        totalCost += 3.0;
                        break;
                    case "AnimalFeeding":
                        totalCost += 2.0;
                        break;
                    case "Photoshoot":
                        totalCost += 5.0;
                        break;
                    default:
                        break;
                }
            }

            return totalCost;
        }
    }
}
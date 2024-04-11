using System;
using System.Collections.Generic;

namespace ZooLander
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Удалить животное");
                Console.WriteLine("3. Просмотреть список животных");
                Console.WriteLine("4. Добавить сотрудника");
                Console.WriteLine("5. Удалить сотрудника");
                Console.WriteLine("6. Просмотреть список сотрудников");
                Console.WriteLine("7. Рассчитать стоимость посещения");
                Console.WriteLine("8. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAnimal(zoo);
                        break;
                    case "2":
                        RemoveAnimal(zoo);
                        break;
                    case "3":
                        ViewAnimals(zoo);
                        break;
                    case "4":
                        AddEmployee(zoo);
                        break;
                    case "5":
                        RemoveEmployee(zoo);
                        break;
                    case "6":
                        ViewEmployees(zoo);
                        break;
                    case "7":
                        CalculateVisitCost(zoo);
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddAnimal(Zoo zoo)
        {
            Console.WriteLine("Введите вид животного:");
            string species = Console.ReadLine();

            Console.WriteLine("Введите характеристики животного:");
            string characteristics = Console.ReadLine();

            zoo.AddAnimal(new Animal { Species = species, Characteristics = characteristics });
            Console.WriteLine("Животное успешно добавлено.");
        }

        static void RemoveAnimal(Zoo zoo)
        {
            Console.WriteLine("Введите номер животного для удаления:");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < zoo.Animals.Count)
            {
                zoo.RemoveAnimal(zoo.Animals[index]);
                Console.WriteLine("Животное успешно удалено.");
            }
            else
            {
                Console.WriteLine("Некорректный номер животного.");
            }
        }

        static void ViewAnimals(Zoo zoo)
        {
            Console.WriteLine("Список животных:");
            for (int i = 0; i < zoo.Animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Вид: {zoo.Animals[i].Species}, Характеристики: {zoo.Animals[i].Characteristics}");
            }
        }

        static void AddEmployee(Zoo zoo)
        {
            Console.WriteLine("Введите должность сотрудника:");
            string position = Console.ReadLine();

            Console.WriteLine("Введите имя сотрудника:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите контактную информацию сотрудника:");
            string contactInfo = Console.ReadLine();

            zoo.AddEmployee(new Employee { Position = position, Name = name, ContactInfo = contactInfo });
            Console.WriteLine("Сотрудник успешно добавлен.");
        }

        static void RemoveEmployee(Zoo zoo)
        {
            Console.WriteLine("Введите номер сотрудника для удаления:");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < zoo.Employees.Count)
            {
                zoo.RemoveEmployee(zoo.Employees[index]);
                Console.WriteLine("Сотрудник успешно удален.");
            }
            else
            {
                Console.WriteLine("Некорректный номер сотрудника.");
            }
        }

        static void ViewEmployees(Zoo zoo)
        {
            Console.WriteLine("Список сотрудников:");
            for (int i = 0; i < zoo.Employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Должность: {zoo.Employees[i].Position}, Имя: {zoo.Employees[i].Name}, Контактная информация: {zoo.Employees[i].ContactInfo}");
            }
        }

        static void CalculateVisitCost(Zoo zoo)
        {
            Console.WriteLine("Выберите тип билета:");
            Console.WriteLine("1. Взрослый");
            Console.WriteLine("2. Детский");
            Console.WriteLine("3. Скидочный");
            string ticketChoice = Console.ReadLine();

            Ticket.TicketType ticketType;
            switch (ticketChoice)
            {
                case "1":
                    ticketType = Ticket.TicketType.Adult;
                    break;
                case "2":
                    ticketType = Ticket.TicketType.Child;
                    break;
                case "3":
                    ticketType = Ticket.TicketType.Discounted;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    return;
            }

            Console.WriteLine("Хотите добавить дополнительные услуги? (Y/N)");
            string addServicesChoice = Console.ReadLine();

            List<string> services = new List<string>();
            if (addServicesChoice.ToLower() == "y")
            {
                Console.WriteLine("Выберите услуги (введите через запятую):");
                Console.WriteLine("1. Экскурсия");
                Console.WriteLine("2. Кормление животных");
                Console.WriteLine("3. Фотосессия");
                string[] selectedServices = Console.ReadLine().Split(',');
                foreach (var service in selectedServices)
                {
                    services.Add(service.Trim());
                }
            }

            Invoice invoice = zoo.CalculateVisitCost(ticketType, services);

            Console.WriteLine("Общая стоимость посещения: $" + invoice.TotalCost);
            Console.WriteLine("Выбранные услуги:");
            foreach (string service in invoice.Services)
            {
                Console.WriteLine("- " + service);
            }
        }
    }
}
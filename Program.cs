using System;
using System.Collections.Generic;
using System.Linq;
namespace EmployeeDatabase
{
    class Employee
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }
        public int MonthlySalary()
        {
            return Salary / 12;
        }
    }
    // class EmployeeDatabase 
    // {
    //   private List<Employee> employees = new List<Employee>();
    // }

    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Our Employee Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var employees = new List<Employee>();

            DisplayGreeting();
            var keepGoing = true;
            while (keepGoing)
            {
                // Inert a blank line then prompt them and get their answer (force uppercase)       
                Console.WriteLine();
                Console.Write("What do you want to do? (A)dd an employee or (D)elete an employee or (S)how all the employees or (F)ind an employee or (Q)uit: ");
                var choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;

                    case "U":
                        var nameToUpdate = PromptForString("What name are you looking for: ");
                        Employee foundEmployeeToUpdate = employees.FirstOrDefault(employee => employee.Name == nameToUpdate);
                        if (foundEmployeeToUpdate == null)
                        {
                            Console.WriteLine("Nobody by that name to update.");
                        }
                        else
                        {
                            employees.Remove(foundEmployeeToUpdate);
                            var newSalary = PromptForInteger($"What is {nameToUpdate}'s salary");
                            foundEmployeeToUpdate.Salary = newSalary;
                        }
                        break;
                    case "D":
                        var nameToDelete = PromptForString("What name are you looking for: ");
                        Employee foundEmployeeToDelete = employees.FirstOrDefault(employee => employee.Name == nameToDelete);
                        if (foundEmployeeToDelete == null)
                        {
                            Console.WriteLine("Nobody by that name to delete.");
                        }
                        else
                        {
                            employees.Remove(foundEmployeeToDelete);
                            Console.WriteLine($"Goodbye {foundEmployeeToDelete.Name}");
                        }
                        break;
                    case "S":
                        // Loop through each employee          
                        foreach (var employee in employees)
                        {
                            // And print details            
                            Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
                        }
                        break;
                    case "F":
                        var name = PromptForString("What name are you looking for: ");
                        Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);



                        // Employee foundEmployee = null;
                        // foreach (var employee in employees)
                        // {            // If the name matches            
                        //     if (employee.Name == name)
                        //     {
                        //         foundEmployee = employee;
                        //     }
                        // }
                        if (foundEmployee == null)
                        {
                            Console.WriteLine("No match found.");
                        }
                        else
                        {
                            Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                        }
                        break;
                }
            }
        }
    }
}


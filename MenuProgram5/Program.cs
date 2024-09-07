using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MenuProgram5
{
    //public class EmployeeNameComparer : IComparer<Employee>
    //{
    //    public int Compare(Employee x, Employee y)
    //    {
    //        if (x == null || y == null) return 0;
    //        return string.Compare(x.Name, y.Name);
    //    }
    //}

    //public class EmployeeSalaryComparer : IComparer<Employee>
    //{
    //    public int Compare(Employee x, Employee y)
    //    {
    //        if (x == null || y == null) return 0;
    //        return x.Salary.CompareTo(y.Salary);
    //    }
    //}

    //public class EmployeeAgeComparer : IComparer<Employee>
    //{
    //    public int Compare(Employee x, Employee y)
    //    {
    //        if (x == null || y == null) return 0;
    //        return x.Age.CompareTo(y.Age);
    //    }
    //}

    //public class EmployeeIDComparer : IComparer<Employee>
    //{
    //    public int Compare(Employee x, Employee y)
    //    {
    //        if (x == null || y == null) return 0;
    //        return x.ID.CompareTo(y.ID);
    //    }
    //}

    public static class Exclass
    {
        public static void Display(this List<Employee> emp)
        {
            if (emp == null || emp.Count() == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }
            foreach (var empl in emp)
            {
                if (empl != null)
                {
                    Console.WriteLine(empl.ToString());
                }
            }
        }
    }

    //public enum Gender
    //{
    //    Male,
    //    Female,
    //}

    //public class Human
    //{
    //    public int Age { get; set; }
    //    public string Name { get; set; }
    //    public Gender Gender { get; set; }

    //    public Human(int age, string name, Gender gender)
    //    {
    //        Age = age;
    //        Name = name;
    //        Gender = gender;
    //    }

    //    public override string ToString()
    //    {
    //        return $"Name: {Name}, Age: {Age}, Gender: {Gender}";
    //    }
    //}

    //public class Employee : Human
    //{
    //    public int ID { get; }
    //    public int Salary { get; set; }

    //    private static int Objectcnt = 0;

    //    public Employee(string name, int salary, Gender gender, int age)
    //        : base(age, name, gender)
    //    {
    //        Salary = salary;
    //        ID = ++Objectcnt;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{base.ToString()}, Employee ID: {ID}, Employee Salary: {Salary}";
    //    }
    //}

    internal class Program
    {
        public static void Main(string[] args)
        {
            //List<Employee> emp = new List<Employee>();
            string[] menu = { "New", "Display", "Exit" };
            //string[] sortOptions = { "By Name", "By Salary", "By Age", "By ID" };
            int chs = 0;
            int data_idx = 0;
            bool isRunning = true;

            do
            {
                Console.Clear();
                ShowMenu(menu, chs);
                ConsoleKeyInfo k = Console.ReadKey();

                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        chs = (chs == 0) ? menu.Length - 1 : chs - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        chs = (chs == menu.Length - 1) ? 0 : chs + 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (chs)
                        {
                            case 0:
                                AddEmployeeOrDepartment();
                                break;
                            case 1:
                                Console.Clear();
                                DisplayMethod();
                                Console.ReadKey();
                                break;
                            //case 2:
                            //    NavigateSortMenu(emp, sortOptions);
                            //    break;
                            case 2:
                                isRunning = false;
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                }
            } while (isRunning);
        }


        public static void ShowMenu(string[] options, int selectedIndex)
        {
            int disx = Console.WindowWidth / 2;
            int disy = Console.WindowHeight / 4;
            for (int i = 0; i < options.Length; i++)
            {
                Console.BackgroundColor = (selectedIndex == i) ? ConsoleColor.Green : ConsoleColor.Black;
                int posX = disx - (options[i].Length / 2);
                int posY = disy * (i + 1);
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(options[i]);
            }
            Console.ResetColor();
        }

        //public static void NavigateSortMenu(List<Employee> emp, string[] sortOptions)
        //{
        //    int sortChs = 0;
        //    bool sorting = true;

        //    while (sorting)
        //    {
        //        Console.Clear();
        //        ShowMenu(sortOptions, sortChs);
        //        ConsoleKeyInfo sortKey = Console.ReadKey();

        //        switch (sortKey.Key)
        //        {
        //            case ConsoleKey.UpArrow:
        //                sortChs = (sortChs == 0) ? sortOptions.Length - 1 : sortChs - 1;
        //                break;
        //            case ConsoleKey.DownArrow:
        //                sortChs = (sortChs == sortOptions.Length - 1) ? 0 : sortChs + 1;
        //                break;
        //            case ConsoleKey.Enter:
        //                try
        //                {
        //                    SortEmployees(emp, sortChs);
        //                    Console.Clear();
        //                    emp.Display();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine($"An error occurred while sorting: {ex.Message}");
        //                }
        //                Console.ReadKey();
        //                sorting = false;
        //                break;
        //            case ConsoleKey.Escape:
        //                sorting = false;
        //                break;
        //        }
        //    }
        //}

        //public static void SortEmployees(List<Employee> emp, int sortOption)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Choose sorting order:");
        //    Console.WriteLine("1: Ascending");
        //    Console.WriteLine("2: Descending");
        //    int orderChoice;
        //    while (!int.TryParse(Console.ReadLine(), out orderChoice) || (orderChoice != 1 && orderChoice != 2))
        //    {
        //        Console.WriteLine("Invalid input. Please enter 1 for Ascending or 2 for Descending.");
        //    }

        //    Comparison<Employee> comparison = sortOption switch
        //    {
        //        0 => (x, y) => string.Compare(x.Name, y.Name),
        //        1 => (x, y) => x.Salary.CompareTo(y.Salary),
        //        2 => (x, y) => x.Age.CompareTo(y.Age),
        //        3 => (x, y) => x.ID.CompareTo(y.ID),

        //    };

        //    if (emp.Count > 0)
        //    {
        //        emp.Sort((x, y) =>
        //        {
        //            int result = comparison(x, y);
        //            return orderChoice == 1 ? result : -result;
        //        });
        //    }
        //}

        public static void AddEmployeeOrDepartment()
        {
            bool adding = true;
            while (adding)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Add Employee");
                Console.WriteLine("2: Add Department");
                Console.WriteLine("3: Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        AddDepartment();
                        break;
                    case "3":
                        adding = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        break;
                }
            }
        }

        public static void AddDepartment()
        {
            Console.WriteLine("Enter Department Name:");
            string departmentName = Console.ReadLine();

            using (var context = new CompanyDBContext())
            {
                var department = new Department
                {
                    Name = departmentName
                };

                context.Departments.Add(department);
                context.SaveChanges();
                Console.WriteLine("Department added successfully.");
            }
        }

        public static void AddEmployee()
        {
            Console.WriteLine("Enter Employee Name:");
            string employeeName = Console.ReadLine();

            Console.WriteLine("Enter Employee Age:");
            int employeeAge = int.Parse(Console.ReadLine());

            

            Console.WriteLine("Enter Department ID:");
            int departmentId = int.Parse(Console.ReadLine());

            using (var context = new CompanyDBContext())
            {
                var employee = new Employee
                {
                    Name = employeeName,
                    Age = employeeAge,
                    DepartmentId = departmentId

                };

                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Employee added successfully.");
            }
        }

        //    public static Employee SetData()
        //{
        //    using (CompanyDBContext context = new CompanyDBContext())
        //    {
        //        Console.Clear();

        //        // Input Name
        //        string name;
        //        do
        //        {
        //            Console.WriteLine("Enter Employee Name (non-empty):");
        //            name = Console.ReadLine();
        //            if (string.IsNullOrWhiteSpace(name))
        //            {
        //                Console.WriteLine("Name cannot be empty. Please try again.");
        //            }
        //        } while (string.IsNullOrWhiteSpace(name));

        //        // Input Salary
        //        int salary;
        //        do
        //        {
        //            Console.WriteLine("Enter Employee Salary (positive integer):");
        //            if (!int.TryParse(Console.ReadLine(), out salary) || salary <= 0)
        //            {
        //                Console.WriteLine("Invalid salary input. Please enter a positive integer.");
        //            }
        //        } while (salary <= 0);

        //        // Input Gender
        //        Gender employeeGender;
        //        int gender;
        //        do
        //        {
        //            Console.WriteLine("Enter Employee Gender:");
        //            Console.WriteLine("0: Male");
        //            Console.WriteLine("1: Female");
        //            if (int.TryParse(Console.ReadLine(), out gender) && Enum.IsDefined(typeof(Gender), gender))
        //            {
        //                employeeGender = (Gender)gender;
        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid gender input. Please enter 0 for Male or 1 for Female.");
        //            }
        //        } while (true);

        //        // Input Age
        //        int age;
        //        do
        //        {
        //            Console.WriteLine("Enter Age (positive integer):");
        //            bool isValidAge = int.TryParse(Console.ReadLine(), out age);
        //            if (!isValidAge || age <= 0 || age < 18)
        //            {
        //                Console.WriteLine("Invalid age input. Please enter a positive integer and ensure the employee is at least 18 years old.");
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        } while (true);

        //        // Select Department
        //        var departments = context.Departments.ToList();
        //        if (departments.Count == 0)
        //        {
        //            Console.WriteLine("No departments available. Please create a department first.");
        //            return null;
        //        }

        //        Console.WriteLine("Choose a department:");
        //        for (int i = 0; i < departments.Count; i++)
        //        {
        //            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        //        }

        //        int deptIndex = 0;
        //        do
        //        {
        //            Console.WriteLine("Enter the number corresponding to the department:");
        //        } while (!int.TryParse(Console.ReadLine(), out deptIndex) || deptIndex < 1 || deptIndex > departments.Count);

        //        var selectedDepartment = departments[deptIndex - 1];

        //        var newEmployee = new Employee(name, salary, employeeGender, age)
        //        {
        //            Department = selectedDepartment
        //        };

        //        context.Employees.Add(newEmployee);
        //        context.SaveChanges();
        //        Console.WriteLine("Employee added successfully!");
        //        Console.ReadLine(); // Pause to view the message

        //        return newEmployee;
        //    }

        public static void DisplayMethod()
        {
            Console.Clear();

            Console.WriteLine("1-Display Department");
            Console.WriteLine("2-Display Employee");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayDepartment();
                    break;
                case "2":
                    DisplayEmployee();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.ReadLine();
        }
       

        public static void DisplayDepartment()
        {
            using (CompanyDBContext context = new CompanyDBContext())
            {
                var Departments = context.Departments.ToList();
                foreach (var department in Departments)
                {
                    Console.WriteLine($"ID = {department.Id} " + department.Name);

                }
            }
        }

        private static void DisplayEmployee()
        {
            using (CompanyDBContext context = new CompanyDBContext())
            {
                var Employees = context.Employees
                    .Include(e => e.Department)
                    .ToList();
                foreach (var employee in Employees)
                {
                    Console.WriteLine($"ID = {employee.Id} " + employee.Name + " " + employee.Age + " " + employee.Department.Name);

                }
            }
        }

    }



    
    }

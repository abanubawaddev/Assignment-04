namespace Assignment_04
{
  
            namespace Assignment02OOP
    {
       

        [Flags]
        public enum SecurityPrivilege
        {
            Guest = 1,
            Developer = 2,
            Secretary = 4,
            DBA = 8,
            SecurityOfficer = 15 
        }

        public enum Gender
        {
            M,
            F
        }

        public class HireDate
        {
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }

            public HireDate(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public override string ToString()
            {
                return $"{Day:D2}/{Month:D2}/{Year}";
            }
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public SecurityPrivilege SecurityLevel { get; set; }
            public decimal Salary { get; set; }
            public HireDate HireDate { get; set; }
            public Gender Gender { get; set; }

            public Employee(int id, string name, SecurityPrivilege securityLevel, decimal salary, HireDate hireDate, Gender gender)
            {
                ID = id;
                Name = name;
                SecurityLevel = securityLevel;
                Salary = salary;
                HireDate = hireDate;
                Gender = gender; 
            }

            public override string ToString()
            {
                
                return string.Format("ID: {0}, Name: {1}, Gender: {2}, Security: {3}, Salary: {4:C}, Hire Date: {5}",
                    ID, Name, Gender, SecurityLevel, Salary, HireDate);
            }
        }


        public class Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Shape(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double Area()
            {
                return Width * Height;
            }

            public override string ToString()
            {
                return $"(Width = {Width}, Height = {Height})";
            }
        }

        public class Cube : Shape
        {
            public double Depth { get; set; }

            public Cube(double width, double height, double depth) : base(width, height)
            {
                Depth = depth;
            }

            public new double Area()
            {
                return base.Area() * Depth;
            }

            public void Print()
            {
                Console.WriteLine($"Width = {Width}, Height = {Height}, Depth = {Depth}");
            }
        }

        

        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public void Greet()
            {
                Console.WriteLine("I am a person's basic data. Person.");
            }

            public virtual void Display()
            {
                Console.WriteLine($"ID: {ID}, Name: {Name}, Age: {Age}");
            }
        }

        public class Doctor : Person
        {
            public string Specialty { get; set; }

            public new void Greet()
            {
                Console.WriteLine("I am a doctor.");
            }

            public override void Display()
            {
                Console.WriteLine($"ID: {ID}, Name: {Name}, Age: {Age}, Specialty: {Specialty}");
            }
        }

        public class Engineer : Person
        {
            public string Field { get; set; }

            public new void Greet()
            {
                Console.WriteLine("I am an engineer.");
            }

            public override void Display()
            {
                Console.WriteLine($"ID: {ID}, Name: {Name}, Age: {Age}, Field: {Field}");
            }
        }

        class Program
        {
            static void ProcessPerson(Person person)
            {
                person.Greet();
                person.Display();

            }
            static void Main(string[] args)
            {
               
                Employee[] EmpArr = new Employee[3];
                EmpArr[0] = new Employee(1, "Ahmed", SecurityPrivilege.DBA, 5000m, new HireDate(1, 5, 2020), Gender.M);
                EmpArr[1] = new Employee(2, "Sara", SecurityPrivilege.Guest, 2000m, new HireDate(15, 8, 2021), Gender.F);
                EmpArr[2] = new Employee(3, "Omar", SecurityPrivilege.SecurityOfficer, 9000m, new HireDate(10, 10, 2018), Gender.M);

                Console.WriteLine("--- Employees ---");
                foreach (var emp in EmpArr)
                {
                    Console.WriteLine(emp.ToString());
                }

                
                Console.WriteLine("\n--- Shape & Cube (Early Binding) ---");
                Shape shape = new Shape(2, 3);
                Console.WriteLine($"Shape Area: {shape.Area()}");

                Cube cube = new Cube(2, 3, 4);
                Console.WriteLine($"Cube Area: {cube.Area()}");

                Shape shapeRef = new Cube(2, 3, 4);
                Console.WriteLine($"ShapeRef Area: {shapeRef.Area()}");
               
                object obj = new Cube(1, 2, 3);
                Console.WriteLine(obj.ToString());
                
                Console.WriteLine("\n--- Person, Doctor & Engineer (Late Binding) ---");
                Person doctor = new Doctor { ID = 101, Name = "Ali", Age = 45, Specialty = "Surgery" };
                Person engineer = new Engineer { ID = 102, Name = "Mona", Age = 30, Field = "Software" };

                ProcessPerson(doctor);
                ProcessPerson(engineer);
                
            }
        }
    }

}
    


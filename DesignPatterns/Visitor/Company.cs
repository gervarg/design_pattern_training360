namespace Visitor
{
    // Visitee
    internal abstract class Employee
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int NumberOfChildren { get; set; }

        public int AnnualBonus { get; set; }

        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void Accept(IEmployeeOperation employeeOperation);
        public abstract T Accept<T>(IEmployeeOperation<T> employeeOperation);
    }

    internal class SalesRepresentative : Employee
    {
        public SalesRepresentative(string name, int age) : base(name, age)
        {
        }

        public override void Accept(IEmployeeOperation employeeOperation)
        {
            employeeOperation.Visit(this);
        }

        public override T Accept<T>(IEmployeeOperation<T> employeeOperation)
        {
            return employeeOperation.Visit(this);
        }
    }

    internal class HrGeneralist : Employee
    {
        public HrGeneralist(string name, int age) : base(name, age)
        {
        }

        public override void Accept(IEmployeeOperation employeeOperation)
        {
            employeeOperation.Visit(this);
        }

        public override T Accept<T>(IEmployeeOperation<T> employeeOperation)
        {
            return employeeOperation.Visit(this);
        }
    }

    internal class Manager : Employee
    {
        public Manager(string name, int age) : base(name, age)
        {
        }

        public override void Accept(IEmployeeOperation employeeOperation)
        {
            employeeOperation.Visit(this);
        }

        public override T Accept<T>(IEmployeeOperation<T> employeeOperation)
        {
            return employeeOperation.Visit(this);
        }
    }

    internal class Developer : Employee
    {
        public Developer(string name, int age) : base(name, age)
        {
        }

        public override void Accept(IEmployeeOperation employeeOperation)
        {
            employeeOperation.Visit(this);
        }

        public override T Accept<T>(IEmployeeOperation<T> employeeOperation)
        {
            return employeeOperation.visit(this);
        }
    }

    // Visitor with no return type
    internal interface IEmployeeOperation
    {
        void Visit(SalesRepresentative salesRepresentative);
        void Visit(HrGeneralist hrGeneralist);
        void Visit(Manager manager);
        void Visit(Developer developer);
    }

    internal interface IEmployeeOperation<T>
    {
        T Visit(SalesRepresentative salesRepresentative);
        T Visit(HrGeneralist hrGeneralist);
        T Visit(Manager manager);
        T visit(Developer developer);
    }

    internal class CalculateHolidays : IEmployeeOperation<int>
    {
        public int visit(Developer developer)
        {
            return AccordingToTheLaw(developer);
        }        

        public int Visit(HrGeneralist hrGeneralist)
        {
            return AccordingToTheLaw(hrGeneralist);
        }

        public int Visit(Manager manager)
        {
            return AccordingToTheLaw(manager);
        }

        public int Visit(SalesRepresentative salesRepresentative)
        {
            return AccordingToTheLaw(salesRepresentative);
        }

        private int AccordingToTheLaw(Employee employee)
        {
            int holidays = 20;
            
            if (25 <= employee.Age && employee.Age < 30)
            {
                holidays += 3;
            }
            else if (30 <= employee.Age && employee.Age < 35)
            {
                holidays += 6;
            }
            else
            {
                holidays += 10;
            }

            if (employee.NumberOfChildren == 1)
            {
                holidays += 2;
            }
            else if (employee.NumberOfChildren == 2)
            {
                holidays += 5;
            }
            else if (employee.NumberOfChildren > 2)
            {
                holidays += 7;
            }

            return holidays;
        }
    }

    internal class SetBonus : IEmployeeOperation
    {
        public void Visit(Developer developer)
        {
            developer.AnnualBonus = 1000;
        }

        public void Visit(HrGeneralist hrGeneralist)
        {
            hrGeneralist.AnnualBonus = 250;
        }

        public void Visit(Manager manager)
        {
            manager.AnnualBonus = 1500;
        }

        public void Visit(SalesRepresentative salesRepresentative)
        {
            salesRepresentative.AnnualBonus = 2500;
        }
    }

}

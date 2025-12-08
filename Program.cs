var departments = new List<Department>
{
    new Department { DeptId = 1, DeptName = "HR" },
    new Department { DeptId = 2, DeptName = "IT" },
    new Department { DeptId = 3, DeptName = "Finance" },
    new Department { DeptId = 4, DeptName = "Marketing" }
};

var employees = new List<Employee>
{
    new Employee { Id = 101, Name = "Amit",   Age = 28, Salary = 75000, DeptId = 2, Skills = new List<string>{ "C#", "SQL", "Angular" } },
    new Employee { Id = 102, Name = "Neha",   Age = 34, Salary = 95000, DeptId = 2, Skills = new List<string>{ "Java", "C#", "React" } },
    new Employee { Id = 103, Name = "Raj",    Age = 45, Salary = 60000, DeptId = 1, Skills = new List<string>{ "Excel", "Communication" } },
    new Employee { Id = 104, Name = "Priya",  Age = 29, Salary = 82000, DeptId = 3, Skills = new List<string>{ "Accounting", "SQL" } },
    new Employee { Id = 105, Name = "Karan",  Age = 31, Salary = 88000, DeptId = 2, Skills = new List<string>{ "C#", "Azure", "Docker" } },
    new Employee { Id = 106, Name = "Simran", Age = 26, Salary = 72000, DeptId = 4, Skills = new List<string>{ "Design", "Photoshop" } }
};


//Get a list containing only the names of all employees.
var employeeNames = employees.Select(e => e.Name).ToList();

//Create a list of anonymous objects with each employee’s Name and Annual Salary (Salary × 12).
var employeeAnnualSalaries = employees
    .Select(e => new { e.Name, AnnualSalary = e.Salary * 12 })
    .ToList();

//Retrieve Name and Salary of all employees older than 30 years.
var employeesOlderThan30 = employees
    .Where(e => e.Age > 30)
    .Select(e => new { e.Name, e.Salary })
    .ToList();

//Show complete details of all employees who belong to the IT department.
var itDepartmentId = departments.First(d => d.DeptName == "IT").DeptId;
var itEmployees = employees
    .Where(e => e.DeptId == itDepartmentId)
    .ToList();

//Produce a single flat list of every skill known by any employee.
var allSkills = employees
    .SelectMany(e => e.Skills)
    .ToList();

//Get a list of all unique skills present in the company (no duplicates).
var uniqueSkills = employees
    .SelectMany(e => e.Skills)
    .Distinct()
    .ToList();

//List all skills known by employees earning more than 80,000.
var skillsOfHighEarners = employees
    .Where(e => e.Salary > 80000)
    .SelectMany(e => e.Skills)
    .Distinct()
    .ToList();


//Given this mixed list:
//List<object> mixed = new List<object> { employees[0], "hello", employees[1], 999, employees[2] };
//Extract only the actual Employee objects.
//From the mixed list above, extract only the names of the Employee objects.


//Return the first three employees in the current order of the list.
var firstThreeEmployees = employees
    .Take(3)
    .ToList();

//Display the names and salaries of the four highest-paid employees.
var topFourHighestPaid = employees
    .OrderByDescending(e => e.Salary)
    .Take(4)
    .Select(e => new { e.Name, e.Salary })
    .ToList();

//Show employees in positions 3 to 5 (pagination – third, fourth, and fifth employees).
var employeesPosition3To5 = employees
    .Skip(2)
    .Take(3)
    .ToList();

//Assuming employees are sorted by increasing Age, return employees until you reach the first one aged 32 or older (do not include that person).
var employeesYoungerThan32 = employees
    .TakeWhile(e => e.Age < 32)
    .ToList();

//Skip all employees earning 80,000 or more, then return the remaining employees.
var employeesEarningLessThan80000 = employees
    .SkipWhile(e => e.Salary >= 80000)
    .ToList();

//Get the distinct department names that employees belong to.
var distinctDepartmentNames = employees
    .Join(departments,
          e => e.DeptId,
          d => d.DeptId,
          (e, d) => d.DeptName)
    .Distinct()
    .ToList();

//Find the first employee whose name starts with the letter 'P'.
var firstEmployeeStartingWithP = employees
    .FirstOrDefault(e => e.Name.StartsWith("P"));

//Find the first employee in the Finance department; return null if none exists.
var firstEmployeeEndingWithP = employees
    .FirstOrDefault(e => e.Name.EndsWith("P"));

//Retrieve the employee with Id = 103 (Id is unique).
var employeeWithId103 = employees
    .SingleOrDefault(e => e.Id == 103);

//Try to find an employee with Id = 999; return null if not found.
var employeeWithId104 = employees
    .SingleOrDefault(e => e.Id == 999);

//Check whether there is at least one employee younger than 28 years.
var hasEmployeeYoungerThan28 = employees
    .Any(e => e.Age < 28);

//Check whether any employee in the IT department knows the skill "React".
var itEmployeesKnowReact = employees
    .Where(e => e.DeptId == itDepartmentId)
    .Any(e => e.Skills.Contains("React"));

//Verify whether every employee in the IT department earns more than 70,000.
var employeesKnowReact = employees
    .Where(e => e.DeptId == itDepartmentId)
    .All(e => e.Salary > 70000);

//Verify whether every employee has at least one skill in their Skills list.
var allEmployeesHaveSkills = employees
    .All(e => e.Skills != null && e.Skills.Count > 0);

//Determine whether the skill "Docker" is known by at least one employee's skill list.
var isDockerKnown = employees
    .Any(e => e.Skills.Contains("Docker"));

//Get the names of the three youngest employees who know "C#", sorted from youngest to oldest.
var threeYoungestCSharpDevelopers = employees
    .Where(e => e.Skills.Contains("C#"))
    .OrderBy(e => e.Age)
    .Take(3)
    .Select(e => e.Name)
    .ToList();
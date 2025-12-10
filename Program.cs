using static System.Collections.Specialized.BitVector32;

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




//Lab-6

var students = new List<Student>
{
 new Student { Rno = 1, Name = "Amit", Branch = "CE", Sem = 3, CPI = 8},
 new Student { Rno = 2, Name = "Priya", Branch = "IT", Sem = 5, CPI = 9 },
 new Student { Rno = 3, Name = "Rahul", Branch = "CE", Sem = 1, CPI = 7 },
 new Student { Rno = 4, Name = "Sneha", Branch = "ME", Sem = 7, CPI = 8 },
 new Student { Rno = 5, Name = "Karan", Branch = "IT", Sem = 3, CPI = 6 }
};


var courses = new List<Course>
{
 new Course { Rno = 1, CourseName = "DBMS", Credits = 4 },
 new Course { Rno = 1, CourseName = "C#", Credits = 3 },
 new Course { Rno = 2, CourseName = "Java", Credits = 4 },
 new Course { Rno = 3, CourseName = "Python", Credits = 3 },
 new Course { Rno = 5, CourseName = "AI", Credits = 5 }
};



//SECTION 1 — FILTERING (Where) — 15 Questions
//1.Get all CE branch students.
var ceStudents = students
    .Where(s => s.Branch == "CE")
    .ToList();

//2. Students having CPI > 8.
var highCPIStudents = students
    .Where(s => s.CPI > 8)
    .ToList();

//3. Students older than 20.
var studentsOlderThan20 = students
    .Where(s => s.Age > 20)
    .ToList();

//4. Students in Semester 3.
studentsOlderThan20 = students
    .Where(s => s.Sem == 3)
    .ToList();

//5. CPI between 7 and 9.
var studentsWithCPIBetween7And9 = students
    .Where(s => s.CPI >= 7 && s.CPI <= 9)
    .ToList();

//6. Name starting with 'A'.
var studentsWithNameStartingWithA = students
    .Where(s => s.Name.StartsWith("A"))
    .ToList();

//7. Branch = IT AND Sem = 3.
var itStudentsInSem3 = students
    .Where(s => s.Branch == "IT" && s.Sem == 3)
    .ToList();

//8. Age < 20 OR CPI > 8.
var youngOrHighCPIStudents = students
    .Where(s => s.Age < 20 || s.CPI > 8)
    .ToList();

//9. Names containing 'a'.
var studentsWithNameContainingA = students
    .Where(s => s.Name.Contains("a"))
    .ToList();

//10. Students NOT in CE.
var nonCEStudents = students
    .Where(s => s.Branch != "CE")
    .ToList();

//11. Sem in {1,3,5}.
var studentsInOddSemesters = students
    .Where(s => new[] { 1, 3, 5 }.Contains(s.Sem))
    .ToList();

//12.Students whose CPI is a whole number.
studentsWithNameStartingWithA = students
    .Where(s => s.CPI % 1 == 0)
    .ToList();

//13. Students with even Roll No.
var studentsWithEvenRollNo = students
    .Where(s => s.Rno % 2 == 0)
    .ToList();

//14. Students whose age is between 18 and 21.
var studentsAged18To21 = students
    .Where(s => s.Age >= 18 && s.Age <= 21)
    .ToList();

//15. Students having name length > 4.
var studentsWithLongNames = students
    .Where(s => s.Name.Length > 4)
    .ToList();



//SECTION 2 — SELECT (Projection) — 10 Questions

//16.Select only names.
var studentNames = students
    .Select(s => s.Name)
    .ToList();

//17.Select Name + CPI.
var nameAndCPI = students
    .Select(s => new { s.Name, s.CPI })
    .ToList();

//18.Select Roll No + Branch.
var rollNoAndBranch = students
    .Select(s => new { s.Rno, s.Branch })
    .ToList();

//19. Select anonymous type: Name, Sem, Age.
var nameSemAge = students
    .Select(s => new { s.Name, s.Sem, s.Age })
    .ToList();

//20. Create 'FullInfo' string (e.g., "Name (Branch)").
var fullInfoStrings = students
    .Select(s => $"{s.Name} ({s.Branch})")
    .ToList();

//21. Project all to CPI only.
var cpiList = students
    .Select(s => s.CPI)
    .ToList();

//22. Select Name in lowercase.
var namesInLowercase = students
    .Select(s => s.Name.ToLower())
    .ToList();

//23. Select Name + Status based on CPI (Good/Average).
var nameAndStatus = students
    .Select(s => new
    {
        s.Name,
        Status = s.CPI >= 8 ? "Good" : "Average"
    })
    .ToList();

//24. Extract only distinct branches.
var distinctBranches = students
    .Select(s => s.Branch)
    .Distinct()
    .ToList();

//25. Convert student to “DTO” format (Rno, Name).
var studentDTOs = students
    .Select(s => new StudentDTO { Rno = s.Rno, Name = s.Name })
    .ToList();


//foreach (var item in studentDTOs)
//{
//    Console.WriteLine(item.Name);    
//}



//SECTION 3 — SORTING (OrderBy) — 10 Questions


//26.Sort names alphabetically.
var namesSortedAlphabetically = students
    .OrderBy(s => s.Name)
    .ToList();

//27.Sort by CPI descending.
var studentsSortedByCPIDesc = students
    .OrderByDescending(s => s.CPI)
    .ToList();

//28. Sort by Sem, then Name.
var studentsSortedBySemThenName = students
    .OrderBy(s => s.Sem)
    .ThenBy(s => s.Name)
    .ToList();

//29.Sort by Age, then CPI desc.
var studentsSortedByAgeThenCPIDesc = students
    .OrderBy(s => s.Age)
    .ThenByDescending(s => s.CPI)
    .ToList();

//30. Sort by Branch.
var studentsSortedByBranch = students
 .OrderBy(s => s.Branch)
 .ToList();

//31. Sort by Name length.
var studentsSortedByNameLength = students
 .OrderBy(s => s.Name.Length)
 .ToList();

//32. Sort by Sem DESC.
var studentsSortedBySemDesc = students
 .OrderByDescending(s => s.Sem)
 .ToList();

//33. Sort by CPI then Age.
var studentsSortedByCPIThenAge = students
 .OrderBy(s => s.CPI)
 .ThenBy(s => s.Age)
 .ToList();

//34. Sort by Rno descending.
studentsSortedByNameLength = students
    .OrderByDescending(s => s.Rno)
    .ToList();

//35. Sort by Branch then Sem.
var studentsSortedByBranchThenSem = students
 .OrderBy(s => s.Branch)
 .ThenBy(s => s.Sem)
 .ToList();

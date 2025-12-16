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

var studentsList = new List<Student>
{
    new Student { Rno = 1, Name = "Amit",  Branch = "CE", Sem = 3, CPI = 8.0, Age = 19 },
    new Student { Rno = 2, Name = "Priya", Branch = "IT", Sem = 5, CPI = 9.0, Age = 21 },
    new Student { Rno = 3, Name = "Rahul", Branch = "CE", Sem = 1, CPI = 7.0, Age = 18 },
    new Student { Rno = 4, Name = "Sneha", Branch = "ME", Sem = 7, CPI = 8.0, Age = 22 },
    new Student { Rno = 5, Name = "Karan", Branch = "IT", Sem = 3, CPI = 6.0, Age = 20 },
};

var courses = new List<Course>
{
    new Course { Rno = 1, CourseName = "DBMS",  Credits = 4 },
    new Course { Rno = 1, CourseName = "C#",    Credits = 3 },
    new Course { Rno = 2, CourseName = "Java",  Credits = 4 },
    new Course { Rno = 3, CourseName = "Python",Credits = 3 },
    new Course { Rno = 5, CourseName = "AI",    Credits = 5 },
};

//---------------------------SECTION 1 — FILTERING (Where) — 15Questions
//1.Get all CE branch studentsList.
var q1 = studentsList.Where(s => s.Branch == "CE");
//foreach (var s in q1)
//{
//    Console.WriteLine(s.Name);
//}

//2.studentsList having CPI > 8.
var q2 = studentsList.Where(s => s.CPI > 8);
//foreach (var s in q2)
//{
//    Console.WriteLine($"{s.Name} - {s.CPI}");
//}

//3.studentsList older than 20.
var q3 = studentsList.Where(s => s.Age > 20);
//foreach (var s in q3)
//{
//    Console.WriteLine($"{s.Name} - {s.Age}");
//}

//4.studentsList in Semester 3.
var q4 = studentsList.Where(s => s.Sem == 3);
//foreach (var s in q4)
//{
//    Console.WriteLine($"{s.Name} - {s.Sem}");
//}

//5.CPI between 7 and 9.
var q5 = studentsList.Where(s => s.CPI >= 7 && s.CPI <= 9);
//foreach (var s in q5)
//{
//    Console.WriteLine($"{s.Name} - {s.CPI}");
//}

//6.Name starting with 'A'.
var q6 = studentsList.Where(s => s.Name.StartsWith("A"));
//foreach (var s in q6)
//{
//    Console.WriteLine($"{s.Name} ");
//}

//7.Branch = IT AND Sem = 3.
var q7 = studentsList.Where(s => s.Branch == "IT" && s.Sem == 3);
//foreach (var s in q7)
//{
//    Console.WriteLine($"{s.Name} - {s.Branch} - {s.Sem}");
//}

//8.Age < 20 OR CPI > 8.
var q8 = studentsList.Where(s => s.Age < 20 || s.CPI > 8);
//foreach (var s in q3)
//{
//    Console.WriteLine($"{s.Name} - {s.Age} -{s.CPI}");
//}

//9.Names containing 'a'.
var q9 = studentsList.Where(s => s.Name.ToLower().Contains("a"));
//foreach (var s in q9)
//{
//    Console.WriteLine($"{s.Name}");
//}

//10.studentsList NOT in CE.
var q10 = studentsList.Where(s => s.Branch != "CE");
//foreach (var s in q10)
//{
//    Console.WriteLine($"{s.Name} - {s.Branch}");
//}

//11.Sem in {1,3,5}.
var q11 = studentsList.Where(s => new[] { 1, 3, 5 }.Contains(s.Sem));
//foreach (var s in q11)
//{
//    Console.WriteLine($"{s.Name} - {s.Sem}");
//}

//12.studentsList whose CPI is a whole number.
var q12 = studentsList.Where(s => s.CPI % 1 == 0);
//foreach (var s in q12)
//{
//    Console.WriteLine($"{s.Name} - {s.CPI}");
//}

//13.studentsList with even Roll No.
var q13 = studentsList.Where(s => s.Rno % 2 == 0);
//foreach (var s in q13)
//{
//    Console.WriteLine($"{s.Name} - {s.Rno}");
//}

//14.studentsList whose age is between 18 and 21.
var q14 = studentsList.Where(s => s.Age >= 18 && s.Age <= 21);
//foreach (var s in q14)
//{
//    Console.WriteLine($"{s.Name} - {s.Age}");
//}

//15.studentsList having name length > 4.
var q15 = studentsList.Where(s => s.Name.Length > 4);
//foreach (var s in q15)
//{
//    Console.WriteLine($"{s.Name} ");
//}


//---------------------------SECTION 2 — SELECT (Projection) — 10Questions
//16.Select only names.
var s1 = studentsList.Select(s => s.Name);
//foreach (var name in s1)
//{
//    Console.WriteLine(name);
//}

//17.Select Name + CPI.
var s2 = studentsList.Select(s => new { s.Name, s.CPI });
//foreach (var s in s2)
//{
//    Console.WriteLine($"{s.Name} - {s.CPI}");
//}

//18.Select Roll No + Branch.
var s3 = studentsList.Select(s => new { s.Rno, s.Branch });
//foreach (var s in s3)
//{
//    Console.WriteLine($"{s.Rno} - {s.Branch}");
//}

//19.Select anonymous type: Name, Sem, Age.
var s4 = studentsList.Select(s => new { s.Name, s.Sem, s.Age });
//foreach (var s in s4)
//{
//    Console.WriteLine($"{s.Name} - Sem:{s.Sem} - Age:{s.Age}");
//}

//20.Create 'FullInfo' string (e.g., "Name (Branch)").
var s5 = studentsList.Select(s => $"{s.Name} ({s.Branch})");
//foreach (var info in s5)
//{
//    Console.WriteLine(info);
//}

//21.Project all to CPI only.
var s6 = studentsList.Select(s => s.CPI);
//foreach (var cpi in s6)
//{
//    Console.WriteLine(cpi);
//}

//22.Select Name in lowercase.
var s7 = studentsList.Select(s => s.Name.ToLower());
//foreach (var s in s7)
//{
//    Console.WriteLine(s);
//}


//23.Select Name + Status based on CPI (Good/Average).
var s8 = studentsList.Select(s => new { s.Name, Status = s.CPI >= 8 ? "Good" : "Average" });
//foreach (var s in s8)
//{
//    Console.WriteLine($"{s.Name} - {s.Status}");
//}

//24.Extract only distinct branches.
var s9 = studentsList.Select(s => s.Branch).Distinct();
//foreach (var branch in s9)
//{
//    Console.WriteLine(branch);
//}

//25.Convert student to “DTO” format (Rno, Name).
var s10 = studentsList.Select(s => new { s.Rno, s.Name });
//foreach (var dto in s10)
//{
//    Console.WriteLine($"{dto.Rno} - {dto.Name}");
//}


//---------------------------SECTION 3 — SORTING (OrderBy) — 10Questions
//26.Sort names alphabetically.
var n1 = studentsList.OrderBy(s => s.Name);
//foreach (var s in n1)
//{
//    Console.WriteLine(s.Name);
//}

//27.Sort by CPI descending.
var n2 = studentsList.OrderByDescending(s => s.CPI);
//foreach (var s in n2)
//{
//    Console.WriteLine($"{s.Name} - {s.CPI}");
//}

//28.Sort by Sem, then Name.
var n3 = studentsList.OrderBy(s => s.Sem).ThenBy(s => s.Name);
//foreach (var s in n3)
//{
//    Console.WriteLine($"{s.Name} - Sem:{s.Sem}");
//}

//29.Sort by Age, then CPI desc.
var n4 = studentsList.OrderBy(s => s.Age).ThenByDescending(s => s.CPI);
//foreach (var s in n4)
//{
//    Console.WriteLine($"{s.Name} - Age:{s.Age} - CPI:{s.CPI}");
//}

//30.Sort by Branch.
var n5 = studentsList.OrderBy(s => s.Branch);
//foreach (var s in n5)
//{
//    Console.WriteLine($"{s.Name} - {s.Branch}");
//}

//31.Sort by Name length.
var n6 = studentsList.OrderBy(s => s.Name.Length);
//foreach (var s in n6)
//{
//    Console.WriteLine($"{s.Name} (Length: {s.Name.Length})");
//}


//32.Sort by Sem DESC.
var n7 = studentsList.OrderByDescending(s => s.Sem);
//foreach (var s in n7)
//{
//    Console.WriteLine($"{s.Name} - Sem:{s.Sem}");
//}

//33.Sort by CPI then Age.
var n8 = studentsList.OrderBy(s => s.CPI).ThenBy(s => s.Age);
//foreach (var s in n8)
//{
//    Console.WriteLine($"{s.Name} - CPI:{s.CPI} - Age:{s.Age}");
//}

//34.Sort by Rno descending.
var n9 = studentsList.OrderByDescending(s => s.Rno);
//foreach (var s in n9)
//{
//    Console.WriteLine($"{s.Rno} - {s.Name}");
//}

//35.Sort by Branch then Sem.
var n10 = studentsList.OrderBy(s => s.Branch).ThenBy(s => s.Sem);
//foreach (var s in n10)
//{
//    Console.WriteLine($"{s.Name} - {s.Branch} - Sem:{s.Sem}");
//}


//---------------------------SECTION 4 — AGGREGATION — 10Questions
//36.Count total studentsList.
var a1 = studentsList.Count();
//Console.WriteLine(a1);

//37.Count CE studentsList.
var a2 = studentsList.Count(s => s.Branch == "CE");
//Console.WriteLine(a2);

//38.Max CPI.
var a3 = studentsList.Max(s => s.CPI);
//Console.WriteLine(a3);

//39.Min CPI.
var a4 = studentsList.Min(s => s.CPI);
//Console.WriteLine(a4);

//40.Average CPI.
var a5 = studentsList.Average(s => s.CPI);
//Console.WriteLine(a5);

//41.Total credits for Rno = 1.
var a6 = courses.Where(c => c.Rno == 1).Sum(c => c.Credits);
//Console.WriteLine(a6);

//42.Oldest student's age.
var a7 = studentsList.Max(s => s.Age);
//Console.WriteLine(a7);

//43.Youngest student's age.
var a8 = studentsList.Min(s => s.Age);
//Console.WriteLine(a8);

//44.Highest Sem.
var a9 = studentsList.Max(s => s.Sem);
//Console.WriteLine(a9);

//45.Sum of all credits.
var a10 = courses.Sum(c => c.Credits);
//Console.WriteLine(a10);



//---------------------------SECTION 5 — ELEMENT OPERATIONS — 10Questions
//46. Get first student.
var p1 = studentsList.First();
//Console.WriteLine($"{p1.Rno} - {p1.Name} - {p1.CPI}");

//47. First student with CPI > 9.
var p2 = studentsList.First(s => s.CPI < 9);
//Console.WriteLine($"{p2.Name} - {p2.CPI}");

//48. Last student.
var p3 = studentsList.Last();
//Console.WriteLine($"{p3.Name} - {p3.CPI}");

//49. Get student at index 2.
var p4 = studentsList.ElementAt(2);
//Console.WriteLine($"{p4.Name}");

//50. Single student with Rno = 3.
var p5 = studentsList.Single(s => s.Rno == 3);
//Console.WriteLine($"{p5.Name}");

//51. Safe single (e.g., Rno = 10).
var p6 = studentsList.SingleOrDefault(s => s.Rno == 10);
//if (p6 == null)
//    Console.WriteLine("Not Found");
//else
//    Console.WriteLine(p6.Name);

//52. First IT student.
var p7 = studentsList.First(s => s.Branch == "IT");
//Console.WriteLine($"{p7.Name}");

//53. Last CE student.
var p8 = studentsList.Last(s => s.Branch == "CE");
//Console.WriteLine($"{p8.Name}");

//54. First student older than 18.
var p9 = studentsList.First(s => s.Age > 18);
//Console.WriteLine($"{p9.Name} - {p9.Age}");

//55. Element at index 0
var p10 = studentsList.ElementAt(0);
//Console.WriteLine($"{p10.Name}");




//---------------------------SECTION 6 — ANY / ALL — 10 Questions
//56. Any CE studentsList?
//Console.WriteLine("56. Any CE studentsList?");
//Console.WriteLine(studentsList.Any(s => s.Branch == "CE") ? "Yes" : "No");

//57. All studentsList older than 17?
//Console.WriteLine("57. All studentsList older than 17?");
//Console.WriteLine(studentsList.All(s => s.Age > 17) ? "Yes" : "No");

//58. Any CPI > 9?
//Console.WriteLine("58. Any CPI > 9?");
//Console.WriteLine(studentsList.Any(s => s.CPI > 9) ? "Yes" : "No");

//59. All semesters are > 0?
//Console.WriteLine("59. All semesters are > 0?");
//Console.WriteLine(studentsList.All(s => s.Sem > 0) ? "Yes" : "No");

//60. Any student with name length > 6?
//Console.WriteLine("60. Any student with name length > 6?");
//Console.WriteLine(studentsList.Any(s => s.Name.Length > 6) ? "Yes" : "No");

//61. All belong to CE?
//Console.WriteLine("61. All belong to CE?");
//Console.WriteLine(studentsList.All(s => s.Branch == "CE") ? "Yes" : "No");

//62. Any course with credits > 4?
//Console.WriteLine("62. Any course with credits > 4?");
//Console.WriteLine(courses.Any(c => c.Credits > 4) ? "Yes" : "No");

//63. All credits > 2?
//Console.WriteLine("63. All credits > 2?");
//Console.WriteLine(courses.All(c => c.Credits > 2) ? "Yes" : "No");

//64. Any course named "Java"?
//Console.WriteLine("64. Any course named 'Java'?");
//Console.WriteLine(courses.Any(c => c.CourseName == "Java") ? "Yes" : "No");


//65. Any student younger than 18?
//Console.WriteLine("65. Any student younger than 18?");
//Console.WriteLine(studentsList.Any(s => s.Age<18) ? "Yes" : "No");


//---------------------------SECTION 7 — GROUPING — 10 Questions
//66. Group studentsList by branch.
var g1 = studentsList.GroupBy(s => s.Branch);
//foreach (var g in g1)
//{
//    Console.WriteLine($"{g.Key}: {string.Join(", ", g.Select(s => s.Name))}");
//}

//67. Group by Semester.
var g2 = studentsList.GroupBy(s => s.Sem);
//foreach (var g in g2)
//{
//    Console.WriteLine($"Sem {g.Key}: {string.Join(", ", g.Select(s => s.Name))}");
//}

//68. Group by Age.
var g3 = studentsList.GroupBy(s => s.Age);
//foreach (var g in g3)
//{
//    Console.WriteLine($"Age {g.Key}: {string.Join(", ", g.Select(s => s.Name))}");
//}

//69. Group by CPI category (High/Low).
var g4 = studentsList.GroupBy(s => s.CPI >= 8.0 ? "High" : "Low");
//foreach (var g in g4)
//{
//    Console.WriteLine($"{g.Key} CPI: {string.Join(", ", g.Select(s => s.Name))}");
//}

//70. Group courses by Rno.
var g5 = courses.GroupBy(c => c.Rno);
//foreach (var g in g5)
//{
//    Console.WriteLine($"Rno {g.Key}: {string.Join(", ", g.Select(c => c.CourseName))}");
//}

//71. Group studentsList by first letter of name.
var g6 = studentsList.GroupBy(s => s.Name[0]);
//foreach (var g in g6)
//{
//    Console.WriteLine($"{g.Key}: {string.Join(", ", g.Select(s => s.Name))}");
//}

//72. Group by Branch then Sem.
var g7 = studentsList.GroupBy(s => s.Branch).Select(g => new { Branch = g.Key, SemGroups = g.GroupBy(s => s.Sem) });
//foreach (var branch in g7)
//{
//    Console.WriteLine($"Branch: {branch.Branch}");
//    foreach (var sem in branch.SemGroups)
//    {
//        Console.WriteLine($"  Sem {sem.Key}: {string.Join(", ", sem.Select(s => s.Name))}");
//    }
//}

//73. Group by age range (Teen/Adult).
var g8 = studentsList.GroupBy(s => s.Age <= 19 ? "Teen" : "Adult");
//foreach (var g in g8)
//{
//    Console.WriteLine($"{g.Key}: {string.Join(", ", g.Select(s => s.Name))}");
//}

//74. Group courses by Credits.
var g9 = courses.GroupBy(c => c.Credits);
//foreach (var g in g9)
//{
//    Console.WriteLine($"Credits {g.Key}: {string.Join(", ", g.Select(c => c.CourseName))}");
//}

//75. Group studentsList by CPI rounded
var g10 = studentsList.GroupBy(s => Math.Round(s.CPI));
//foreach (var g in g10)
//{
//    Console.WriteLine($"CPI {g.Key}: {string.Join(", ", g.Select(s => s.Name))}");
//}



//---------------------------SECTION 8 — JOIN — 10 Questions

//76. Inner Join studentsList + courses.
var join1 = studentsList.Join(courses,
                                       s => s.Rno,
                                       c => c.Rno,
                                       (s, c) => new { s.Name, c.CourseName });
//foreach (var j in join1){
//    Console.WriteLine($"{j.Name} -> {j.CourseName}");
//}

//77. Join to get total credits per student.
var join2 = courses.GroupBy(c => c.Rno)
                                     .Select(g => new {
                                         StudentName = studentsList.First(s => s.Rno == g.Key).Name,
                                         TotalCredits = g.Sum(c => c.Credits)
                                     });
//foreach (var j in join2){
//    Console.WriteLine($"{j.StudentName}: {j.TotalCredits} credits");
//}

//78. studentsList with courses (Name, CourseName, Credits).
var join3 = studentsList.Join(courses, s => s.Rno, c => c.Rno,
                            (s, c) => new { s.Name, c.CourseName, c.Credits });
//foreach (var j in join3){
//    Console.WriteLine($"{j.Name} -> {j.CourseName} ({j.Credits})");
//}

//79. Left join to include studentsList without courses.
var Join4 = from s in studentsList
            join c in courses on s.Rno equals c.Rno into sc
            from c in sc.DefaultIfEmpty()
            select new { s.Name, CourseName = c?.CourseName ?? "No Course" };
//foreach (var j in Join4){
//    Console.WriteLine($"{j.Name} -> {j.CourseName}");
//}

//80. List of all distinct courses taken.
var join5 = courses.Select(c => c.CourseName).Distinct();
//foreach (var course in join5){
//    Console.WriteLine(course);
//}

//81. studentsList having more than 1 course.
var join6 = courses.GroupBy(c => c.Rno)
                                       .Where(g => g.Count() > 1)
                                        .Select(g => studentsList.First(s => s.Rno == g.Key).Name);
//foreach (var name in join6){
//    Console.WriteLine(name);
//}

//82. Join and order by credits.
var join7 = studentsList.Join(courses, s => s.Rno, c => c.Rno,
                                  (s, c) => new { s.Name, c.CourseName, c.Credits })
                                 .OrderByDescending(x => x.Credits);
//foreach (var j in join7){
//    Console.WriteLine($"{j.Name} -> {j.CourseName} ({j.Credits})");
//}

//83. studentsList of IT with courses.
var join8 = studentsList.Where(s => s.Branch == "IT")
                          .Join(courses, s => s.Rno, c => c.Rno,
                          (s, c) => new { s.Name, c.CourseName });
//foreach (var j in join8) { 
//    Console.WriteLine($"{j.Name} -> {j.CourseName}");
//}

//84. studentsList who have no course.
var join9 = studentsList.Where(s => !courses.Any(c => c.Rno == s.Rno));
//foreach (var j in join9){
//    Console.WriteLine(j.Name);
//}

//85. studentsList + number of courses.
var join10 = from s in studentsList
             join c in courses on s.Rno equals c.Rno into sc
             select new { s.Name, Count = sc.Count() };
//foreach (var j in join10){
//    Console.WriteLine($"{j.Name} -> {j.Count} course(s)");
//}



//---------------------------SECTION 9 — SET OPERATIONS — 5
//Questions
//86. Distinct branches.
var set1 = studentsList.Select(s => s.Branch).Distinct();
//Console.WriteLine(string.Join(", ", set1));

//87. studentsList in CE or IT (Union).
var setce = studentsList.Where(s => s.Branch == "CE").Select(s => s.Name);
var setit = studentsList.Where(s => s.Branch == "IT").Select(s => s.Name);
var set2 = setce.Union(setit);
//Console.WriteLine(string.Join(", ", set2));

//88. studentsList in CE but not IT (Except).
var set3 = setce.Except(setit);
//Console.WriteLine(string.Join(", ", set3));

//89. Common semesters between CE and IT studentsList (Intersect).
var ceSem = studentsList.Where(s => s.Branch == "CE").Select(s => s.Sem);
var itSem = studentsList.Where(s => s.Branch == "IT").Select(s => s.Sem);
var set4 = ceSem.Intersect(itSem);
//Console.WriteLine(string.Join(", ", set4));

//90. Get all courses that have credits other than 3.
var set5 = courses.Where(c => c.Credits != 3).Select(c => c.CourseName).Distinct();
//Console.WriteLine(string.Join(", ", set5));



//---------------------------SECTION 10 — CONVERSION (ToList,Dictionary) — 5 Questions
//91. Convert to list.
var l1 = studentsList.Select(s => s.Name).ToList();
//l1.ForEach(n => Console.WriteLine(n));

//92. Convert to dictionary (Rno → Name).
var l2 = studentsList.ToDictionary(s => s.Rno, s => s.Name);
//foreach (var l in l2)
//    Console.WriteLine($"Rno {l.Key}: {l.Value}");

//93. Convert projected type to array (Names → string[]).
string[] l3 = studentsList.Select(s => s.Name).ToArray();
//foreach (var name in l3)
//    Console.WriteLine(name);

//94.Create lookup(Rno → Courses).
var l4 = courses.ToLookup(c => c.Rno, c => c.CourseName);
//foreach (var student in studentsList)
//{
//    var studentCourses = l4[student.Rno];
//    string coursesStr = studentCourses.Any() ? string.Join(", ", studentCourses) : "No courses";
//    Console.WriteLine($"{student.Name}: {coursesStr}");
//}

//95.Convert branch list to HashSet
var l5 = new HashSet<string>(studentsList.Select(s => s.Branch));
//foreach (var branch in l5)
//    Console.WriteLine(branch);


//---------------------------SECTION 11 — BASIC / MIXED — 5Questions
//96. Top 2 highest CPI studentsList.
var t1 = studentsList.OrderByDescending(s => s.CPI).Take(2);
//foreach (var s in t1)
//    Console.WriteLine(s.Name);

//97. Skip first 2, take next 2.
var t2 = studentsList.Skip(2).Take(2);
//foreach (var s in t2)
//    Console.WriteLine(s.Name);

//98. Find student with max CPI (full object).
var t3 = studentsList.OrderByDescending(s => s.CPI).First();
//Console.WriteLine($"{t3.Name}, " +
//    $"Branch: {t3.Branch}, Sem: {t3.Sem}," +
//    $" CPI: {t3.CPI}, Age: {t3.Age}");

//99. Get studentsList with course count + sort by count.
var t4 = studentsList
                 .Select(s => new {
                     s.Name,
                     Count = courses.Count(c => c.Rno == s.Rno)
                 })
                  .OrderByDescending(s => s.Count);
//foreach (var s in t4)
//    Console.WriteLine($"{s.Name} -> {s.Count} course(s)");

//100. Show studentsList grouped by Branch and sorted by CPI
var t5 = studentsList.GroupBy(s => s.Branch);
//foreach (var g in t5)
//{
//    Console.WriteLine($"Branch: {g.Key}");
//    foreach (var s in g.OrderByDescending(x => x.CPI))
//        Console.WriteLine($"{s.Name} -> CPI: {s.CPI}");
//    Console.WriteLine();
//}
using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace Task_2
{
    internal class Program
    {
        class Student
        {
            public int studentid;
            public string name;
            public int age;
            public List <Course> Courses;
      
            public Student(int studnetid, string name, int age)
            {
                this.studentid = studnetid;
                this.name = name;
                this.age = age;
                Courses = new();
            }
            public bool Enroll(Course course)
            {
                if (course.title is null)
                    return false;
                Courses.Add(course);
                return true;
            }
            public void StudentPrint()
            {
                Console.WriteLine($"{this.studentid}");
                Console.WriteLine($"{this.name}");
                Console.WriteLine($"{this.age}");
                for(int i = 0;i < Courses.Count;i++)
                {
                    Console.WriteLine($"{Courses[i]}");
                }
            }

        }
        class Instructor
        {
            public int instructorid;
            public string name;
            public string specialization;

            public Instructor(int instructorid, string name, string specialization)
            {
                this.instructorid = instructorid;
                this.name = name;
                this.specialization = specialization;
            }
            public void InstructorPrint()
            {
                Console.WriteLine($"{this.instructorid}");
                Console.WriteLine($"{this.name}");
                Console.WriteLine($"{this.specialization}");
            }
        }
        class Course
        {
           public int courseid;
           public string title;
           public Instructor instructor;


            public Course(int courseid, string title, Instructor instructor)
            {
                this.courseid = courseid;
                this.title = title;
                this.instructor = instructor;
            }
            public void CoursPrint()
            {
                Console.WriteLine($"{this.courseid}");
                Console.WriteLine($"{this.title}");
                Console.WriteLine($"{this.instructor}");
            }

        }
        class School
        {
            public List<Student> StudentList;
            public List<Instructor> InstructorList;
            public List<Course> CourseList;

            public School()
            {
                StudentList = new();
                InstructorList = new();
                CourseList = new();
            }
            public bool AddStudent (Student students)
            {
                if (students.name is null)
                    return false;
                StudentList.Add(students);
                return true;
            }
            public bool AddCourse(Course courses)
            {
                if (courses.title is null)
                    return false;
                CourseList.Add(courses);
                return true;
            }
            public bool AddInstructor(Instructor instructor)
            {
                if (instructor.name is null)
                    return false;
                InstructorList.Add(instructor);
                return true;
            }
            public List<Student> FindStudents(string query) 
            {
                List<Student> foundstudent = [];
                for (int i = 0; i < StudentList.Count; i++)
                {
                    if ( StudentList[i].name.ToLower().Contains(query) || StudentList[i].studentid.ToString().ToLower().Contains(query) )
                    {
                        foundstudent.Add(StudentList[i]);
                    }
                }

                return foundstudent;
            }
            public Student FindStudent(string query)
            {
                Student foundstudent;
                for (int i = 0; i < StudentList.Count; i++)
                {
                    if (StudentList[i].name.ToLower().Contains(query) || StudentList[i].studentid.ToString().ToLower().Contains(query))
                    {
                        foundstudent = StudentList[i];
                        return foundstudent;
                    }
                }

                return null;
            }
            public List<Instructor> FindInstructors(string query)
            {
                List<Instructor> foundinstructor = [];
                for (int i = 0; i < InstructorList.Count; i++)
                {
                    if (InstructorList[i].name.ToLower().Contains(query) || InstructorList [i].instructorid.ToString().ToLower().Contains(query))
                    {
                        foundinstructor.Add(InstructorList[i]);
                    }
                }

                return foundinstructor;
            }
            public Instructor FindInstructor(string query)
            {
                Instructor foundinstructor;
                for (int i = 0; i < InstructorList.Count; i++)
                {
                    if (InstructorList[i].name.ToLower().Contains(query) || InstructorList[i].instructorid.ToString().ToLower().Contains(query))
                    {
                        foundinstructor = InstructorList[i];
                        return foundinstructor;
                    }
                }
                return null;
                
            }
            public List<Course> FindCourses(string query)
            {
                List<Course> foundcourses= [];
                for (int i = 0; i < CourseList.Count; i++)
                {
                    if (CourseList[i].title.ToLower().Contains(query) || CourseList[i].courseid.ToString().ToLower().Contains(query))
                    {
                        foundcourses.Add(CourseList[i]);
                    }
                }

                return foundcourses;
            }
            public Course FindCourse(string query)
            {
                Course foundcourses;
                for (int i = 0; i < CourseList.Count; i++)
                {
                    if (CourseList[i].title.ToLower().Contains(query) || CourseList[i].courseid.ToString().ToLower().Contains(query))
                    {
                        foundcourses = CourseList[i];
                        return foundcourses;
                    }
                }

                return null;
            }
            public bool EnrollStudentInCourse(string  studentId, string courseId)
            {
                Student student = this.FindStudent(studentId);
                Course course = this.FindCourse(courseId);
                if (student is not null && course is not null)
                {
                    student.Enroll(course);
                    Console.WriteLine("Student Enrolled succsseflly");
                    return true;
                }
                Console.WriteLine("404");
                return false;
            }
                


        }
        static void Main(string[] args)
        {
            School school = new();
           string inputchar;
            do
            {
                Console.WriteLine("1  -  Add Student");
                Console.WriteLine("2  -  Add Instructor");
                Console.WriteLine("3  -  Add Course");
                Console.WriteLine("4  -  Enroll Student in Course ");
                Console.WriteLine("5  -  Show All Students");
                Console.WriteLine("6  -  Show All Courses");
                Console.WriteLine("7  -  Show All Instructors");
                Console.WriteLine("8  -  Find the student by id or name ");
                Console.WriteLine("9  -  Fine the course by id or name");
                Console.WriteLine("10 -  Exit");
                Console.WriteLine("Please Enter Your Choice");
                inputchar = Console.ReadLine();
                switch (inputchar)
                {
                    case "1":
                        Console.WriteLine("Enter Student Id");
                        int studentid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Student Age");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Student student = new(studentid, name, age);
                        school.AddStudent(student);
                        break;
                    case "2":
                        Console.WriteLine("Enter Instructor Id");
                        int instructorid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Instructor Name");
                        string instructorname = Console.ReadLine();
                        Console.WriteLine("Enter Instructor Specialization");
                        string specialization = Console.ReadLine();
                        Instructor instructor = new( instructorid, instructorname, specialization);
                        school.AddInstructor(instructor);
                        break;
                    case "3":
                        Console.WriteLine("Enter CourseId");
                        int courseid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Course InstructorID");
                        string instructorId  = Console.ReadLine();
                        Instructor foundedinstructor = school.FindInstructor(instructorId);
                        if (foundedinstructor is null)
                        {
                            Console.WriteLine("Instructor not found");
                            break;
                        }
                            
                        Course course = new(courseid, title, foundedinstructor);
                        school.AddCourse(course);
                        break;
                    case "4":
                        Console.WriteLine("Enter Student Id");
                        string studentEnrolledId = Console.ReadLine();
                        Console.WriteLine("Enter CourseId");
                        string courseEnrolledId = Console.ReadLine();
                        school.EnrollStudentInCourse(studentEnrolledId, courseEnrolledId);
                        break;
                    case "5":
                        for (int i = 0; i < school.StudentList.Count; i++)
                        {
                            school.StudentList[i].StudentPrint();
                        }
                        break;
                    case "6":
                        for (int i = 0; i < school.CourseList.Count; i++)
                        {
                            school.CourseList[i].CoursPrint();
                        }
                        break;
                    case "7":
                        for (int i = 0; i < school.InstructorList.Count; i++)
                        {
                            school.InstructorList[i].InstructorPrint();
                        }
                        break;
                    case "8":
                        Console.WriteLine("Enter Student Id");
                        string findStudentId = Console.ReadLine();
                        Student foundStudent = school.FindStudent(findStudentId);
                        if (foundStudent is null)
                        {
                            Console.WriteLine("Student not found");
                            break;
                        }
                        foundStudent.StudentPrint();
                        break;
                    case "9":
                        Console.WriteLine("Enter Course Id");
                        string findCourseId = Console.ReadLine();
                        Course foundCourseId = school.FindCourse(findCourseId);
                        if (foundCourseId is null)
                        {
                            Console.WriteLine("Student not found");
                            break;
                        }
                        foundCourseId.CoursPrint();
                        break;
                    case "10":
                        break;
                    default:
                        Console.WriteLine("Unknown selection, please try again.");
                        break;
                }

            } while (inputchar != "10");




            Console.WriteLine("Goodbye");

        }
    }
}
    
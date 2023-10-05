using System;
namespace ListsandLinkL

{
    //class for static methods (subrout) and main pgm
    public static class LinkedListSR
    {
        // initialise a list to hold student details
        static LinkedList<Student> students = new LinkedList<Student>();
        
        static void AddStudent(){
            Console.Write("Name :");
            string name = Console.ReadLine();
            Console.Write("Email :");
            string email = Console.ReadLine();
            Console.Write("Date of Birth :");
            string dob = Console.ReadLine();
            Student student= new Student(name, email, dob);
            students.AddFirst(student);
            Console.WriteLine($"The new ID is {student.ID}");

            return;
        }

        static void FindStudent(){
            int findId;
            
            Console.Write("Enter student id to find: ");
            String sId=Console.ReadLine();
            if (!Int32.TryParse(sId, out findId)) {
                Console.WriteLine("Invalid ID, must be numeric");
            } else {
                bool found=false;
                LinkedListNode<Student> studentNode  = students.First;
                while (!found && studentNode != null){
                    Console.WriteLine($"id {studentNode.Value.ID}");
                    if (studentNode.Value.ID==findId){
                        found=true;
                    } else {
                        studentNode=studentNode.Next;
                    }
                }
                
                if (!found) {
                    Console.WriteLine($"ID {findId} not found");
                } else {
                    studentNode.Value.PrintCard();
                    //code needed here 
                }
            }
        }

        static void PrintStudentList() {
            Student.PrintListHead();
            foreach (Student student in students) {
                student.PrintList();
            }
        }

        static string DisplayMenu() {
            string ch;
            Console.WriteLine("");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1) Add Student");
            Console.WriteLine("2) Find Student");
            Console.WriteLine("3) Print all students");
            Console.WriteLine("Q) Exit");
            ch=Console.ReadLine();

            return ch;
        }
        
        static void ProcessMenu(string ch){
            switch (ch) {
                case "1": {
                    AddStudent();
                    break;
                }
                case "2": {
                    FindStudent();
                    break;
                }
                case "3": {
                    PrintStudentList();
                    break;
                }
                case "4": {
                    Console.WriteLine("Not is use");
                    break;
                }
                case "q": {
                    Console.WriteLine("Goodbye");
                    break;
                }
                default: {
                    Console.WriteLine("Invalid option");
                    break;
                }
            }

            return;
        }


        public static void MainLists()
        {
            string ch;
            do {
                ch=DisplayMenu();
                ProcessMenu(ch);
            } while (ch!="q");            
        }
    }
}
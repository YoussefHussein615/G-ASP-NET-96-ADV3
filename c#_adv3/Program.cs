/*
 Advanced C# - Collections Exercises
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace c__adv3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Exercise1_StudentGradeManager();//ex1
            Exercise2_Leaderboard();//ex2
            Exercise3_PhoneBook();//ex3
            Exercise4_UniqueEmailValidator();//ex4
            Exercise5_PrintQueueSimulator();//ex5
            Exercise6_BrowserHistory();//ex6
        }

        public static void Exercise1_StudentGradeManager()
        {
            Console.WriteLine(" Ex1: Student Grade Manager");

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First: {grades.First()}");
            Console.WriteLine($"Last: {grades.Last()}");

            grades.Sort(); // Sort ascending in place
            Console.WriteLine("Sorted ascending: " + string.Join(", ", grades));

            int firstAbove90 = grades.First(g => g > 90);
            Console.WriteLine($"First grade above 90: {firstAbove90}");

            List<int> failingGrades = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing grades (below 75): " + string.Join(", ", failingGrades));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("Grades after removing failing ones: " + string.Join(", ", grades));

            bool hasPerfectScore = grades.Any(g => g == 100);
            Console.WriteLine($"Any grade equal to 100: {hasPerfectScore}");

            List<string> gradeLabels = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine("Grade labels: " + string.Join(", ", gradeLabels));

            Console.WriteLine();
        }

        // Ex2: Leaderboard 
        public static void Exercise2_Leaderboard()
        {
            Console.WriteLine("Ex2: Leaderboard");

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>
            {
                { 500, "Ahmed" },
                { 200, "Sara" },
                { 800, "Ali" },
                { 350, "Mona" }
            };

            Console.WriteLine("Leaderboard (sorted by score):");
            foreach (var entry in leaderboard)
                Console.WriteLine($"{entry.Key} = {entry.Value}");

            Console.WriteLine($"First key (lowest score): {leaderboard.Keys.First()}");
            Console.WriteLine($"First value (player with lowest score): {leaderboard.Values.First()}");

            bool hasScore500 = leaderboard.ContainsKey(500);
            Console.WriteLine($"Score 500 exists: {hasScore500}");

            if (leaderboard.TryGetValue(999, out string player999))
                Console.WriteLine($"Player with score 999: {player999}");
            else
                Console.WriteLine("Player with score 999: not found");

            leaderboard.Remove(200);
            Console.WriteLine("Leaderboard after removing score 200:");
            foreach (var entry in leaderboard)
                Console.WriteLine($"{entry.Key} = {entry.Value}");

            Console.WriteLine();
        }

        // Ex3: Phone Book
        public static void Exercise3_PhoneBook()
        {
            Console.WriteLine("Ex3: Phone Book");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Ahmed", "010-1111-1111" },
                { "Sara", "010-2222-2222" },
                { "Ali", "010-3333-3333" },
                { "Mona", "010-4444-4444" }
            };

            phoneBook["Youssef"] = "010-5555-5555";
            Console.WriteLine("Added Youssef using [] syntax.");

            // .Add() throws ArgumentException on a duplicate key.
            try
            {
                phoneBook.Add("Ahmed", "010-9999-9999");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Add() duplicate error: {ex.Message}");
            }

            // .TryAdd() returns false instead of throwing on a duplicate key.
            bool added = phoneBook.TryAdd("Ahmed", "010-9999-9999");
            Console.WriteLine($"TryAdd() duplicate succeeded: {added}");

            // Searching for a contact that doesn't exist.
            bool foundUnknown = phoneBook.TryGetValue("Khaled", out string khaledNumber);
            Console.WriteLine($"Search for 'Khaled' found: {foundUnknown}");

            // Get a contact with a fallback value.
            string mariamNumber = phoneBook.TryGetValue("Mariam", out string number) ? number : "Not Found";
            Console.WriteLine($"Mariam's number: {mariamNumber}");

            Console.WriteLine("Keys: " + string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));

            Console.WriteLine();
        }

        // Ex4: Unique Email Validator 
        public static void Exercise4_UniqueEmailValidator()
        {
            Console.WriteLine("Ex4: Unique Email Validator");

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine($"Count: {emails.Count}");
            Console.WriteLine("Explanation: only 2 are stored because the HashSet uses a " +
                               "case-insensitive comparer, so \"ahmed@test.com\"/\"AHMED@test.com\" " +
                               "are treated as the same element, and likewise for the two \"sara\" variants.");

            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            HashSet<int> unionResult = new HashSet<int>(setA);
            unionResult.UnionWith(setB);
            Console.WriteLine("UnionWith (A ∪ B): " + string.Join(", ", unionResult.OrderBy(n => n)));

            HashSet<int> intersectResult = new HashSet<int>(setA);
            intersectResult.IntersectWith(setB);
            Console.WriteLine("IntersectWith (A ∩ B): " + string.Join(", ", intersectResult.OrderBy(n => n)));

            HashSet<int> exceptResult = new HashSet<int>(setA);
            exceptResult.ExceptWith(setB);
            Console.WriteLine("ExceptWith (A - B): " + string.Join(", ", exceptResult.OrderBy(n => n)));

            HashSet<int> subsetCheck = new HashSet<int> { 1, 2 };
            bool isSubset = subsetCheck.IsSubsetOf(setA);
            Console.WriteLine($"{{1,2}} IsSubsetOf Set A: {isSubset}");

            Console.WriteLine();
        }

        // Ex5: Print Queue Simulator
        public static void Exercise5_PrintQueueSimulator()
        {
            Console.WriteLine("Ex5: Print Queue Simulator ");

            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue contents: " + string.Join(", ", printQueue));
            Console.WriteLine($"Count: {printQueue.Count}");

            string nextToPrint = printQueue.Peek();
            Console.WriteLine($"Peek (next to print): {nextToPrint}");

            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {doc}");
            }

            bool dequeued = printQueue.TryDequeue(out string result);
            Console.WriteLine($"TryDequeue on empty queue succeeded: {dequeued} (result is null/default: {result == null})");

            Console.WriteLine();
        }

        // Ex6: Browser History (Undo) 
        public static void Exercise6_BrowserHistory()
        {
            Console.WriteLine("Ex6: Browser History (Undo) ");

            // Stack<string>: LIFO - the most recently visited page is the
            // first one you return to when going "back", which is exactly
            // what Push/Pop give you.
            Stack<string> history = new Stack<string>();
            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            string currentPage = history.Peek();
            Console.WriteLine($"Current page: {currentPage}");

            Console.WriteLine("Pressing back 3 times:");
            for (int i = 0; i < 3; i++)
            {
                string leftPage = history.Pop();
                Console.WriteLine($"Leaving: {leftPage}");
            }

            Console.WriteLine($"Current page after going back: {history.Peek()}");
            history.Pop();
            history.Pop();

            bool popped = history.TryPop(out string poppedPage);
            Console.WriteLine($"TryPop on empty stack succeeded: {popped} (result is null/default: {poppedPage == null})");

            Console.WriteLine();
        }
    }
}

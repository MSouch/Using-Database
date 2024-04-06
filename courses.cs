using MySqlConnector; // Import MySQL Connector library
using System;
using System.Collections.Generic;

namespace UsingDatabases
{
    internal class courses
    {
        static void Main(string[] args)
        {
            // Retrieve all courses from the database
            List<Course> courses = CourseManager.GetAllCourses();

            // Display each course information
            foreach (Course course in courses)
            {
                Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.Name}, Credits: {course.Credits}");
            }
        }

        // Define the Course class
        public class Course
        {
            public int CourseId { get; set; }
            public string Name { get; set; }
            public int Credits { get; set; }
        }

    }

    internal class CourseManager
    {
        // Connection string to connect to the database
        const string connectionString = "root@localhost:3306";

        // Method to retrieve all courses from the database
        public static List<courses.Course> GetAllCourses()
        {
            List<courses.Course> courses = new List<courses.Course>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Courses";

                // Execute SQL command
                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Read data returned by SQL command
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create Course object for each row in the result set and add to the list
                            courses.Add(new courses.Course
                            {
                                CourseId = Convert.ToInt32(reader["CourseId"]),
                                Name = reader["Name"].ToString(),
                                Credits = Convert.ToInt32(reader["Credits"])
                            });
                        }
                    }
                }
            }
            return courses;
        }
    }
}


using MySqlConnector; // Import MySQL Connector library

namespace UsingDatabases
{
    internal class CourseManager
    {
        // Connection string to connect to the database
        const string connectionString = "root@localhost:3306";

        // Method to retrieve all courses from the database
        public static List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
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
                            courses.Add(new Course
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

        // Method to create a new course in the database
        public static void CreateCourse(Course course, string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Courses (Name, Credits) VALUES (@Name, @Credits)";

                // Execute SQL command
                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Name", course.Name);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.ExecuteNonQuery(); // Execute the SQL command (no result set expected)
                }
            }
        }

        // Method to retrieve all courses from the database using a provided connection string
        public static List<Course> GetAllCourses(string connectionString)
        {
            List<Course> courses = new List<Course>();
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
                            courses.Add(new Course
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

        // Method to update an existing course in the database
        public static void UpdateCourse(Course course, string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Courses SET Name = @Name, Credits = @Credits WHERE CourseId = @CourseId";

                // Execute SQL command
                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    cmd.Parameters.AddWithValue("@Name", course.Name);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.ExecuteNonQuery(); // Execute the SQL command (no result set expected)
                }
            }
        }

        // Method to delete a course from the database
        public static void DeleteCourse(int courseId, string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Courses WHERE CourseId = @CourseId";

                // Execute SQL command
                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    cmd.ExecuteNonQuery(); // Execute the SQL command (no result set expected)
                }
            }
        }
    }
}

using System;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Globalization;

namespace KeyboardWriting
{
    class DBHandler
    {
        static MySqlConnection conn;

        static string server = "";   //server address (localhost:   127.0.0.1)
        static string database = "";    //database name
        static string username = "";    //username
        static string password = "";    //password

        public static void Connect()
        {
            string connString = "Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password;
            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static bool IsUserExists(string username)
        {
            string queryString = "SELECT username FROM users";
            using (MySqlCommand query = new MySqlCommand(queryString, conn))
            {
                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString().Equals(username)) { reader.Close(); return true; };
                }

                reader.Close();
                return false;
            }
        }

        public static bool RegisterUser(string username, double time, int questionID)
        {
            string specifier = "G";
            string queryString = "INSERT INTO users(username, perfect_value, phrase_id) VALUES('" + username + "', " + time.ToString(specifier, CultureInfo.InvariantCulture) + ", " + questionID + ")";

            using (MySqlCommand query = new MySqlCommand(queryString, conn))
            {
                try
                {
                    query.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public static string GetRegistrationString(ref int questionID)
        {
            string queryString = "SELECT id FROM phrases ORDER BY id DESC LIMIT 1;";
            using (MySqlCommand query = new MySqlCommand(queryString, conn))
            {

                var reader = query.ExecuteReader();
                reader.Read();
                int phrasesCount = Convert.ToInt32(reader[0]);

                Random rand = new Random();

                int phrasesNumber = rand.Next(1, phrasesCount);

                reader.Close();

                queryString = "SELECT id, phrase FROM phrases WHERE id = " + phrasesNumber;
                using (MySqlCommand query2 = new MySqlCommand(queryString, conn))
                { 
                    reader = query2.ExecuteReader();
                    reader.Read();

                    questionID = Convert.ToInt32(reader[0]);

                    return reader[1].ToString();
                }
            }
        }



        public static string GetAuthorizationString(string username)
        {
            string queryString = "SELECT phrase_id FROM users WHERE username = '" + username + "';";
            using (MySqlCommand query = new MySqlCommand(queryString, conn))
            {
                var reader = query.ExecuteReader();
                reader.Read();
                int phraseID = Convert.ToInt32(reader[0]);

                reader.Close();

                queryString = "SELECT phrase FROM phrases WHERE id = " + phraseID;
                using (MySqlCommand query2 = new MySqlCommand(queryString, conn))
                {
                    reader = query2.ExecuteReader();
                    reader.Read();

                    return reader[0].ToString();
                }
            }
        }



        public static bool Authorize(string username, double time)
        {
            string queryString = "SELECT perfect_value FROM users WHERE username = '" + username + "'";

            using(MySqlCommand query = new MySqlCommand(queryString, conn))
            {
                var reader = query.ExecuteReader();

                reader.Read();

                double perfect = Convert.ToDouble(reader[0]);

                //string specifier = "G";
                
                if((time > perfect - perfect * 15 / 100) && (time < perfect + perfect * 15 / 100))
                {
                    return true;
                }
                return false;

            }
        }

        public static void Disconnect()
        {
            try
            {
                conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}

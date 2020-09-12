using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Methods
    {

        private SqlConnection establishConnection()
        {
          return  new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Dictionary.mdf;Integrated Security=True");
          //  SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Dictionary.mdf;Integrated Security=True;User Instance=True");

        }

        public int saveInsert(Word word)
        {
            // to keep from duplicates
            if (alreadyExists(word))
                return 0;

            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO words(russian,english,lithuanian) output INSERTED.ID VALUES(@russian, @english,@lithuanian)";
            cmd.Parameters.AddWithValue("@russian", word.russian1);
            cmd.Parameters.AddWithValue("@english", word.english1);
            cmd.Parameters.AddWithValue("@lithuanian", word.lithuanian1);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
           
            connection.Close();

            return i;

        }

        private bool alreadyExists(Word word)
        {
            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "SELECT * FROM words WHERE russian = @russian";

            bool answer = false;

            connection.Open();
            cmd.Parameters.AddWithValue("@russian", word.russian1);

            var reader = cmd.ExecuteReader();

            // if has Russian word 
            if (reader.HasRows)
            {
                answer = true;
             
            }
            reader.Close();
            // if has English word 
            cmd.CommandText = "SELECT * FROM words WHERE english = @english";
            cmd.Parameters.AddWithValue("@english", word.english1);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                answer = true;
            }
            reader.Close();

            // if has Lithuanian word 
            cmd.CommandText = "SELECT * FROM words WHERE lithuanian = @lithuanian";
            cmd.Parameters.AddWithValue("@lithuanian", word.lithuanian1);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                answer = true;
            }
            reader.Close();

            connection.Close();

            return answer;

        }
        // exists.russian1 = word.russian1;
        //exists.english1 = reader.GetString(1);
        //  exists.lithuanian1 = reader.GetString(2);



        public void display()
        {
            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM words";
            connection.Open();
            int i = cmd.ExecuteNonQuery();


        }

      

        public Word search(string word)
        {
            Word exists = new Word();
            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT english,lithuanian FROM words WHERE russian = @wordy";
            cmd.Parameters.AddWithValue("@wordy", word);

            connection.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string gg = reader["english"].ToString();
                exists =  new Word(word, reader["english"].ToString(), reader["lithuanian"].ToString());
            }
            reader.Close();


            cmd.CommandText = "SELECT russian,lithuanian FROM words WHERE english = @english";
            cmd.Parameters.AddWithValue("@english", word);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                exists = new Word(reader["russian"].ToString(), word, reader["lithuanian"].ToString());
            }
            reader.Close();


            cmd.CommandText = "SELECT russian,english FROM words WHERE lithuanian = @lithuanian";
            cmd.Parameters.AddWithValue("@lithuanian", word);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                exists = new Word(reader["russian"].ToString(), reader["english"].ToString(), word);
            }
            reader.Close();
            connection.Close();

            return exists == null? null:exists;

        }



        public void deleteAll()
        {
            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE  FROM words";
          
            connection.Open();
            int i = cmd.ExecuteNonQuery();

            connection.Close();

        }
        public void deleteOne(string id)
        {
            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE  FROM words where id =@id";
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();
            int i = cmd.ExecuteNonQuery();

            connection.Close();

        }
        public void update(Word word)
        {
            SqlConnection connection = establishConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE   words SET russian = @russian, english= @english, lithuanian = @lithuanian where id =@id";
            cmd.Parameters.AddWithValue("@id", word.id1);
            cmd.Parameters.AddWithValue("@russian", word.russian1);
            cmd.Parameters.AddWithValue("@english", word.english1);
            cmd.Parameters.AddWithValue("@lithuanian", word.lithuanian1);

            connection.Open();
            int i = cmd.ExecuteNonQuery();

            connection.Close();

        }






    }
}

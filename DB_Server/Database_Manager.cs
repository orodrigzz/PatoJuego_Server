using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Database_Manager
{

    static void Main(string[] args)
    {

        //String con los datos de conexion
        const string connectionString = "Server=db4free.net;Port=3306;database=enti_duck_game;Uid=root_duck_game;password=pass_duck_game;SSL Mode=None;connect timeout=3600;default command timeout = 3600;";

        //Clase encargada de la conexion
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            //Abro conexion
            connection.Open();
        }
        catch (Exception ex)
        {
            //Gestiono posibles errores de conexión.
            Console.WriteLine(ex.Message);
        }

        SelectExample();
        //InsertExample();
        //DeleteExample();

        //Cierro conexion
        connection.Close();

        //Funcion para eliminar datos "Hardcoded"
        void DeleteExample()
        {
            //Creo la instruccion que quiero ejecutar de SQL (clase)
            MySqlCommand command = connection.CreateCommand();

            //Añado en el atributo de la clase la query a realizar
            command.CommandText = "DELETE FROM Player Where Player.Id = 5;";

            try
            {
                //Ejecuto la instrucción, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //Funcion optimizada de select, recibe por parametro la query de la consulta y que campo debe devolver
        List<string> OptimizedStringSelectExample(string commandString, string returnedRow)
        {
            //Creo el reader para leer los datos
            MySqlDataReader reader;

            //Creo la instruccion que quiero ejecutar de SQL (clase)
            MySqlCommand command = connection.CreateCommand();

            //Añado en el atributo de la clase la query a realizar
            command.CommandText = commandString;

            //Variable para almacenar temporalmente los datos
            List<string> tmp = new List<string>();

            try
            {
                //Creo el reader para leer los datos
                reader = command.ExecuteReader();

                //Mientras haya datos voy leyendo
                while (reader.Read())
                {
                    //Almaceno el dato
                    tmp.Add(reader[returnedRow].ToString());
                }

                //Devuelvo los datos
                return tmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tmp;
            }
        }

        //Funcion de ejecutar consultas genericas asincronas, es decir, que no necesito esperar respuesta de la base de datos
        void OptimizedExecuteCommandExample(string commandString)
        {
            //Creo la instruccion que quiero ejecutar de SQL (clase)
            MySqlCommand command = connection.CreateCommand();

            //Almaceno la query recibida por parametro.
            command.CommandText = commandString;

            try
            {
                //Ejecuto la instrucción, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Funcion de insert con la query "Hardcoded"
        void InsertExample()
        {
            //Creo la instruccion que quiero ejecutar de SQL (clase)
            MySqlCommand command = connection.CreateCommand();

            //Añado en el atributo de la clase la query a realizar
            command.CommandText = "Insert Into Player Values (5, 'Testing', 543798, 'testing@testing.com', '1981-02-07', 0);";
            try
            {
                //Ejecuto la instrucción, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Funcion de select con la query "Hardcoded"
        void SelectExample()
        {

            //Creo el reader para leer los datos
            MySqlDataReader reader;

            //Creo la instruccion que quiero ejecutar de SQL (clase)
            MySqlCommand command = connection.CreateCommand();

            //Añado en el atributo de la clase la query a realizar
            command.CommandText = "Select * from Player";

            try
            {
                //Ejecuto la query (SQL es asincrono, respondera cuando quiera), interrumpe el programa hasta recibir respuesta.
                reader = command.ExecuteReader();

                //reader.Read() devuelve true mientras haya algo que leer.
                while (reader.Read())
                {
                    //Puedo leer el reader como un array [0], [1]... o directamente los campos que devuelve my query.
                    Console.WriteLine(reader["Username"].ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
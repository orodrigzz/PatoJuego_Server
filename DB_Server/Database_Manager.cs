using MySql.Data.MySqlClient;

class Database_Manager
{
    //Singleton para acceder desde otros archivos para poner activo el servicio
    public static Database_Manager _DATABASE_MANAGER;

    //String con los datos de conexion
    const string connectionString = "Server=db4free.net;Port=3306;database=duckgame;Uid=orodrigzz;password=12345678;SSL Mode=None;connect timeout=3600;default command timeout=3600;";

    //Clase encargada de la conexion
    private MySqlConnection mySqlConnection;

    //Singleton
    public Database_Manager()
    {
        if (_DATABASE_MANAGER != null && _DATABASE_MANAGER != this)
        {
            //Nada
        }
        else
        {
            //Instanciamos clase MySQL
            this.mySqlConnection = new MySqlConnection(connectionString);

            //Asignamos singleton
            _DATABASE_MANAGER = this;
        }
    }

    //Función para conectarse a la BDD
    public void ConnectDB()
    {
        try
        {
            this.mySqlConnection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectarse a la BDD");
            Console.WriteLine(ex.Message);
        }
    }

    //Función para desconectarse a la BDD
    public void DisconnectDB()
    {
        this.mySqlConnection.Close();
    }

    //Función para obtener razas
    public List<string[]> GetRaces()
    {
        //Creo el reader para leer los datos
        MySqlDataReader reader;

        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = this.mySqlConnection.CreateCommand();

        //Añado en el atributo de la clase la query a realizar
        command.CommandText = "SELECT * FROM races;";

        //Variable para almacenar temporalmente los datos
        List<string[]> data = new List<string[]>();

        try
        {
            //Creo el reader para leer los datos
            reader = command.ExecuteReader();

            //Mientras haya datos voy leyendo
            while (reader.Read())
            {
                //Almaceno el dato
                string[] fieldsData = new string[2];
                fieldsData[0] = reader[0].ToString();
                fieldsData[1] = reader[1].ToString();

                data.Add(fieldsData);
            }
            //Cierro y Devuelvo los datos
            reader.Close();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    //Función para Log In
    public string Login(string _query)
    {
        //Creo el reader para leer los datos
        MySqlDataReader reader;

        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = this.mySqlConnection.CreateCommand();

        //Añado en el atributo de la clase la query a realizar
        command.CommandText = _query;

        try
        {
            //Ejecuto la query (SQL es asincrono, respondera cuando quiera), interrumpe el programa hasta recibir respuesta.
            reader = command.ExecuteReader();

            string id_race = "";

            //Mientras haya datos voy leyendo
            while (reader.Read())
            {
                //Leo los parametros, puedo usar una string o un int para acceder a una columna
                Console.WriteLine("id_user: " + reader[0].ToString() + ", username: " + reader[1].ToString());
                id_race = reader[3].ToString();
            }
            //Cierro y Devuelvo los datos
            reader.Close();
            return id_race;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    //Función para realizar selects
    public bool Select(string _query)
    {
        //Creo el reader para leer los datos
        MySqlDataReader reader;

        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = this.mySqlConnection.CreateCommand();

        //Añado en el atributo de la clase la query a realizar
        command.CommandText = _query;

        try
        {
            //Ejecuto la query (SQL es asincrono, respondera cuando quiera), interrumpe el programa hasta recibir respuesta.
            reader = command.ExecuteReader();

            //Mientras haya datos voy leyendo
            while (reader.Read())
            {
                //Leo los parametros, puedo usar una string o un int para acceder a una columna
                Console.WriteLine("id_user: " + reader[0].ToString() + ", username: " + reader[1].ToString());

            }
            //Cierro y Devuelvo los datos
            reader.Close();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    //Función para realizar inserts
    public void Insert(string _query)
    {
        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = this.mySqlConnection.CreateCommand();

        //Añado en el atributo de la clase la query a realizar
        command.CommandText = _query;

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

    //Función para realizar deletes
    public void Delete(string _query)
    {
        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = this.mySqlConnection.CreateCommand();

        //Añado en el atributo de la clase la query a realizar
        command.CommandText = _query;

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
}
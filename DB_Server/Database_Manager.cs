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
            //Intentamos realizar conexión
            this.mySqlConnection.Open();
        }
        catch (Exception ex)
        {
            //Lanzo error
            Console.WriteLine("Error al conectarse a la BDD");
            Console.WriteLine(ex.Message);
        }
    }

    //Función para desconectarse a la BDD
    public void DisconnectDB()
    {
        this.mySqlConnection.Close();
    }
}
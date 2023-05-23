class Server {
    static void Main(string[] args)
    {
        //Bool para controlar cuando queremos apagar el servidor
        bool bServerOn = true;
		
		//Instanciamos managers
        Network_Manager Network_Service = new Network_Manager();
        new Database_Manager();

        //Iniciamos los servicios del servidor
        StartServices();

		//Mantenemos el servidor iniciado con un bucle "infinito"
        while (bServerOn)
        {
			//Comprobamos conexiones
            Network_Service.CheckConnection();
			//Desconectamos usuarios
			Network_Service.DisconnectClients();
			//Comprobamos mensajes
            Network_Service.CheckMessage();
        }

        //Init services
        void StartServices()
        {
			//Iniciamos todos los servicios existentes
            Network_Service.Start_Network_Service();

            Database_Manager._DATABASE_MANAGER.ConnectDB();
        }
    }
}

using System.Net.Sockets;

//Clase para almacenar los datos necesarios de cada cliente
class Client
{
	
    private TcpClient tcp; //Almacenamos los datos de conexion del cliente
    private string nick; //Almacenamos el nick del cliente (en este caso hardcodeado)
    private bool waitingPing; //Almacenamos si estamos a la espera que responda un ping de conexion

	//Constructor de la clase
    public Client(TcpClient tcp)
    {
        this.tcp = tcp;
        this.nick = "Anonymous";
        this.waitingPing = false;
    }

//-------------------------------- Getters ----------------------
    public TcpClient GetTcpClient()
    {
        return this.tcp;
    }

    public string GetNick()
    {
        return this.nick;
    }

    public bool GetWaitingPing()
    {
        return this.waitingPing;
    }

//-------------------------------- Setters ----------------------
    public void SetWaitingPing(bool waitingPing)
    {
        this.waitingPing = waitingPing;
    }
}
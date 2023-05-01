using System.Net.Sockets;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a TcpClient object and connect to the server on port 4948
            TcpClient client = new TcpClient();
            client.Connect("localhost", 4948);

            // Send the "change color" message to the server
            var message = new
            {
                Qualifier = "showWinningNumber",
                Data = new { WinningNumber = 34 }
            };
            string json = JsonSerializer.Serialize(message);
            byte[] data = Encoding.UTF8.GetBytes(json);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            // Shutdown and close the client socket
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }

    }
}
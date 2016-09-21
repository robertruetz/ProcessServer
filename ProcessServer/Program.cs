using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;

//TODO: Implement ProcessResponse struct
//TODO: Implement killing the ProcessServer
//TODO: Implement StartProcess()
//TODO: Implement StopProcess()
//TODO: Implement SendToProcess()
//TODO: Handle process tracking

namespace ProcessServer
{
    public class ProcessServer
    {
        public struct ProcessRequest
        {
            public string action;
            public string path;
            public string args;
        }

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 1984);
            server.Start();
            while (true)
            {
                Console.WriteLine("Waiting for a connection.");
                TcpClient client = server.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                try
                {
                    string request = sr.ReadLine();
                    Console.WriteLine(string.Format("RECEIVED: {0}", request));
                    ProcessRequest command = DeserializeJSONString(request);
                    var result = string.Empty;
                    switch (command.action)
                    {
                        case "start":
                            result = StartProcess(command);
                            break;
                        case "stop":
                            result = StopProcess(command);
                            break;
                        case "send":
                            //Handle sending a key to the process
                            break;
                        default:
                            result = ("Did not recognize that command.\n");
                            break;
                    }
                    Console.WriteLine(string.Format("RESPONSE: {0}", result));
                    sw.WriteLine(result);
                    sw.Flush();
                    sr.Close();
                }                
                catch (Exception ex)
                {
                    sw.WriteLine("The listener encountered an error.");
                    sw.Flush();
                    Console.WriteLine(ex.ToString());
                }
                client.Close();
            }
        }

        public static string StartProcess(ProcessRequest command)
        {
            string output = string.Format("Starting process {0} with args {1}", command.path, command.args);
            Console.WriteLine(output);
            return output;
        }

        public static string StopProcess(ProcessRequest command)
        {
            string output = string.Format("Stopping process {0} with args {1}", command.path, command.args);
            Console.WriteLine(output);
            return output;
        }

        public static ProcessRequest DeserializeJSONString(string input)
        {
            ProcessRequest nObj = JsonConvert.DeserializeObject<ProcessRequest>(input);
            return nObj;
        }

        public static string[] ArraySlice(string[] input, int? start, int? stop)
        {
            List<string> outList = new List<string>();
            int startIndex = start != null ? (int)start : 0;
            int stopIndex = stop != null ? (int)stop : input.Length;
            if (startIndex > input.Length || startIndex < 0)
            {
                throw new ArgumentException("Start index invalid.");
            }
            if (stopIndex < 0 || stopIndex > input.Length)
            {
                throw new ArgumentException("Stop index invalide.");
            }

            for (int x = startIndex; x < stopIndex; x++)
            {
                outList.Add(input[x]);
            }
            return outList.ToArray();
        }
    }
}

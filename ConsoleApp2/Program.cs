using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<OcorrenciaPonto> ocorrencias = new List<OcorrenciaPonto>();
            StreamReader file = new StreamReader("Abril 2017.txt");
            String linha;

            DataContractSerializer obj = new DataContractSerializer(ocorrencias.GetType());
            TextWriter arquivo = new StreamWriter("OcorrenciaPonto.xml");

            XmlWriter xw = XmlWriter.Create(arquivo);
           
        
            do
            {
                OcorrenciaPonto aux = new OcorrenciaPonto();
                linha = file.ReadLine();

                if(linha != null)
                { 
                    aux.Matricula = linha.Substring(0, 15);
                    aux.Data = linha.Substring(15, 6);
                    aux.Hora = linha.Substring(21, 4);
                    aux.Filler = linha.Substring(25, 8);
                    ocorrencias.Add(aux);
                    
                }


            } while (linha != null);
            obj.WriteObject(xw, ocorrencias);
            xw.Close();
            file.Close();
            Console.ReadKey();  
        }
    }
}

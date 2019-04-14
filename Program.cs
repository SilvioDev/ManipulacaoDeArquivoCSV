using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoArquivosIBGE
{
    class Program
    {                       
        static void Main(string[] args)
        {            
            StreamReader reader = new StreamReader("../../ibge.csv");
            int totalAcessoTodosSul = 0;            
            int[] totalAcessoMovelRegiao = new int[5];
            int totalAcessoMoveisBrasil = 0;
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string[] dadosBruto = reader.ReadLine().Split(';');
                DadosIBGE dados = new DadosIBGE();
                dados.estado = dadosBruto[0];
                dados.total = int.Parse(dadosBruto[1].Replace(" ",""));
                dados.movel = int.Parse(dadosBruto[2].Replace(" ",""));

                switch (dados.estado.ToUpper())
                {
                    case "ROND�NIA":
                    case "ACRE":
                    case "AMAZONAS":
                    case "RORAIMA":
                    case "PAR�":
                    case "AMAP�":
                    case "TOCANTINS":
                        //code norte
                        totalAcessoMovelRegiao[0] += dados.movel;
                        break;
                    case "MARANH�O":
                    case "PIAU�":
                    case "CEAR�":
                    case "RIO GRANDE DO NORTE":
                    case "PARA�BA":
                    case "PERNAMBUCO":
                    case "ALAGOAS":
                    case "SERGIPE":
                    case "BAHIA":
                        //code Nordeste
                        totalAcessoMovelRegiao[1] += dados.movel;
                        break;
                    case "MINAS GERAIS":
                    case "ESP�RITO SANTO":
                    case "RIO DE JANEIRO":
                    case "S�O PAULO":
                        //code sudeste
                        totalAcessoMovelRegiao[2] += dados.movel;
                        break;                    
                    case "PARAN�":
                    case "SANTA CATARINA":
                    case "RIO GRANDE DO SUL":
                        //code Sul
                        totalAcessoMovelRegiao[3] += dados.movel;
                        totalAcessoTodosSul += dados.total;
                        break;
                    case "MATO GROSSO DO SUL":
                    case "MATO GROSSO":
                    case "GOI�S":
                    case "DISTRITO FEDERAL":
                        //code centroOeste
                        totalAcessoMovelRegiao[4] += dados.movel;
                        break;
                }

                totalAcessoMoveisBrasil += dados.movel;
            }

            Console.WriteLine("Quantidade total de acesso à Internet por todos os tipos de aparelhos no Sul : {0}",totalAcessoTodosSul);            
            Console.WriteLine("Quantidade total de acesso por aparelhos móveis no Centro-Oeste : {0}", totalAcessoMovelRegiao[4]);
            Console.WriteLine("Quantidade total de acesso por dispositivo móvel por região : ");
            Console.WriteLine("Norte : {0}",totalAcessoMovelRegiao[0]);
            Console.WriteLine("Nordeste : {0}",totalAcessoMovelRegiao[1]);
            Console.WriteLine("Sudeste : {0}", totalAcessoMovelRegiao[2]);
            Console.WriteLine("Sul : {0}", totalAcessoMovelRegiao[3]);
            Console.WriteLine("Centro-Oeste : {0}", totalAcessoMovelRegiao[4]);
            Console.WriteLine("Quantidade total de acesso à Internet por dispositivos móveis no Brasil : {0}",totalAcessoMoveisBrasil);
            reader.Close();
            Console.ReadKey();            
        }
    }
}

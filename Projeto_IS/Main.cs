using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using Newtonsoft.Json;  //usada para converter de datatable para json string
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using NPOI.SS.UserModel;  //usada para converter de excel para datatable
using NPOI.XSSF.UserModel;  //..
using RestSharp;
using System.Xml;

using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace Projeto_IS
{
    public partial class Main : Form
    {

        public string inPath;
        public string inMethod;
        public string outMethod;
        public string outRestURI;
        public String inRESTuriAux;
        public String outRestMethod;
        public String jsonString;
        public String htmlString;
        public string outPath;

        //ja esta a funcionar, mas n garanto que quando isto for corrido em maquinas que nao as nossas funcione, quinta tenho que ver maneira melhor de fazer isto
        public string xsd = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\flowsXSD.xsd";


        public Main()
        {
            InitializeComponent();
            //iniciar os outputs a false de modo a facilitar utilizaçao, 
            //para efeitos de testes talvez seja melhor manter comentado
            //mais info ver comentarios das funcçoes permitirInput() e permitirOutput()
            //estas funcçoes estao presentes em inClickXml inClickExcel form inREST, outClickHtml e form outREST!
            permitirInput();
            // Abrir uma janela no startup a perguntar se o utilizador deseja carregar configuraçoes de fluxo previamente feitas
            //
            startup_import init = new startup_import(this);
            init.ShowDialog();
        }

        private void outHTML_Click(object sender, EventArgs e)
        {

            SaveFileDialog exportHtml = new SaveFileDialog(); // perguntamos ao utilizador onde quer guardar o ficheiro e qual o nome a dar 
            exportHtml.Filter = "Html files (*.html)|*.html";
            exportHtml.Title = "Guardar o ficheiro HTML!";

            if (exportHtml.ShowDialog() == DialogResult.OK)
            {
                outPath = Path.GetFullPath(exportHtml.FileName);
                outMethod = "HTML";
                outputHTML(jsonString, outPath);
                //permitir inputs, gray out outputs
                permitirInput();
                MessageBox.Show("Sucesso!");
                createFlowString(inMethod, inPath, outMethod, outPath);

            }
            else
            {
                MessageBox.Show("Erro! Ocorreu um erro a gravar o ficheiro ");
            }





        }

        private void inREST_Click(object sender, EventArgs e)
        {
            //passar a form main para a nova form de modo a poder alterar a variavel inRESTuriAux dentro da form nova
            //por enquanto funciona, se der tempo, utilizaçao de interfaces seria uma melhor soluçao

            inREST formAux = new inREST(this);
            formAux.ShowDialog();

            //para efeitos de testes
            jsonString = restToJSON(inPath);


        }

        private void inEXCEL_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //abrir o ficheiro
            openFileDialog1.Filter = "xlsx Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"; //filtrar por tipo de ficheiro
            //openFileDialog1.FilterIndex = 1;  //default

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inPath = openFileDialog1.FileName;
                MessageBox.Show(inPath);
                inMethod = "EXCEL";

                //este ultimo so vai ser invocado no correr fluxos
                jsonString = excelToJSON(inPath);  //chama a funcao excelToJson que converte o ficheiro excel numa jsonstring

                permitirOutput();  //para desbloquear os botoes de Output
            }

        }

        private void inXML_Click(object sender, EventArgs e)
        {
            //inXML formXML = new inXML(this);
            //jsonString = xmlToJSON(inPath);
            //formXML.ShowDialog();
            openFileDialog2.InitialDirectory = Application.StartupPath;
            openFileDialog2.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog2.FileName;
                MessageBox.Show(path);

                inPath = path;
                inMethod = "XML";
                jsonString = xmlToJSON(inPath);

                //permitir output
                permitirOutput();
            }
        }

        private String xmlToJSON(String path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            MessageBox.Show(path);
            //A variavel "jsonText" contem  o JSON já convertido 
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            MessageBox.Show(jsonText);
            return jsonText;
        }

        private String restToJSON(String uriAux)
        {
            var client = new RestClient(uriAux);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var queryResult = client.Execute<Object>(request).Data;
            string json = JsonConvert.SerializeObject(queryResult);

            return json;
        }

        private String excelToJSON(String filename) //esta funcao serve para converter o excel que recebemos do utilizador numa string Json
        {                                           //para isso usamos o package NPOI que e um projecto open source que nos ajuda a escrever/ler de ficheiros XLS(excel)
                                                    //DOC (word) e  PPT (powerpoint)
            string jsonString = "";
            string output = "";

            output = $"{filename}.txt";


            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                    }
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum - 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            {
                                rowList.Add(row.GetCell(j).ToString());
                            }
                        }
                    }
                    if (rowList.Count > 0)
                        dtTable.Rows.Add(rowList.ToArray());
                    rowList.Clear();
                }
            }
            //primeiramente vamos ler os dados do nosso ficheiro para uma datatable e so depois convertemos para uma string Json atraves da  seralizacao 
            //entre objectos neste caso entre uma datatable e um Json Object atraves da biblioteca Newtonsoft  metodo jsonConvert
            jsonString = JsonConvert.SerializeObject(dtTable);
            MessageBox.Show(jsonString);
            using (FileStream fs = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                StreamWriter write = new StreamWriter(fs); //escrever para um ficheiro so para testes
                write.Write(JsonConvert.SerializeObject(dtTable));
                write.Flush();
                write.Close();
                fs.Close();
            }

            // ExportDatatableToHtml(dtTable); para debug e testes

            MessageBox.Show(jsonString);
            return jsonString;
        }

        private void outREST_Click(object sender, EventArgs e)
        {
            outREST formOutREST = new outREST(this);
            formOutREST.ShowDialog();
        }

        protected string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();// criar o ficheiro html atraves das tags
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td>");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr>");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //fechar as tags  
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();
            MessageBox.Show(Htmltext);
            return Htmltext;//retorna uma variavel HTMLtext que contem o nosso codigo html, sendo basicamente uma string

        }


        private string outputHTML(string strJson, string caminho)
        {
            MessageBox.Show(strJson);
            DataTable dtTable = new DataTable(); //criar uma nova datatable
            dtTable = convertStringToDataTable(strJson); //converter a string em datatable
            htmlString = ExportDatatableToHtml(dtTable); //converter a datatable em conteudo html

            //MessageBox.Show(inPath);
            string path = caminho;

            // criar o ficheiro para escrever 
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(htmlString);//escrever a string para criar o ficheiro html
            }


            return htmlString;
        }



        public static DataTable convertStringToDataTable(string jsonString)
        {

            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;


        }

        private void export_Click(object sender, EventArgs e)
        {
            if (listaFluxos.Items.Count == 0)
            {
                MessageBox.Show("Erro! Não existem fluxos para guardar!");
                return;
            }

            XmlDocument doc = new XmlDocument();

            // Create the XML Declaration, and append it to XML document
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            // Create the root element
            XmlElement root = doc.CreateElement("flows");
            doc.AppendChild(root);

            foreach (var aux in listaFluxos.Items)
            {
                root.AppendChild(createFlow(doc, aux.ToString()));
            }

            SaveFileDialog exportXml = new SaveFileDialog();
            //exportXml.ShowDialog();
            exportXml.Filter = "xml files (*.xml)|*.xml";
            exportXml.Title = "Guardar os Fluxos de dados!";
            if (exportXml.ShowDialog() == DialogResult.OK)
            {
                doc.Save(exportXml.FileName);
                MessageBox.Show("Sucesso!");

            }
            else
            {
                MessageBox.Show("Erro! Ocorreu um erro a gravar o ficheiro ");
            }

        }

        private XmlElement createFlow(XmlDocument doc, string flowAux)
        {
            string[] splitHalf = flowAux.Split('*');
            string[] splitIn = splitHalf[0].Split('>');
            string[] splitOut = splitHalf[1].Split('>');

            XmlElement flow = doc.CreateElement("flow");
            flow.SetAttribute("inputType", splitIn[0].Trim());
            flow.SetAttribute("inputPath", splitIn[1].Trim());
            flow.SetAttribute("outputType", splitOut[0].Trim());
            flow.SetAttribute("outputPath", splitOut[1].Trim());

            return flow;
        }

        private void createFlowString(string inType, string inPath, string outType, string outPath)
        {
            string aux = inType + " > " + inPath + " * " + outType + " > " + outPath;

            listaFluxos.Items.Add(aux);
        }



        private async void executar_Click(object sender, EventArgs e)
        {
            if (listaFluxos.Items.Count == 0)
            {
                MessageBox.Show("Erro! Não existem fluxos a serem processados!");
                return;
            }

            foreach (string fluxo in listaFluxos.Items)
            {
                string[] splitHalf = fluxo.Split('*');
                string[] splitIn = splitHalf[0].Split('>');
                string[] splitOut = splitHalf[1].Split('>');

                string aux = splitIn[0].Trim() + splitOut[0].Trim();

                switch (aux)
                {
                    case "GETPOST":
                        await PostAsync(restToJSON(splitIn[1].Trim()), splitOut[1].Trim());
                        /*MessageBox.Show("sucesso!");*/
                        break;
                    case "GETPUT":
                        await PutAsync(restToJSON(splitIn[1].Trim()), splitOut[1].Trim());
                        break;
                    case "GETHTML":
                        break;
                    case "XMLPOST":
                        await PostAsync(xmlToJSON(splitIn[1].Trim()), splitOut[1].Trim());
                        break;
                    case "XMLPUT":
                        await PutAsync(xmlToJSON(splitIn[1].Trim()), splitOut[1].Trim());
                        break;
                    case "XMLHTML":
                        break;
                    case "EXCELPOST":
                        await PostAsync(excelToJSON(excelToJSON(splitIn[1].Trim())), splitOut[1].Trim());
                        break;
                    case "EXCELPUT":
                        await PutAsync(excelToJSON(excelToJSON(splitIn[1].Trim())), splitOut[1].Trim());
                        break;
                    case "EXCELHTML":
                        outputHTML(excelToJSON(splitIn[1].Trim()), splitOut[1].Trim());  // para chamar os fluxos recursivamente
                        break;
                }
            }
        }

        public void permitirInput()
        {
            //funcao publica para poder ser chamada dentro das forms, a fim de facilitar
            //utilizacao do programa da parte do utilizador, atraves de desabilitar os butoes de input
            //quando o programa está a espera de um output

            outHTML.Enabled = false;
            outREST.Enabled = false;
            inREST.Enabled = true;
            inEXCEL.Enabled = true;
            inXML.Enabled = true;
        }

        public void permitirOutput()
        {
            //funcao publica para poder ser chamada dentro das forms, a fim de facilitar
            //utilizacao do programa da parte do utilizador, atraves de desabilitar os butoes de output
            //quando o programa está a espera de um Input

            outHTML.Enabled = true;
            outREST.Enabled = true;
            inREST.Enabled = false;
            inEXCEL.Enabled = false;
            inXML.Enabled = false;
        }

        public void import_Click(object sender, EventArgs e)
        {
            OpenFileDialog importXml = new OpenFileDialog();
            importXml.Filter = "xml files (*.xml)|*.xml";
            if (importXml.ShowDialog() == DialogResult.OK)
            {

                HandlerXML(Path.GetFullPath(importXml.FileName));
            }
            else
            {
                MessageBox.Show("Erro! Ocorreu um erro a abrir o ficheiro ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaFluxos.Items.Clear();
        }

        public void HandlerXML(string path)
        {
            HandlerXML handler = new HandlerXML(path, xsd);
            if (handler.ValidateXML())
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    string inType = node.Attributes["inputType"]?.InnerText;
                    string inPath = node.Attributes["inputPath"]?.InnerText;
                    string outType = node.Attributes["outputType"]?.InnerText;
                    string outPath = node.Attributes["outputPath"]?.InnerText;
                    createFlowString(inType, inPath, outType, outPath);
                }
                MessageBox.Show("Sucesso!");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao abrir o ficheiro de fluxos!");
            }
        }


        public static async Task PostAsync(string json, string url)
        {
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            /*var response =*/
            await client.PostAsync(url, data);

            /*string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);*/
        }

        public static async Task PutAsync(string json, string url)
        {
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            /*var response =*/
            await client.PutAsync(url, data);

            /*string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);*/
        }



    }

}




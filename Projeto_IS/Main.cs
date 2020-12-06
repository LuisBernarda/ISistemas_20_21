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
using Newtonsoft.Json;
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RestSharp;
using System.Xml;

namespace Projeto_IS
{
    public partial class Main : Form
    {
        public string inRESTuriAux;
        public string outRestMethod;
        public string outRestURI;

        public Main()
        {
            InitializeComponent();
        }

        private void outHTML_Click(object sender, EventArgs e)
        {
            Console.WriteLine(inRESTuriAux);
        }

        private void inREST_Click(object sender, EventArgs e)
        {
            //passar a form main para a nova form de modo a poder alterar a variavel inRESTuriAux dentro da form nova
            //por enquanto funciona, se der tempo, utilizaçao de interfaces seria uma melhor soluçao
            inREST formAux = new inREST(this);
            formAux.ShowDialog();
        }

        private void inEXCEL_Click(object sender, EventArgs e)
        {
            string filename = "";
            string output = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xlsx Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                output = $"{filename}.txt";
                MessageBox.Show(filename);



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
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum-1; i++)
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
                MessageBox.Show(JsonConvert.SerializeObject(dtTable));
                using (FileStream fs = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    StreamWriter write = new StreamWriter(fs);
                    write.Write(JsonConvert.SerializeObject(dtTable));
                    write.Flush();
                    write.Close();
                    fs.Close();
                }
            }


            }
        private void inXML_Click(object sender, EventArgs e)
        {
            inXML formXML = new inXML(this);
            formXML.ShowDialog();
        }

        private string restToJSON(string uriAux)
        {
            var client = new RestClient(uriAux);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var queryResult = client.Execute<Object>(request).Data;
            string json = JsonConvert.SerializeObject(queryResult);

            return json;
        }

        private void outREST_Click(object sender, EventArgs e)
        {
            outREST formOutREST = new outREST(this);
            formOutREST.ShowDialog();
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
                createFlow(doc, aux.ToString());
            }


        }

        private XmlElement createFlow(XmlDocument doc, string flowAux)
        {
            string[] splitHalf = flowAux.Split(':');
            string[] splitIn = splitHalf[0].Split('>');
            string[] splitOut = splitHalf[1].Split('>');

            XmlElement flow = doc.CreateElement("flow");
            flow.SetAttribute("inputType", splitIn[0].Trim());
            flow.SetAttribute("inputPath", splitIn[1].Trim());
            flow.SetAttribute("outputType", splitOut[0].Trim());
            flow.SetAttribute("outputPath", splitOut[1].Trim());

            return flow;
        }
    }

}


        

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
<<<<<<< Updated upstream
using System.Xml;
=======
using Newtonsoft.Json.Linq;
>>>>>>> Stashed changes

namespace Projeto_IS
{
    public partial class Main : Form
    {
<<<<<<< Updated upstream
        public string inRestURI;
        public string inMethod;
        public string outMethod;
        public string outRestURI;
=======
        public String inRESTuriAux;
        public String outRestMethod;
        public String outRestURI;
        public String jsonString;
>>>>>>> Stashed changes

        public Main()
        {
            InitializeComponent();
        }

        private void outHTML_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            Console.WriteLine(inRestURI);
=======
            Console.WriteLine(inRESTuriAux);
            string filename = "";
            string jason = "";


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "xlsx Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                MessageBox.Show(filename);
                DataTable dtTable = new DataTable();
                dtTable = convertStringToDataTable(jsonString);
                ExportDatatableToHtml(dtTable);
            }

>>>>>>> Stashed changes
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
            string jason = "";


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xlsx Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                MessageBox.Show(filename);
                jason= excelToJSON(filename);

            }

  

        }
        private void inXML_Click(object sender, EventArgs e)
        {
            inXML formXML = new inXML(this);
            formXML.ShowDialog();
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

        private String excelToJSON(String filename)
        {
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
                jsonString = JsonConvert.SerializeObject(dtTable);
                MessageBox.Show(jsonString);
                using (FileStream fs = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    StreamWriter write = new StreamWriter(fs);
                    write.Write(JsonConvert.SerializeObject(dtTable));
                    write.Flush();
                    write.Close();
                    fs.Close();
                }
           
            ExportDatatableToHtml(dtTable);

            return jsonString;
        }

        private void outREST_Click(object sender, EventArgs e)
        {
            outREST formOutREST = new outREST(this);
            formOutREST.ShowDialog();
        }
        protected string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();
            MessageBox.Show(Htmltext);
            return Htmltext;

        }

<<<<<<< Updated upstream
        private string restToJSON(string uriAux)
=======
        private String jsonToDatatable(String filename)
>>>>>>> Stashed changes
        {
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
            jsonString = JsonConvert.SerializeObject(dtTable);
            MessageBox.Show(jsonString);
            using (FileStream fs = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                StreamWriter write = new StreamWriter(fs);
                write.Write(JsonConvert.SerializeObject(dtTable));
                write.Flush();
                write.Close();
                fs.Close();
            }

            ExportDatatableToHtml(dtTable);

            return jsonString;
        }

        public static DataTable convertStringToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            bool columnsAdded = false;
            foreach (string row in data.Split('}'))
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (string cell in row.Split(':'))
                {
                    string[] keyValue = cell.Split(',');
                    if (!columnsAdded)
                    {
                        DataColumn dataColumn = new DataColumn(keyValue[0]);
                        dataTable.Columns.Add(dataColumn);
                    }
                    dataRow[keyValue[0]] = keyValue[1];
                }
                columnsAdded = true;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

<<<<<<< Updated upstream
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
                
            } else
            {
                MessageBox.Show("Erro! Ocorreu um erro a gravar o ficheiro ");
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

        private void createFlowString(string inType, string inPath, string outType, string outPath)
        {
            string aux = inType + " > " + inPath + " : " + outType + " > " + outPath;

            listaFluxos.Items.Add(aux);
        }
=======

>>>>>>> Stashed changes
    }

}


        

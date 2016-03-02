using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using System.IO;

namespace GeneradorScriptPaquetesOracle
{
    public partial class MainForm : Form
    {
        string oradb = "";
        ConfigForm m;       

        public MainForm()
        {
            InitializeComponent();
            fillEnvironments();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            StreamWriter file;  
            OracleConnection conn = new OracleConnection(null);
            string rutaFichero = "";
            int totalLines = 0;

            string[] packagesNames = new string[checkedListBox1.CheckedItems.Count]; //Nombre de los paquetes seleccionados

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                packagesNames[i] = checkedListBox1.CheckedItems[i].ToString();
            }

            for(int i = 0;i < packagesNames.Length; i++)
            {
                

                if (textBox2.Text == "")
                    rutaFichero = packagesNames[i] + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".sql";    //Ruta del fichero si no se ha introducido una ruta (la carpeta donde se ejecuta)
                else
                    rutaFichero = textBox2.Text + packagesNames[i] + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".sql";     //Ruta del fichero si se ha introdudico una ruta

                conn = new OracleConnection(oradb);    //Conectamos a la base de datos con la cadena de conexion

                totalLines = countLines(oradb, packagesNames[i], "HEADER") + countLines(oradb, packagesNames[i], "BODY");

                label1.Text = "";
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalLines;
                
                try
                {
                    conn.Open();    //Abrimos la conexión

                    file = new StreamWriter(rutaFichero, true);     //Abrimos el fichero
                    file.NewLine = "\r";

                    OracleCommand cmd = new OracleCommand();    //Comando que mandaremos a la base de datos

                    cmd.Connection = conn;

                    cmd.CommandText = "select text from all_source where type = 'PACKAGE' AND name = '" + packagesNames[i] + "' ORDER BY LINE ASC";
                    cmd.CommandType = CommandType.Text;

                    OracleDataReader dr = cmd.ExecuteReader();      //Resultados de la query

                    while (dr.Read())
                    {
                        if (progressBar1.Value < totalLines)
                            progressBar1.Increment(1);
                        label1.Text = packagesNames[i] + " -> Escribiendo cabecera...";
                        await file.WriteAsync(dr.GetString(0));     //Escribimos en el fichero cada línea de la cabecera                    
                    }

                    file.WriteLine(Environment.NewLine);
                    file.Write("/");
                    file.WriteLine(Environment.NewLine);

                    cmd.CommandText = "select text from all_source where type = 'PACKAGE BODY' AND name = '" + packagesNames[i] + "' ORDER BY LINE ASC";
                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (progressBar1.Value < totalLines)
                            progressBar1.Increment(1);
                        label1.Text = packagesNames[i] + " -> Escribiendo cuerpo...";
                        await file.WriteAsync(dr.GetString(0));     //Escribimos en el fichero cada línea del body                        
                    }

                    file.WriteLine(Environment.NewLine);
                    file.Write("/");

                    file.Flush();
                    file.Dispose();         //Cerramos el fichero

                }
                catch (Exception ex)
                {
                    label1.Text = ex.Message;
                }
            }             
            
                conn.Dispose();         //Cerramos la conexión

                label1.Text = "¡Completado!";
            
        }

        private void comboBox1_SelectionChangeCommited(object sender, EventArgs e)
        {

            string owner = "";
            int index = 0;
            string[] aliases = new string[Properties.ConnectionStrings.Default.Alias.Count];
            string[] connections = new string[Properties.ConnectionStrings.Default.ConnectionString.Count];
            string[] owners = new string[Properties.ConnectionStrings.Default.Owners.Count];

            
            Properties.ConnectionStrings.Default.ConnectionString.CopyTo(connections, 0);
            Properties.ConnectionStrings.Default.Alias.CopyTo(aliases, 0);
            Properties.ConnectionStrings.Default.Owners.CopyTo(owners, 0);
            
            for(int i=0; i < aliases.Length; i++)
            {
                if (aliases[i] == comboBox1.Text)
                    index = i;
            }

            oradb = SecureIt.ToInsecureString(SecureIt.DecryptString(connections[index]));         //Obtenemos la cadena de conexión y el owner correspondientes
            owner = owners[index];             

            OracleConnection conn = new OracleConnection(oradb);    //Conectamos a la base de datos con la cadena de carga

            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "select distinct name from all_source where TYPE = 'PACKAGE' AND NAME LIKE 'P\\_%' ESCAPE '\\'  AND OWNER = '" + owner + "'";     //Obtenemos el nombre de los paquetes de la base de datos
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();

                checkedListBox1.Items.Clear();

                while (dr.Read())
                {
                    checkedListBox1.Items.Add(dr.GetString(0));         //Añadimos los elementos a la lista              
                }

                checkedListBox1.Update();

                conn.Dispose();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            m = new ConfigForm(this);     
            m.Show();
        }

        public void fillEnvironments()
        {
            comboBox1.Items.Clear();
            comboBox1.BeginUpdate();
            if (Properties.ConnectionStrings.Default.Alias != null)
            {
                foreach (string alias in Properties.ConnectionStrings.Default.Alias)
                {
                    comboBox1.Items.Add(alias);
                }
            }
            comboBox1.EndUpdate();
            comboBox1.Refresh();
        }

        private int countLines(string dbCon, string package, string hOrb)
        {
            OracleConnection conn = new OracleConnection(dbCon);
            int lines = 0;            

            string headerOrbody;
            if (hOrb.Equals("HEADER"))
                headerOrbody = "PACKAGE";
            else
                headerOrbody = "PACKAGE BODY";

            try
            {
                conn.Open();    //Abrimos la conexión                

                OracleCommand cmd = new OracleCommand();    //Comando que mandaremos a la base de datos

                cmd.Connection = conn;

                cmd.CommandText = "select count(*) from all_source where type = '"+headerOrbody+"' AND name = '" + package+ "'";
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();      //Resultados de la query                

                while (dr.Read())
                {
                    lines =  (int)dr.GetDecimal(0);             //Cogemos el número de líneas
                }

                conn.Dispose();         //Cerramos la conexión

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }            

            return lines;
        }
        
    }
}

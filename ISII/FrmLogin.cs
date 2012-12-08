using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient; //Para conexion con SQL Server
using DAT;

namespace ISII
{
    public partial class FrmLogin : Form
    {
        int contador = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            contador++;
           
            
            
            //Cadena de Conexion --> USR: sa PASS: SQLSERVER
            SqlConnection conexionbdd = new SqlConnection("Data Source=localhost;Initial Catalog=is2atencionmedica;User ID=sa;Password=SQLSERVER");
            
            try
            {
                SqlCommand comando = new SqlCommand("select usuario, contrasenia from login where usuario = '" + txtUsuario.Text + "' and contrasenia = '" + txtcontraseña.Text + "' ", conexionbdd);

                conexionbdd.Open();
                comando.ExecuteNonQuery();

                DataSet dataset_gl = new DataSet();
                SqlDataAdapter adaptador_sql = new SqlDataAdapter(comando);
                adaptador_sql.Fill(dataset_gl, "login");

                DataRow datarow_gl;
                datarow_gl = dataset_gl.Tables["login"].Rows[0];

                if ((txtUsuario.Text == datarow_gl["usuario"].ToString()) || (txtcontraseña.Text == datarow_gl["contrasenia"].ToString()))
                {
                    //FrmInicio formInicial = new FrmInicio();
                    //formInicial.Show();
                    if (txtUsuario.Text.Equals("admin"))
                    {
                        FrmInicioAdmin admin = new FrmInicioAdmin();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        PrincipalSecretaria secretaria = new PrincipalSecretaria();
                        secretaria.Show();
                        this.Hide();
                    }
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Fallido!\nNombre de Usuario o Contraseña Inválidos...", "Login Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (contador >= 3)
                {
                    MessageBox.Show("Login Fallido!\nIntentos Excedidos...\nCerrando el Programa...", "Login Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Dispose();
                    this.Close();
                    Application.Exit();
                }
            }
            finally
            {
                conexionbdd.Close();
            }

        }
    }
}

namespace Practica_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desactivarControles();
        }
        private Double monto;

        private void activarControles()
        {
            txtCliente.Enabled = false;
            txtMonto.Enabled = false;
            btnAbrir.Enabled = false;

            btnDeposito.Enabled = true;
            btnRetiro.Enabled = true;

        }
        private void desactivarControles()
        {
            txtCliente.Enabled = true;
            txtMonto.Enabled = true;
            btnAbrir.Enabled = true;

            btnDeposito.Enabled = false;
            btnRetiro.Enabled = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string cliente;
            cliente = txtCliente.Text;
            monto = Convert.ToDouble(txtMonto.Text);

            if (monto > 0)
            {
                activarControles();
            }
            else
            {
                MessageBox.Show(" El monto debe ser mayor o igual que 0", " Gestion de ahorros ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Double leer(string mensaje)
        {
            Double cantidad;
            cantidad = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Ingrese monto a " + mensaje, "Gestion de ahorros", "0", 100, 0));
            return cantidad;
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Double deposito;
            deposito = leer("Depositar");
            monto = monto + deposito;
            lstDepositos.Items.Add(deposito);
            mostrar();
        }
        private void mostrar()
        {
            txtSaldo.Text = Convert.ToString(monto);
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            Double retiro;
            retiro = leer("Retirar");
            if (retiro <= monto)
            {
                monto = monto - retiro;
                lstRetiros.Items.Add(retiro);
                mostrar();
            }
            else
            {
                MessageBox.Show("La cantidad de retiro es mayor al monto", "Gestion de ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();
            txtSaldo.Clear();
            lstDepositos.Items.Clear();
            lstRetiros.Items.Clear();
            desactivarControles();
        }
    }

}
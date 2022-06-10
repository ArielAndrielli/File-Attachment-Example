using EllonMusk.services;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EllonMusk
{
    public partial class Anexos : Form
    {

        #region Atributos

        public Anexos()
        {
            InitializeComponent();
        }

        RelacionamentoAnexoService relacionamentoAnexo;

        #endregion

        #region Eventos

        private void Anexos_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_anexo_Click(object sender, EventArgs e)
        {
            if (relacionamentoAnexo == null)
            {
                MessageBox.Show("Escolha uma tabela para salvar!");
                return;
            }

            //Filtrar por arquivos de texto => Text files (*.txt)|*.txt| <= Esse último pipe separa para se você quiser adicionar outro filtro.
            //Colocar ele toda vez que for definir um novo filtro

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Word files (*.docx)|*.docx| Exel files (*.xlsx)|*.xlsx| PDF files (*.pdf)|*.pdf| Text files (*.txt)|*.txt| All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                fs.Close();
                br.Close();

                relacionamentoAnexo.Anexos.Add( new Anexo() 
                { Nome = Path.GetFileName(dlg.FileName), 
                  Caminho = dlg.FileName, 
                  Extensao = Path.GetExtension(dlg.FileName),
                  Dados = bytes.ToList() });
                lista.Items.Add(Path.GetFileName(dlg.FileName));
            }
            txt_1.Text = dlg.FileName;
            txt_2.Text = Path.GetFileName(dlg.FileName);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (relacionamentoAnexo == null)
            {
                MessageBox.Show("Escolha uma tabela para salvar!");
                return;
            }

            if (relacionamentoAnexo.Anexos.Count == 0)
            {
                MessageBox.Show("Array de Anexos está vazia!");
                return;
            }

            MessageBox.Show(relacionamentoAnexo.SalvarAnexo());

        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (lista.SelectedIndex == -1)
            {
                MessageBox.Show("Selcione um item para apagar!");
                return;
            }
            
                lista.Items.RemoveAt(lista.SelectedIndex);
                relacionamentoAnexo.Anexos.RemoveAt(lista.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                relacionamentoAnexo = new AnexoClienteService();
            else if (comboBox1.SelectedIndex == 1)
                relacionamentoAnexo = new AnexoVisitaService();
            else if (comboBox1.SelectedIndex == 2)
                relacionamentoAnexo = new AnexoSolicitacaoService();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

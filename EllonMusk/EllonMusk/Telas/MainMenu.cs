using System;
using System.Windows.Forms;

namespace EllonMusk
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        #region Events

        private void btn_1_Click(object sender, EventArgs e)
        {
            Anexos tela1 = new Anexos();
            tela1.ShowDialog();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            Anexos tela2 = new Anexos();
            tela2.ShowDialog();
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            Anexos tela3 = new Anexos();
            tela3.ShowDialog();
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            Anexos tela4 = new Anexos();
            tela4.ShowDialog();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btn_teste_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\Users\aars\Documents\Texto\Querys.txt";

            var connectionString = "DefaultEndpointsProtocol=https;" +
                "AccountName=aarsmeudiscofavorito;" +
                "AccountKey=1J3TXtEc1PQ91f8vf8bJ1sVJO0DZchHbgPRZ7qE29oMk2sLCsAbghscvolo5QcXExaFgkWk4reQ/+AStjZnu2w==;" +
                "EndpointSuffix=core.windows.net";

            try
            {
                // intialize BobClient
                Azure.Storage.Blobs.BlobClient blobClient = new Azure.Storage.Blobs.BlobClient(
                connectionString: connectionString,
                blobContainerName: "anexos",
                blobName: "testeBlobStorage");

                // upload the file
                blobClient.Upload(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

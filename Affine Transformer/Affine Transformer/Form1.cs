using System;
using System.Drawing;
using System.Windows.Forms;

namespace Affine_Transformer
{
    public partial class Form1 :Form
    {
        /// <summary>
        /// fileDialog
        /// </summary>
        OpenFileDialog m_fileDialog;
        /// <summary>
        /// Interface Manageするクラス
        /// </summary>
        InterfaceManager m_iManager;
        /// <summary>
        /// Ctor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            m_fileDialog = new OpenFileDialog();
            m_iManager = new InterfaceManager();
            numericAngle.Controls[0].Visible = false;
            numericCenterXcoordinate.Controls[0].Visible = false;
            numericCenterYcoordinate.Controls[0].Visible = false;
            numericAngle.DecimalPlaces = 2;
            txtBoxFractionValue.ReadOnly = true;
            txtBoxOutputA.ReadOnly = true;
            txtBoxOutputB.ReadOnly = true;
            txtBoxOutputC.ReadOnly = true;
            txtBoxOutputD.ReadOnly = true;
            txtBoxOutputXcoordinate.ReadOnly = true;
            txtBoxOutputYcoordinate.ReadOnly = true;
            txtBoxFractionShiftedValue.ReadOnly = true;
            txtBoxShiftedAValue.ReadOnly = true;
            txtBoxShiftedBValue.ReadOnly = true;
            txtBoxShiftedCValue.ReadOnly = true;
            txtBoxShiftedDValue.ReadOnly = true; 
            txtBoxShiftedXcoordinate.ReadOnly = true;
            txtBoxShiftedYcoordinate.ReadOnly = true;
            btnSaveImage.Enabled = false;
        }
        /// <summary>
        /// 画像入力するボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            //画像ファイルを入力する部分
            m_fileDialog.InitialDirectory = "c://";
            m_fileDialog.Filter = "image files (*.bmp)|*.bmp|Allfiles (*.*)|*.*";
            if (m_fileDialog.ShowDialog() == DialogResult.OK) {
                m_iManager.m_fileName = m_fileDialog.FileName;
                picBox.Image = Image.FromFile(m_fileDialog.FileName);
                btnSaveImage.Enabled = true;
            }
        }
        /// <summary>
        /// アフィン変換するボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAffineTransform_Click(object sender, EventArgs e)
        {
            ProgramCode progCode = ProgramCode.Done;
            
            if ((picBox.Image == null)|| (picBox == null)) {
                progCode = ProgramCode.InputImageError;
            }
            if (progCode == ProgramCode.Done) {
                //入力値を計算する部分に入れます
                listInvalidDatacoordinate.Items.Clear();
                m_iManager.m_angle = Decimal.ToSingle(numericAngle.Value);
                m_iManager.m_centerX = Decimal.ToSingle(numericCenterXcoordinate.Value);
                m_iManager.m_centerY = Decimal.ToSingle(numericCenterYcoordinate.Value);
            }
            if(progCode == ProgramCode.Done) {
                progCode = m_iManager.InitialBackEnd();
            }
            if(progCode == ProgramCode.Done) {
                txtBoxOutputA.Text = m_iManager.m_OutPutValueA.ToString(); 
                txtBoxOutputB.Text = m_iManager.m_OutPutValueB.ToString();
                txtBoxOutputC.Text = m_iManager.m_OutPutValueC.ToString();
                txtBoxOutputD.Text = m_iManager.m_OutPutValueD.ToString();
                txtBoxOutputXcoordinate.Text = m_iManager.m_OutPutValueX.ToString();
                txtBoxOutputYcoordinate.Text = m_iManager.m_OutPutValueY.ToString();
                txtBoxFractionValue.Text = m_iManager.m_DifferenceValue.ToString();
                txtBoxFractionShiftedValue.Text = m_iManager.m_RegManager.difference.ToString();
                txtBoxShiftedAValue.Text = m_iManager.m_RegManager.outputA.ToString();
                txtBoxShiftedBValue.Text = m_iManager.m_RegManager.outputB.ToString();
                txtBoxShiftedCValue.Text = m_iManager.m_RegManager.outputC.ToString();
                txtBoxShiftedDValue.Text = m_iManager.m_RegManager.outputD.ToString();
                txtBoxShiftedXcoordinate.Text = m_iManager.m_RegManager.outputX.ToString();
                txtBoxShiftedYcoordinate.Text = m_iManager.m_RegManager.outputY.ToString();

                //画像処理
                progCode = m_iManager.ProcessImage();
            }
            if (progCode == ProgramCode.Done) {
                picBox.Image = m_iManager.m_OutPutImage;
                listInvalidDatacoordinate.Scrollable = true;
                ListViewItem listItem = null;
                for (int index = 0; index < m_iManager.m_InvalidXCoordinateArray.Count; index++) {
                    listItem = new ListViewItem(new string[] { (index + 1).ToString(), m_iManager.m_InvalidXCoordinateArray[index].ToString(), m_iManager.m_InvalidYCoordinateArray[index].ToString() });
                    listInvalidDatacoordinate.Items.Add(listItem);
                }
            }
            if(progCode != ProgramCode.Done) {
                MessageBox.Show(progCode.ToString() + Environment.NewLine + progCode.ToStringMessage(), "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        /// <summary>
        /// 出力画像を保存するボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            ProgramCode progCode = ProgramCode.Done;
            if(picBox == null) {
                progCode = ProgramCode.ImageIsNull;
            }
            if (progCode == ProgramCode.Done) {
                Bitmap bitmapSaveImage = new Bitmap(picBox.Image);
                bitmapSaveImage.Save(@"test.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}

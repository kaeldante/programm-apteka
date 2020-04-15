/*
 * Создано в SharpDevelop.
 * Пользователь: 123
 * Дата: 25.02.2020
 * Время: 18:05
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace APTEKA
{
	/// <summary>
	/// Description of auth.
	/// </summary>
	public partial class auth : Form
	{
		
		private SQLiteConnection DB;
		public auth()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.MinimumSize = this.MaximumSize = this.Size;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Label2Click(object sender, EventArgs e)
		{
	
		}
		void AuthLoad(object sender, EventArgs e)
		{
			DB = new SQLiteConnection("Data Source = aptekaDB.db; version = 3");
			DB.Open();
			ToolTip t = new ToolTip();
            t.SetToolTip(tlog, "Не более 20 символов");
            t.SetToolTip(tpass, "Не более 20 символов");
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(tlog.Text =="" || tpass.Text ==""){
				label2.ForeColor = Color.Red;
								label3.ForeColor = Color.Red;
			}
	if(tlog.Text !="" || tpass.Text !=""){
				SQLiteCommand CMD  = DB.CreateCommand();
				CMD.CommandText = "select * from auth where login like @login and pass like @pass ";
				CMD.Parameters.Add("@login",System.Data.DbType.String).Value = tlog.Text.ToUpper();
								CMD.Parameters.Add("@pass",System.Data.DbType.String).Value = tpass.Text.ToUpper();
								SQLiteDataReader SQL =  CMD.ExecuteReader();
								
								if(SQL.HasRows){
									while(SQL.Read()){
										MessageBox.Show(string.Format("Добро пожаловать: " + SQL["FIO"]));
										MainForm main = new MainForm();
										this.Hide();
										main.ShowDialog();
										this.Show();
									
									}
								}
								else label2.ForeColor = Color.Red;
								label3.ForeColor = Color.Red;
		}
	}
		void PictureBox3Click(object sender, EventArgs e)
		{
	
			Application.Exit();
			DB.Close();
		}
		void Label4Click(object sender, EventArgs e)
		{
	register reg = new register();
										this.Hide();
										reg.ShowDialog();
										this.Show();
		}
		
}
}

/*
 * Создано в SharpDevelop.
 * Пользователь: 123
 * Дата: 27.02.2020
 * Время: 8:50
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
	/// Description of register.
	/// </summary>
	public partial class register : Form
	{
		private SQLiteConnection DB;
		public register()
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
		void RegisterLoad(object sender, EventArgs e)
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
								label4.ForeColor = Color.Red;
			}
			
	if(tlog.Text !="" && tpass.Text !="" && tfio.Text !=""){
				SQLiteCommand CMD  = DB.CreateCommand();
				CMD.CommandText = "insert into auth(login,pass,FIO) values(@login,@pass,@FIO)";
				CMD.Parameters.Add("@login",System.Data.DbType.String).Value = tlog.Text;
								CMD.Parameters.Add("@pass",System.Data.DbType.String).Value = tpass.Text;
								CMD.Parameters.Add("@FIO",System.Data.DbType.String).Value = tfio.Text;
								SQLiteDataReader SQL =  CMD.ExecuteReader();
								
										MessageBox.Show(string.Format("Сотрудник " + SQL["FIO"] + "зарегистрирован "));
										auth log = new auth();
										this.Hide();
										log.ShowDialog();
										this.Show();
									
									}
							
		}
		void PictureBox3Click(object sender, EventArgs e)
		{
	auth log = new auth();
										this.Hide();
										log.ShowDialog();
										this.Show();
		}
		}
	}


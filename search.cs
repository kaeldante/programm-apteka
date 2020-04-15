/*
 * Создано в SharpDevelop.
 * Пользователь: 123
 * Дата: 28.02.2020
 * Время: 14:45
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;


namespace APTEKA
{
	/// <summary>
	/// Description of search.
	/// </summary>
	public partial class search : Form
	{
		private SQLiteConnection DB;
		public search()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
	
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
	
		}
		void SearchLoad(object sender, EventArgs e)
		{
	DB = new SQLiteConnection("Data Source = aptekaDB.db; version = 3");
			DB.Open();
			
			string query = "SELECT * FROM auth ORDER BY id";
			SQLiteCommand command = new SQLiteCommand(query,DB);
			SQLiteDataReader reader = command.ExecuteReader();
			List<string[]> data = new List<string[]>();
			while(reader.Read()){
				data.Add(new string[4]);
				data[data.Count - 1][0] = reader[0].ToString();
				data[data.Count - 1][1] = reader[1].ToString();
				data[data.Count - 1][2] = reader[2].ToString();
				data[data.Count - 1][3] = reader[3].ToString();
			}
			reader.Close();
			DB.Close();
			
			foreach(string[] s in data)
				dataGridView1.Rows.Add(s);
		}
	
		void Button1Click(object sender, EventArgs e)
		{
			
			for (int i = 0; i < dataGridView1.RowCount; i++)
            {
				
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(tfind.Text))
                        {
                	dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            dataGridView1.Rows[i].Selected = true;
                            break;
                            
                        }
                
            }
			}
		}
	}

	


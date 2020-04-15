/*
 * Создано в SharpDevelop.
 * Пользователь: 123
 * Дата: 21.02.2020
 * Время: 16:49
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace APTEKA
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
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
		
		void PictureBox1Click(object sender, EventArgs e)
		{
	
			auth log = new auth();
										this.Hide();
										log.ShowDialog();
										this.Show();
			
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox1, "Переход к авторизации");
            t.SetToolTip(pictureBox3, "Завершение работы");
           
      
  
		}
		void Button1MouseHover(object sender, EventArgs e)
		{
		
		}
		void Button1Click(object sender, EventArgs e)
		{
		search srch = new search();
										this.Hide();
										srch.ShowDialog();
										this.Show();
		
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		void PictureBox3Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void СправкаToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Помощь в использовании: " +
			                "\n Поиск/Просмотр - используйте для поиска и просмотра интересующих вас лекарственных средств " +
			                "\n Добавить/Удалить - используется для добавления или удаления лекарственных препаратов " +
			                "\n Заявка на поставку - используется для составления списка необходимых лекарственных средств, для дальнейшей заявки поставщику " +
			                "\n Кнопка питания - завершение работы " +
			                "\n Кнопка выхода - выход из учетной записи на экран авторизации" );
			
		}
		
	}
}

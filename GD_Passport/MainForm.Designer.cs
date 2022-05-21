
namespace GD_Passport
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.Searchbutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.Printbutton = new System.Windows.Forms.Button();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 108);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(779, 331);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 458);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поиск по первой букве фамилии";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(281, 455);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(132, 22);
            this.textBoxSearch.TabIndex = 2;
            // 
            // Searchbutton
            // 
            this.Searchbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Searchbutton.Location = new System.Drawing.Point(462, 447);
            this.Searchbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Searchbutton.Name = "Searchbutton";
            this.Searchbutton.Size = new System.Drawing.Size(112, 38);
            this.Searchbutton.TabIndex = 3;
            this.Searchbutton.Text = "Найти";
            this.Searchbutton.UseVisualStyleBackColor = false;
            this.Searchbutton.Click += new System.EventHandler(this.Searchbutton_Click);
            // 
            // Addbutton
            // 
            this.Addbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Addbutton.Location = new System.Drawing.Point(16, 41);
            this.Addbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(124, 46);
            this.Addbutton.TabIndex = 4;
            this.Addbutton.Text = "Добавить";
            this.Addbutton.UseVisualStyleBackColor = false;
            this.Addbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Editbutton.Location = new System.Drawing.Point(169, 41);
            this.Editbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Editbutton.Name = "Editbutton";
            this.Editbutton.Size = new System.Drawing.Size(125, 46);
            this.Editbutton.TabIndex = 5;
            this.Editbutton.Text = "Редактировать";
            this.Editbutton.UseVisualStyleBackColor = false;
            // 
            // Deletebutton
            // 
            this.Deletebutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Deletebutton.Location = new System.Drawing.Point(327, 41);
            this.Deletebutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(125, 46);
            this.Deletebutton.TabIndex = 6;
            this.Deletebutton.Text = "Удалить";
            this.Deletebutton.UseVisualStyleBackColor = false;
            // 
            // Printbutton
            // 
            this.Printbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Printbutton.Location = new System.Drawing.Point(487, 41);
            this.Printbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Printbutton.Name = "Printbutton";
            this.Printbutton.Size = new System.Drawing.Size(171, 46);
            this.Printbutton.TabIndex = 7;
            this.Printbutton.Text = "Экспорт для печати";
            this.Printbutton.UseVisualStyleBackColor = false;
            // 
            // Exitbutton
            // 
            this.Exitbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Exitbutton.Location = new System.Drawing.Point(677, 457);
            this.Exitbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(100, 28);
            this.Exitbutton.TabIndex = 8;
            this.Exitbutton.Text = "Выход";
            this.Exitbutton.UseVisualStyleBackColor = false;
            this.Exitbutton.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.Location = new System.Drawing.Point(723, 15);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(69, 53);
            this.button7.TabIndex = 9;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(723, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 53);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(808, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Printbutton);
            this.Controls.Add(this.Deletebutton);
            this.Controls.Add(this.Editbutton);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.Searchbutton);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Система паспортного учёта";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button Searchbutton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.Button Printbutton;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
    }
}
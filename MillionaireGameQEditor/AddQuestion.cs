﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Millionaire.Windows.Question_Editor
{
    public partial class frmQuestionAdd : Form
    {

        private readonly QEditor _qe;
        int fff_answer = 0;

        public frmQuestionAdd(QEditor q)
        {
            InitializeComponent();
            this._qe = q;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string levelType;
            SqlCommand cmd;

            if (txtLevel.Text == "Level 1 (q1-5)")
            {
                levelType = "Lvl1";
                QEditor.c.Open();
                string str = String.Format(@"INSERT INTO questions_Level1 (Question, A, B, C, D, CorrectAnswer, Type) VALUES('" +
                    txtQuestion.Text + "','"
                    + txtA.Text + "','"
                    + txtB.Text + "','"
                    + txtC.Text + "','"
                    + txtD.Text + "','"
                    + txtCorrect.Text + "','"
                    + "{0}" + "'" +
                    ")", levelType);
                cmd = new SqlCommand(str, QEditor.c);
                cmd.ExecuteNonQuery();
                QEditor.c.Close();
                Console.WriteLine("[{0}] Database ADD operation completed succesfully!", DateTime.Now);
                _qe.UpdateDB();
                this.Close();
            }
            else if (txtLevel.Text == "Level 2 (q6-10)")
            {
                levelType = "Lvl2";
                QEditor.c.Open();
                string str = String.Format(@"INSERT INTO questions_Level2 (Question, A, B, C, D, CorrectAnswer, Type) VALUES('" +
                    txtQuestion.Text + "','"
                    + txtA.Text + "','"
                    + txtB.Text + "','"
                    + txtC.Text + "','"
                    + txtD.Text + "','"
                    + txtCorrect.Text + "','"
                    + "{0}" + "'" +
                    ")", levelType);
                cmd = new SqlCommand(str, QEditor.c);
                cmd.ExecuteNonQuery();
                QEditor.c.Close();
                Console.WriteLine("[{0}] Database ADD operation completed succesfully!", DateTime.Now);
                _qe.UpdateDB();
                this.Close();
            }
            else if (txtLevel.Text == "Level 3 (q11-14)")
            {
                levelType = "Lvl3";
                QEditor.c.Open();
                string str = String.Format(@"INSERT INTO questions_Level3 (Question, A, B, C, D, CorrectAnswer, Type) VALUES('" +
                    txtQuestion.Text + "','"
                    + txtA.Text + "','"
                    + txtB.Text + "','"
                    + txtC.Text + "','"
                    + txtD.Text + "','"
                    + txtCorrect.Text + "','"
                    + "{0}" + "'" +
                    ")", levelType);
                cmd = new SqlCommand(str, QEditor.c);
                cmd.ExecuteNonQuery();
                QEditor.c.Close();
                Console.WriteLine("[{0}] Database ADD operation completed succesfully!", DateTime.Now);
                _qe.UpdateDB();
                this.Close();
            }
            else if (txtLevel.Text == "Level 4 (q15)")
            {
                levelType = "Lvl4";
                QEditor.c.Open();
                string str = String.Format(@"INSERT INTO questions_Level4 (Question, A, B, C, D, CorrectAnswer, Type) VALUES('" +
                    txtQuestion.Text + "','"
                    + txtA.Text + "','"
                    + txtB.Text + "','"
                    + txtC.Text + "','"
                    + txtD.Text + "','"
                    + txtCorrect.Text + "','"
                    + "{0}" + "'" +
                    ")", levelType);
                cmd = new SqlCommand(str, QEditor.c);
                cmd.ExecuteNonQuery();
                QEditor.c.Close();
                Console.WriteLine("[{0}] Database ADD operation completed succesfully!", DateTime.Now);
                _qe.UpdateDB();
                this.Close();
            }
            else if (txtLevel.Text == "Fastest Finger Round")
            {
                levelType = "Lvl0";
                QEditor.c.Open();
                string str = String.Format(@"INSERT INTO questions_Level0 (Question, A, B, C, D, CorrectAnswer, Type) VALUES('" +
                    txtQuestion.Text + "','"
                    + txtA.Text + "','"
                    + txtB.Text + "','"
                    + txtC.Text + "','"
                    + txtD.Text + "','"
                    + lblAnswer.Text + "','"
                    + "{0}" + "'" +
                    ")", levelType);
                cmd = new SqlCommand(str, QEditor.c);
                cmd.ExecuteNonQuery();
                QEditor.c.Close();
                Console.WriteLine("[{0}] Database ADD operation completed succesfully!", DateTime.Now);
                _qe.UpdateDB();
                this.Close();
            }
            else
            {
                Console.WriteLine("[{0}] Error while completing operation: Level type is invalid.", DateTime.Now);
                MessageBox.Show("Level type is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuestion.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtCorrect.Text = "A";
            txtLevel.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuestionAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtLevel.Text == "Fastest Finger Round")
            {
                txtCorrect.Visible = false;
                pnlFFFAnswer.Visible = true;
            }
            else
            {
                txtCorrect.Visible = true;
                pnlFFFAnswer.Visible = false;
            }
        }

        private void btnFFFA_Click(object sender, EventArgs e)
        {
            if(fff_answer == 0)
            {
                lblAnswer.Text = "";
            }
            lblAnswer.Text = lblAnswer.Text + "A";
            btnFFFA.Enabled = false;
            btnReset.Enabled = true;
            fff_answer++;
        }

        private void btnFFFB_Click(object sender, EventArgs e)
        {
            if (fff_answer == 0)
            {
                lblAnswer.Text = "";
            }
            lblAnswer.Text = lblAnswer.Text + "B";
            btnFFFB.Enabled = false;
            btnReset.Enabled = true;
            fff_answer++;
        }

        private void btnFFFC_Click(object sender, EventArgs e)
        {
            if (fff_answer == 0)
            {
                lblAnswer.Text = "";
            }
            lblAnswer.Text = lblAnswer.Text + "C";
            btnFFFC.Enabled = false;
            btnReset.Enabled = true;
            fff_answer++;
        }

        private void btnFFFD_Click(object sender, EventArgs e)
        {
            if (fff_answer == 0)
            {
                lblAnswer.Text = "";
            }
            lblAnswer.Text = lblAnswer.Text + "D";
            btnFFFD.Enabled = false;
            btnReset.Enabled = true;
            fff_answer++;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = "*";
            btnFFFA.Enabled = true;
            btnFFFB.Enabled = true;
            btnFFFC.Enabled = true;
            btnFFFD.Enabled = true;
            fff_answer = 0;
            btnReset.Enabled = false;
        }
    }

    public class Edits
    {
        public static void Remove(int Id)
        {

        }
    }
}

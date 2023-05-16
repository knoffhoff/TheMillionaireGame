using Millionaire.Windows.Question_Editor;
using MillionaireGameQEditor;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace Millionaire
{
    public partial class QEditor : Form
    {
        public static SqlConnection c = new SqlConnection
                    (String.Format
                    (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\{1}.mdf;Integrated Security=True;Connect Timeout=30", Application.StartupPath, "dbMillionaire"));

        public QEditor()
        {
            InitializeComponent();
        }

        private void UpdateDB()
        {
                    var levels = new[] { "0", "1", "2", "3", "4" };
                    var dataTables = new[] { dtLevel0, dtLevel1, dtLevel2, dtLevel3, dtLevel4 };

                    for (int i = 0; i < levels.Length; i++)
                    {
                        var select = $"SELECT * FROM questions_Level{levels[i]}";
                        var dataAdapter = new SqlDataAdapter(select, c);
                        var commandBuilder = new SqlCommandBuilder(dataAdapter);
                        var ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dataTables[i].ReadOnly = true;
                        dataTables[i].DataSource = ds.Tables[0];
                    }
                }

        private void EditDB()
        {
                    frmEditQuestion edit = new frmEditQuestion(this);
                    var levels = new[] { "Lvl0", "Lvl1", "Lvl2", "Lvl3", "Lvl4" };
                    var dataTables = new[] { dtLevel0, dtLevel1, dtLevel2, dtLevel3, dtLevel4 };

                    for (int i = 0; i < levels.Length; i++)
                    {
                        if (stLevel.Text == levels[i])
                        {
                            if (Convert.ToInt32(dataTables[i].CurrentRow.Cells[0].Value) == 0)
                            {
                                MessageBox.Show("You must select a question first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                PopulateFieldsForEditing(edit, dataTables[i]);
                            }
                            break;
                        }
                    }
                    edit.ShowDialog();
                }

        private void PopulateFieldsForEditing(frmEditQuestion edit, DataGridView dataTable)
        {
                    edit.txtId.Text = dataTable.CurrentRow.Cells[0].Value.ToString();
                    edit.txtQuestion.Text = dataTable.CurrentRow.Cells[1].Value.ToString();
                    edit.txtA.Text = dataTable.CurrentRow.Cells[2].Value.ToString();
                    edit.txtB.Text = dataTable.CurrentRow.Cells[3].Value.ToString();
                    edit.txtC.Text = dataTable.CurrentRow.Cells[4].Value.ToString();
                    edit.txtD.Text = dataTable.CurrentRow.Cells[5].Value.ToString();
                    edit.txtCorrect.Text = dataTable.CurrentRow.Cells[6].Value.ToString();
                    edit.txtLevel.Text = dataTable.CurrentRow.Cells[7].Value.ToString();
                    edit.txtNote.Text = dataTable.CurrentRow.Cells[9].Value.ToString();
                }

        private void DeleteDB()
        {
                    if (stLevel.Text == "Not selected")
                    {
                        MessageBox.Show("Please select the question you want to remove.", "Remove question", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult remDiag = MessageBox.Show("Are you sure that you want to delete the selected question?", "Remove question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (remDiag == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(stlblId.Text);
                            var levels = new[] { "Lvl0", "Lvl1", "Lvl2", "Lvl3", "Lvl4" };

                            foreach (var level in levels)
                            {
                                if (stLevel.Text == level)
                                {
                                    ExecuteDbCommand($"DELETE FROM questions_{level} WHERE Id='{id}'");
                                    break;
                                }
                            }
                            UpdateDB();
                        }
                    }
                }

        private void ExecuteDbCommand(string commandText)
        {
                    using(SqlCommand cmd = new SqlCommand(commandText, c))
                    {
                        c.Open();
                        cmd.ExecuteNonQuery();
                        c.Close();
                    }
                }

        private void ChangeLevelDB()
        {
                    frmChangeLevel change = new frmChangeLevel(this);
                    var levels = new[] { "Lvl0", "Lvl1", "Lvl2", "Lvl3", "Lvl4" };

                    foreach (var level in levels)
                    {
                        if (stLevel.Text == level)
                        {
                            var currentLevel = (DataGridView) this.Controls.Find($"dt{level}", true).FirstOrDefault();

                            if (currentLevel == null || Convert.ToInt32(currentLevel.CurrentRow.Cells[0].Value) == 0)
                            {
                                MessageBox.Show("You must select a question first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                change.lblOldLevel.Text = $"Level {level.Substring(3)}";
                                change.cmbNewLevel.Text = $"Level {level.Substring(3)}";
                                change.QuestionID = Convert.ToInt32(currentLevel.CurrentRow.Cells[0].Value);
                                change.question = currentLevel.CurrentRow.Cells[1].Value.ToString();
                                change.A = currentLevel.CurrentRow.Cells[2].Value.ToString();
                                change.B = currentLevel.CurrentRow.Cells[3].Value.ToString();
                                change.C = currentLevel.CurrentRow.Cells[4].Value.ToString();
                                change.D = currentLevel.CurrentRow.Cells[5].Value.ToString();
                                change.Correct = currentLevel.CurrentRow.Cells[6].Value.ToString();
                                change.Note = currentLevel.CurrentRow.Cells[9].Value.ToString();
                                change.ShowDialog();
                            }
                            return;
                        }
                    }
                    MessageBox.Show("You cannot change the question level for a Fastest Finger question.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        private void QEditor_Load(object sender, EventArgs e)
        {
            UpdateDB();
            var levels = new[] { "dtLevel0", "dtLevel1", "dtLevel2", "dtLevel3", "dtLevel4" };

                        foreach (var level in levels)
                        {
                            var currentLevel = (DataGridView) this.Controls.Find(level, true).FirstOrDefault();

                            if (currentLevel != null)
                            {
                                foreach (DataGridViewColumn column in currentLevel.Columns)
                                {
                                    if (column.Index == 1)
                                    {
                                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                    }
                                    else
                                    {
                                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                    }
                                }
                            }
                        }
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmQuestionAdd add = new frmQuestionAdd(this);
            add.ShowDialog();
        }

        private void tsRemove_Click(object sender, EventArgs e)
        {
            DeleteDB();
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            if (stLevel.Text == "Not selected")
            {
                MessageBox.Show("You must select a question first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EditDB();
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            UpdateDB();
        }

        #region Selection Changed
        private void HandleSelectionChange(DataGridView dtLevel)
        {
                    if (dtLevel.SelectedCells.Count > 0)
                    {
                        int selectedrowindex = dtLevel.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dtLevel.Rows[selectedrowindex];
                        string a = Convert.ToString(selectedRow.Cells["Id"].Value);
                        stlblId.Text = Convert.ToString(a);
                        stLevel.Text = dtLevel.CurrentRow.Cells[7].Value.ToString();
                    }
                }

        private void dtLevel1_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChange(dtLevel1);
        }

        private void dtLevel2_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChange(dtLevel2);
        }

        private void dtLevel3_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChange(dtLevel3);
        }

        private void dtLevel4_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChange(dtLevel4);
        }

        private void dtLevel0_SelectionChanged(object sender, EventArgs e)
        {
            HandleSelectionChange(dtLevel0);
        }

        private void dtLevel1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleSelectionChange(dtLevel1);
        }

        private void dtLevel2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleSelectionChange(dtLevel2);
        }

        private void dtLevel3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleSelectionChange(dtLevel3);
        }

        private void dtLevel4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleSelectionChange(dtLevel4);
        }

        private void dtLevel0_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleSelectionChange(dtLevel0);
        }
        #endregion

        #region Questions Reset functions
        private void ResetQuestions(string tableName, string successMessage)
        {
                    string commandText = $"UPDATE {tableName} SET Used='False'";
                    SqlCommand cmd = new SqlCommand(commandText, c);

                    try
                    {
                        c.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(successMessage, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (c.State == ConnectionState.Open)
                        {
                            c.Close();
                        }
                        UpdateDB();
                    }
                }

        private void tsmenuActionsResetAllQuestions_Click_1(object sender, EventArgs e)
        {
                    ResetQuestions("questions_Level0", "All questions succesfully reset!");
                    ResetQuestions("questions_Level1", "All questions succesfully reset!");
                    ResetQuestions("questions_Level2", "All questions succesfully reset!");
                    ResetQuestions("questions_Level3", "All questions succesfully reset!");
                    ResetQuestions("questions_Level4", "All questions succesfully reset!");
                }

        private void resetLevel1UsedQuestionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetQuestions("questions_Level1", "All Level 1 questions succesfully reset!");
        }

        private void resetLevel2UsedQuestionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetQuestions("questions_Level2", "All Level 2 questions succesfully reset!");
        }

        private void resetLevel3UsedQuestionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetQuestions("questions_Level3", "All Level 3 questions succesfully reset!");
        }

        private void resetLevel4UsedQuestionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetQuestions("questions_Level4", "All Level 4 questions succesfully reset!");
        }

        private void resetFastestFingerUsedQuestionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetQuestions("questions_Level0", "All Fastest Finger questions succesfully reset!");
        }
        #endregion

        #region Double Clicks
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditDB();
        }
        #endregion

        private void ChangeLevel_Click(object sender, EventArgs e)
        {
            ChangeLevelDB();
        }

        private void tbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            stLevel.Text = "Not selected";
            stlblId.Text = "0";
            ClearAllSelections();
        }

        private void ClearAllSelections()
        {
            dtLevel0.ClearSelection();
            dtLevel1.ClearSelection();
            dtLevel2.ClearSelection();
            dtLevel3.ClearSelection();
            dtLevel4.ClearSelection();
        }
    }
}

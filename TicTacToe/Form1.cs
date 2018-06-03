using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe
{
       
    public partial class Form1 : Form
    {

        private string s;                                       //Buffer string
        private int dim;                                        //Game field dimension
        private bool is_col = false;                            //Is a column filled?
        private bool is_row = false;                            //Is a row filled?
        private bool is_diag = false;                           //Is a diag filled?
        private bool is_full = false;                           //Is a gamefield full?
        string[,] matrix = new string[9,9];                     //Matrix
        private int turn_num = 1;                               //Number of turn


        public Form1()
        {
            InitializeComponent();
            dimensionMTB.Mask = "0";                      //Only digits for dimension
            s = "X";                                      //First turn is Cross          
        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            if (!is_col && !is_row && !is_diag && !is_full)       //If game is not over
            {
                try
                {
                    dim = Convert.ToInt16(dimensionMTB.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message + "\nВведена некорректная размерность поля!\nДолжно быть введено число от 3 до 9!\n");
                }
                
                
                int w = 25;                                     //Width of the cell
                int h = 25;                                     //Height of the cell

                for (int i = 0; i < dim; i++)                 //Filling up the matrix with -1s
                {
                    for (int j = 0; j < dim; j++)
                    {
                        matrix[i, j] = "-1";
                    }
                }

                if (dim >= 3 && dim <= 9)
                {
                    //statusRTB.Text += "Игра началась! Первыми ходят " + s + ".\n";        //Replaced with gameStatusBox with IStatus

                    gameStatusBox.WriteStatus_Start(s);

                    Button b = (Button)sender;              
                    b.Enabled = false;                      //Blocking controls at game start
                    dimensionMTB.Visible = false;           //
                    label1.Visible = false;                 //

                    for (int i = 0; i < dim; i++)           //Creating a gamefield (dim x dim)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            var imarkProvider = new MarkProvider();
          
                            var cr = new Cell(imarkProvider);                          
                            cr.Row = i;                                 //Cell row position
                            cr.Col = j;                                 //Cell column position
                            cr.Width = w;
                            cr.Height = h;
                            cr.Name = i.ToString() + j.ToString();      //Cell name for further usage
                            cr.Location = new Point(15 + w + w * j, 100 + h + h * i);
                            this.Controls.Add(cr);
                            cr.Click += new EventHandler(BTN_Click);

                            if (i == 0)                                 //Creating column coordinate labels
                            {
                                Label lb = new Label();
                                lb.Width = w - 5;
                                lb.Height = h - 5;
                                lb.Name = j.ToString();                 //Coordinate name for further usage
                                lb.Location = new Point(22 + w + w * j, 80 + h + h * i);
                                lb.Text = j.ToString();
                                this.Controls.Add(lb);
                            }

                            if (j == 0)                                 //Creating row coordinate labels
                            {
                                Label lb = new Label();
                                lb.Width = w - 5;
                                lb.Height = h - 5;
                                lb.Name = i.ToString();                 //Coordinate name for further usage
                                lb.Location = new Point(-5 + w + w * j, 105 + h + h * i);
                                lb.Text = i.ToString();
                                this.Controls.Add(lb);
                            }

                        
                        }
                    }
                }
            }
            else                        //If game is over
            {
                is_row = false;                               //Restoring bool conditions
                is_col = false;
                is_diag = false; 
                is_full = false;
                s = "X";                                      //Restoring the first turn
                startBTN.Text = "Начать новую игру";          //
                label1.Visible = true;                        //Showing the start interface
                dimensionMTB.Visible = true;                  //
                
                for (int i = 0; i < dim; i++)                 //Filling up the matrix with -1s
                {
                    for (int j = 0; j < dim; j++)
                    {
                        matrix[i, j] = "-1";
                    }
                }

                for (int i = 0; i < dim; i++)                 //Removing old cells and coordinates with names
                {
                    for (int j = 0; j < dim; j++)
                    {
                        this.Controls.RemoveByKey(i.ToString() + j.ToString());
                        if (i == 0) this.Controls.RemoveByKey(j.ToString());
                        if (j == 0) this.Controls.RemoveByKey(i.ToString());
                    }
                }

                                
                /*foreach (Control c in this.Controls)      //Doesnt work because Remove() shifts all control indexes by 1...
                {                                           //... as a result not all Cells are removed with "foreach"
                    Cell Pt = c as Cell;                    
                    if (Pt != null)
                    {
                        this.Controls.Remove(Pt)                          
                    }
                }*/

                //statusRTB.Clear();                        //Replaced with gameStatusBox with IStatus
                
                gameStatusBox.WriteStatus_Clear();
                turn_num = 1;

            }
            
      
        }

        private void BTN_Click(object sender, EventArgs e)      //Clicking on a cell
        {
            if (!is_row && !is_col && !is_diag && !is_full)     //If game is not over
            {
                Cell b = (Cell)sender;
                b.Text = b.PlaceMark(s);                      //Place s-mark on clicked cell
                matrix[b.Row, b.Col] = s;                     //Marking the pushed cell               


                gameStatusBox.WriteStatus_Turn(turn_num, s, b.Row, b.Col);
                
                turn_num++;

                is_col = true;
                is_row = true;
                for (int i = 0; i < dim; i++)                 //Checking if any row or column is filled with 0s
                {
                    for (int j = 0; j < dim; j++)
                    {
                        if (matrix[i, j] != "O") is_row = false;
                        if (matrix[j, i] != "O") is_col = false;
                    }
                    if (is_row || is_col) break;
                    else
                    {
                        if (i != dim - 1)
                        {
                            is_col = true;
                            is_row = true;
                        }
                        continue;
                    }
                }

                if (!is_col && !is_row)                         //...if not
                {
                    is_col = true;
                    is_row = true;
                    for (int i = 0; i < dim; i++)                 //Checking if any row or column is filled with Xs
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            if (matrix[i, j] != "X") is_row = false;
                            if (matrix[j, i] != "X") is_col = false;
                        }
                        if (is_row || is_col) break;
                        else
                        {
                            if (i != dim - 1)
                            {
                                is_col = true;
                                is_row = true;
                            }
                            continue;
                        }
                    }
                }

                is_diag = true;
                for (int i = 0; i < dim; i++)                 //Checking if left-to-right diag is filled with 0s...
                {
                    if (matrix[i, i] != "O")
                    {
                        is_diag = false;
                    }
                }

                if (is_diag == false)                           //...if not...
                {
                    is_diag = true;
                    for (int i = 0; i < dim; i++)                 //Checking if right-to-left diag is filled with 0s...
                    {
                        if (matrix[i, dim - 1 - i] != "O") { is_diag = false; }
                    }
                }


                if (is_diag == false)                           //...if not...
                {
                    is_diag = true;
                    for (int i = 0; i < dim; i++)                 //Checking if left-to-right diag is filled with Xs...
                    {
                        if (matrix[i, i] != "X")
                        {
                            is_diag = false;
                        }
                    }
                }


                if (is_diag == false)                           //...if not...
                {
                    is_diag = true;
                    for (int i = 0; i < dim; i++)                 //Checking if right-to-left diag is filled with Xs...
                    {
                        if (matrix[i, dim - 1 - i] != "X") { is_diag = false; }
                    }
                }

                is_full = true;
                for (int i = 0; i < dim; i++)                 //Checking if matrix is full
                {
                    for (int j = 0; j < dim; j++)
                    {
                        if (matrix[i, j] == "-1") is_full = false;
                    }
                }

                if (is_row) MessageBox.Show("Игра окончена! Заполнена строка! Значение: " + s);
                if (is_col) MessageBox.Show("Игра окончена! Заполнен столбец! Значение: " + s);
                if (is_diag) MessageBox.Show("Игра окончена! Заполнена диагональ! Значение: " + s);
                if (is_full) MessageBox.Show("Игра окончена! Не осталось свободного места!");
                

                if (is_row || is_col || is_diag || is_full)     //Modifying start button if game is over
                {                 
                    startBTN.Enabled = true;
                    startBTN.Text = "Обновить поле";
                    gameStatusBox.WriteStatus_End(is_row, is_col, is_diag, is_full, s);
                    ResSave(DateTime.Now, s, turn_num - 1);                             //Saving game results to database
                }

               
                    if (s == "X") s = "O";                          //Flip-flopping mark
                    else s = "X";

            }           

        }

        public void ResSave(DateTime d, string winner, int count)                   //Method for saving game results to database
        {
            using (ResultContext db = new ResultContext())
            {
                GameResults res = new GameResults { Time = d, TurnsCount = count, Winner = winner };              
                db.Results.Add(res);
                db.SaveChanges();
                gameStatusBox.Text += "\nРезультаты сохранены в базу данных \n";
                gameStatusBox.Text += "Имеющиеся записи в базе данных: \n";
                var total_results = db.Results;
                foreach (GameResults r in total_results)
                {
                    gameStatusBox.Text += r.Time.ToString() + " .Выиграли " + r.Winner.ToString() + ". Количество ходов " + r.TurnsCount.ToString() + ".\n";
                }
                gameStatusBox.SelectionStart = gameStatusBox.Text.Length;
                gameStatusBox.ScrollToCaret();
            }
                
        }

        
    }

    public interface IMark
    {
        string PlaceMark(string s);                 //Required mark
    }


    public class Cell : Button                         //Updating the Button with IMark => Cell
    {
        private readonly IMark imark;

        public Cell(IMark imark)                        //Dependancy injection
        {
            this.imark = imark;
        }

        public int Row { get; set; }                    //Row position

        public int Col { get; set; }                    //Column position

        public string PlaceMark(string s)
        {  
            if (imark != null)
            {
                this.Enabled = false;
                return imark.PlaceMark(s);           
            }
            else { throw new Exception("Ошибка ввода!"); }                  
        }
    }

    public class MarkProvider : IMark                   //Real Mark Provider (not fake one)
    {
        public string PlaceMark(string s)
        {
            return s;
        }       
    }



    public interface IStatus
    {
        void WriteStatus_End(bool row, bool col, bool diag, bool full, string mark);                 //Game end status
        void WriteStatus_Turn(int turn, string mark, int row, int col);                 //Turn status
        string WriteStatus_Start(string mark);                                            //Start status
        void WriteStatus_Clear();                                                       //Clear
    }


    public class StatusBox : RichTextBox, IStatus               //Updating the RichTextBox with IStatus => StatusBox
    {
        public string lastTextWritten;

        public void WriteStatus_End(bool row, bool col, bool diag, bool full, string mark)
        {
            if (row || col || diag || full)
            {              
                this.Text += "Игра окончена! Победили " + mark + ".\n";
                this.SelectionStart = this.Text.Length;
                this.ScrollToCaret();
                lastTextWritten = "Игра окончена! Победили " + mark + ".\n";
            }
        }

        public void WriteStatus_Turn(int turn, string mark, int row, int col)
        {
            this.Text += "Ход " + turn.ToString() + ". " + mark + " сделал ход по координатам " + row.ToString() + ":" + col.ToString() + ".\n";
            this.SelectionStart = this.Text.Length;
            this.ScrollToCaret();

        }

        public string WriteStatus_Start(string mark)
        {
            this.Text += "Игра началась! Первыми ходят " + mark + ".\n";
            lastTextWritten = "Игра окончена! Победили " + mark + ".\n";
            return lastTextWritten;
        }

        public void WriteStatus_Clear()
        {
            this.Clear();
        }
        
    }


    //--------------------------------Database-------------------------------------
    public class ResultContext : DbContext
    {
       public ResultContext()
            : base("DbConnection")
        { }

        public DbSet<GameResults> Results { get; set; }
    }

    public class GameResults
    {
        [Key]
        public DateTime Time { get; set; }
        public string Winner { get; set; }
        public int TurnsCount { get; set; }
    }
       
    //-----------------------------------------------------------------------------



}

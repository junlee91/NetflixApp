namespace NetfilxApp
{
    partial class Form1
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
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ListDisplay = new System.Windows.Forms.ListBox();
            this.InsertReview = new System.Windows.Forms.Button();
            this.TopNMovies = new System.Windows.Forms.Button();
            this.topNtxt1 = new System.Windows.Forms.TextBox();
            this.EachRate = new System.Windows.Forms.Button();
            this.TopNUsers = new System.Windows.Forms.Button();
            this.NetfilxIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RatingBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListDisplay2 = new System.Windows.Forms.ListBox();
            this.MovieIdBox = new System.Windows.Forms.TextBox();
            this.AvgRateBox = new System.Windows.Forms.TextBox();
            this.lblMovieId = new System.Windows.Forms.Label();
            this.lblAvgRating = new System.Windows.Forms.Label();
            this.occupationBox = new System.Windows.Forms.TextBox();
            this.userIdBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GetUserReview = new System.Windows.Forms.Button();
            this.GetMovieReview = new System.Windows.Forms.Button();
            this.TopNReview = new System.Windows.Forms.Button();
            this.MovieIDTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.MovieIDlbl = new System.Windows.Forms.Label();
            this.UserIDlbl = new System.Windows.Forms.Label();
            this.FindMovieID = new System.Windows.Forms.Button();
            this.FindUserID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NetfilxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFilename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFilename.Location = new System.Drawing.Point(12, 523);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(671, 30);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.Text = "netflix.mdf";
            this.txtFilename.TextChanged += new System.EventHandler(this.dataFile_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "All Movies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(355, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(328, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "All Users";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListDisplay
            // 
            this.ListDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListDisplay.FormattingEnabled = true;
            this.ListDisplay.ItemHeight = 20;
            this.ListDisplay.Location = new System.Drawing.Point(12, 46);
            this.ListDisplay.Name = "ListDisplay";
            this.ListDisplay.Size = new System.Drawing.Size(328, 364);
            this.ListDisplay.TabIndex = 7;
            this.ListDisplay.SelectedIndexChanged += new System.EventHandler(this.ListDisplay_SelectedIndexChanged);
            // 
            // InsertReview
            // 
            this.InsertReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.InsertReview.Location = new System.Drawing.Point(692, 522);
            this.InsertReview.Name = "InsertReview";
            this.InsertReview.Size = new System.Drawing.Size(174, 31);
            this.InsertReview.TabIndex = 14;
            this.InsertReview.Text = "Add";
            this.InsertReview.UseVisualStyleBackColor = true;
            this.InsertReview.Click += new System.EventHandler(this.InsertReview_Click);
            // 
            // TopNMovies
            // 
            this.TopNMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TopNMovies.Location = new System.Drawing.Point(1034, 348);
            this.TopNMovies.Name = "TopNMovies";
            this.TopNMovies.Size = new System.Drawing.Size(139, 46);
            this.TopNMovies.TabIndex = 18;
            this.TopNMovies.Text = "Top N Movies";
            this.TopNMovies.UseVisualStyleBackColor = true;
            this.TopNMovies.Click += new System.EventHandler(this.TopNMovies_Click);
            // 
            // topNtxt1
            // 
            this.topNtxt1.Location = new System.Drawing.Point(896, 313);
            this.topNtxt1.Name = "topNtxt1";
            this.topNtxt1.Size = new System.Drawing.Size(110, 25);
            this.topNtxt1.TabIndex = 19;
            this.topNtxt1.Text = "5";
            // 
            // EachRate
            // 
            this.EachRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.EachRate.Location = new System.Drawing.Point(12, 482);
            this.EachRate.Name = "EachRate";
            this.EachRate.Size = new System.Drawing.Size(150, 35);
            this.EachRate.TabIndex = 21;
            this.EachRate.Text = "Each Rating";
            this.EachRate.UseVisualStyleBackColor = true;
            this.EachRate.Click += new System.EventHandler(this.EachRate_Click);
            // 
            // TopNUsers
            // 
            this.TopNUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TopNUsers.Location = new System.Drawing.Point(878, 348);
            this.TopNUsers.Name = "TopNUsers";
            this.TopNUsers.Size = new System.Drawing.Size(139, 46);
            this.TopNUsers.TabIndex = 22;
            this.TopNUsers.Text = "Top N Users";
            this.TopNUsers.UseVisualStyleBackColor = true;
            this.TopNUsers.Click += new System.EventHandler(this.TopNUsers_Click);
            // 
            // NetfilxIcon
            // 
            this.NetfilxIcon.Location = new System.Drawing.Point(802, 74);
            this.NetfilxIcon.Name = "NetfilxIcon";
            this.NetfilxIcon.Size = new System.Drawing.Size(301, 221);
            this.NetfilxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NetfilxIcon.TabIndex = 24;
            this.NetfilxIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15F);
            this.label1.Location = new System.Drawing.Point(873, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Netflix App";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RatingBox
            // 
            this.RatingBox.FormattingEnabled = true;
            this.RatingBox.Items.AddRange(new object[] {
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.RatingBox.Location = new System.Drawing.Point(740, 490);
            this.RatingBox.Name = "RatingBox";
            this.RatingBox.Size = new System.Drawing.Size(126, 23);
            this.RatingBox.TabIndex = 28;
            this.RatingBox.SelectedIndexChanged += new System.EventHandler(this.RatingBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(689, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Rating";
            // 
            // ListDisplay2
            // 
            this.ListDisplay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListDisplay2.FormattingEnabled = true;
            this.ListDisplay2.ItemHeight = 20;
            this.ListDisplay2.Location = new System.Drawing.Point(355, 46);
            this.ListDisplay2.Name = "ListDisplay2";
            this.ListDisplay2.Size = new System.Drawing.Size(328, 364);
            this.ListDisplay2.TabIndex = 33;
            this.ListDisplay2.SelectedIndexChanged += new System.EventHandler(this.ListDisplay2_SelectedIndexChanged);
            // 
            // MovieIdBox
            // 
            this.MovieIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieIdBox.Location = new System.Drawing.Point(164, 415);
            this.MovieIdBox.Name = "MovieIdBox";
            this.MovieIdBox.Size = new System.Drawing.Size(176, 24);
            this.MovieIdBox.TabIndex = 34;
            // 
            // AvgRateBox
            // 
            this.AvgRateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgRateBox.Location = new System.Drawing.Point(164, 447);
            this.AvgRateBox.Name = "AvgRateBox";
            this.AvgRateBox.ReadOnly = true;
            this.AvgRateBox.Size = new System.Drawing.Size(176, 24);
            this.AvgRateBox.TabIndex = 35;
            // 
            // lblMovieId
            // 
            this.lblMovieId.AutoSize = true;
            this.lblMovieId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMovieId.Location = new System.Drawing.Point(68, 416);
            this.lblMovieId.Name = "lblMovieId";
            this.lblMovieId.Size = new System.Drawing.Size(66, 18);
            this.lblMovieId.TabIndex = 36;
            this.lblMovieId.Text = "Movie ID";
            // 
            // lblAvgRating
            // 
            this.lblAvgRating.AutoSize = true;
            this.lblAvgRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAvgRating.Location = new System.Drawing.Point(68, 447);
            this.lblAvgRating.Name = "lblAvgRating";
            this.lblAvgRating.Size = new System.Drawing.Size(78, 18);
            this.lblAvgRating.TabIndex = 37;
            this.lblAvgRating.Text = "Avg Rating";
            // 
            // occupationBox
            // 
            this.occupationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.occupationBox.Location = new System.Drawing.Point(507, 447);
            this.occupationBox.Name = "occupationBox";
            this.occupationBox.ReadOnly = true;
            this.occupationBox.Size = new System.Drawing.Size(176, 24);
            this.occupationBox.TabIndex = 38;
            // 
            // userIdBox
            // 
            this.userIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdBox.Location = new System.Drawing.Point(507, 416);
            this.userIdBox.Name = "userIdBox";
            this.userIdBox.Size = new System.Drawing.Size(176, 24);
            this.userIdBox.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(417, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 40;
            this.label5.Text = "User ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(417, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "Occupation";
            // 
            // GetUserReview
            // 
            this.GetUserReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.GetUserReview.Location = new System.Drawing.Point(511, 482);
            this.GetUserReview.Name = "GetUserReview";
            this.GetUserReview.Size = new System.Drawing.Size(172, 35);
            this.GetUserReview.TabIndex = 42;
            this.GetUserReview.Text = "Get Review";
            this.GetUserReview.UseVisualStyleBackColor = true;
            this.GetUserReview.Click += new System.EventHandler(this.GetUserReview_Click);
            // 
            // GetMovieReview
            // 
            this.GetMovieReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.GetMovieReview.Location = new System.Drawing.Point(168, 482);
            this.GetMovieReview.Name = "GetMovieReview";
            this.GetMovieReview.Size = new System.Drawing.Size(172, 35);
            this.GetMovieReview.TabIndex = 43;
            this.GetMovieReview.Text = "Get Review";
            this.GetMovieReview.UseVisualStyleBackColor = true;
            this.GetMovieReview.Click += new System.EventHandler(this.GetMovieReview_Click);
            // 
            // TopNReview
            // 
            this.TopNReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TopNReview.Location = new System.Drawing.Point(719, 348);
            this.TopNReview.Name = "TopNReview";
            this.TopNReview.Size = new System.Drawing.Size(139, 46);
            this.TopNReview.TabIndex = 44;
            this.TopNReview.Text = "Top N Review";
            this.TopNReview.UseVisualStyleBackColor = true;
            this.TopNReview.Click += new System.EventHandler(this.TopNReview_Click);
            // 
            // MovieIDTextBox
            // 
            this.MovieIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieIDTextBox.Location = new System.Drawing.Point(943, 453);
            this.MovieIDTextBox.Name = "MovieIDTextBox";
            this.MovieIDTextBox.Size = new System.Drawing.Size(160, 24);
            this.MovieIDTextBox.TabIndex = 45;
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDTextBox.Location = new System.Drawing.Point(943, 513);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(160, 24);
            this.UserIDTextBox.TabIndex = 46;
            // 
            // MovieIDlbl
            // 
            this.MovieIDlbl.AutoSize = true;
            this.MovieIDlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieIDlbl.Location = new System.Drawing.Point(940, 432);
            this.MovieIDlbl.Name = "MovieIDlbl";
            this.MovieIDlbl.Size = new System.Drawing.Size(66, 18);
            this.MovieIDlbl.TabIndex = 47;
            this.MovieIDlbl.Text = "Movie ID";
            // 
            // UserIDlbl
            // 
            this.UserIDlbl.AutoSize = true;
            this.UserIDlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDlbl.Location = new System.Drawing.Point(940, 490);
            this.UserIDlbl.Name = "UserIDlbl";
            this.UserIDlbl.Size = new System.Drawing.Size(58, 18);
            this.UserIDlbl.TabIndex = 48;
            this.UserIDlbl.Text = "User ID";
            // 
            // FindMovieID
            // 
            this.FindMovieID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindMovieID.Location = new System.Drawing.Point(1109, 453);
            this.FindMovieID.Name = "FindMovieID";
            this.FindMovieID.Size = new System.Drawing.Size(75, 40);
            this.FindMovieID.TabIndex = 49;
            this.FindMovieID.Text = "Find";
            this.FindMovieID.UseVisualStyleBackColor = true;
            this.FindMovieID.Click += new System.EventHandler(this.FindMovieID_Click);
            // 
            // FindUserID
            // 
            this.FindUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindUserID.Location = new System.Drawing.Point(1109, 513);
            this.FindUserID.Name = "FindUserID";
            this.FindUserID.Size = new System.Drawing.Size(75, 40);
            this.FindUserID.TabIndex = 50;
            this.FindUserID.Text = "Find";
            this.FindUserID.UseVisualStyleBackColor = true;
            this.FindUserID.Click += new System.EventHandler(this.FindUserID_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 565);
            this.Controls.Add(this.FindUserID);
            this.Controls.Add(this.FindMovieID);
            this.Controls.Add(this.UserIDlbl);
            this.Controls.Add(this.MovieIDlbl);
            this.Controls.Add(this.UserIDTextBox);
            this.Controls.Add(this.MovieIDTextBox);
            this.Controls.Add(this.TopNReview);
            this.Controls.Add(this.GetMovieReview);
            this.Controls.Add(this.GetUserReview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userIdBox);
            this.Controls.Add(this.occupationBox);
            this.Controls.Add(this.lblAvgRating);
            this.Controls.Add(this.lblMovieId);
            this.Controls.Add(this.AvgRateBox);
            this.Controls.Add(this.MovieIdBox);
            this.Controls.Add(this.ListDisplay2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RatingBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NetfilxIcon);
            this.Controls.Add(this.TopNUsers);
            this.Controls.Add(this.EachRate);
            this.Controls.Add(this.topNtxt1);
            this.Controls.Add(this.TopNMovies);
            this.Controls.Add(this.InsertReview);
            this.Controls.Add(this.ListDisplay);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NetfilxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ListDisplay;
        private System.Windows.Forms.Button InsertReview;
        private System.Windows.Forms.Button TopNMovies;
        private System.Windows.Forms.TextBox topNtxt1;
        private System.Windows.Forms.Button EachRate;
        private System.Windows.Forms.Button TopNUsers;
        private System.Windows.Forms.PictureBox NetfilxIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RatingBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ListDisplay2;
        private System.Windows.Forms.TextBox MovieIdBox;
        private System.Windows.Forms.TextBox AvgRateBox;
        private System.Windows.Forms.Label lblMovieId;
        private System.Windows.Forms.Label lblAvgRating;
        private System.Windows.Forms.TextBox occupationBox;
        private System.Windows.Forms.TextBox userIdBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button GetUserReview;
        private System.Windows.Forms.Button GetMovieReview;
        private System.Windows.Forms.Button TopNReview;
        private System.Windows.Forms.TextBox MovieIDTextBox;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Label MovieIDlbl;
        private System.Windows.Forms.Label UserIDlbl;
        private System.Windows.Forms.Button FindMovieID;
        private System.Windows.Forms.Button FindUserID;
    }
}


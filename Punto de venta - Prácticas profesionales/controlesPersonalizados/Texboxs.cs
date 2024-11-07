using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.controlesPersonalizados
{
    [DefaultEvent("_TextChanged")]
    public partial class Texboxs : UserControl
    {
        private Color borderColor = Color.MediumBlue;
        private int borderSize = 2;
        private bool UnderlinedStyle = false;
        private Color borderFocusColor = Color.DarkGray;
        private bool isFocused = false;


        //constructor
        public Texboxs()
        {
            InitializeComponent();
        }

        //eventos
        public event EventHandler _TextChanged;


        //estas son laspropiedades
        [Category("txt personalizado")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }

        }
        [Category("txt personalizado")]
        public int BorderSize
        {

            get => borderSize;
            set { borderSize = value; this.Invalidate(); }
        }

        public bool UnderlinedStyle1
        {
            get => UnderlinedStyle;
            set { UnderlinedStyle = value; this.Invalidate(); }
        }
        [Category("txt personalizado")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("txt personalizado")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category("txt personalizado")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    updateControlHeigth();
            }
        }
        [Category("txt personalizado")]
        public string Texts
        {
            get
            {
                return textBox1.Text;
            }
            set
            {

                textBox1.Text = value;
            }
        }
        [Category("txt personalizado")]
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set => borderFocusColor = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //dibujo del borde 
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (!isFocused)
                {
                    if (UnderlinedStyle1) //aqui se dibuja el borde subrayado 
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //aqui normal
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

                }
                    else
                {
                    penBorder.Color = borderFocusColor;

                    if (UnderlinedStyle1) //aqui se dibuja el borde subrayado 
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //aqui normal
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                updateControlHeigth();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            updateControlHeigth();
        }

        private void updateControlHeigth()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeigth = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeigth);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }
    }

}

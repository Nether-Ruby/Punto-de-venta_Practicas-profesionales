using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FontAwesome.Sharp; 

namespace Punto_de_venta___Prácticas_profesionales.controlesPersonalizados
{
    public class ClassBtnPersonalizado : Button
    {
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;
        private IconChar iconChar = IconChar.None; // Icono 
        private Color iconColor = Color.White;
        private int iconSize = 24;
        private ContentAlignment iconAlignment = ContentAlignment.MiddleLeft;
        private int iconPadding = 5;

        [Category("btn")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = value; this.Invalidate(); }
        }

        [Category("btn")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }

        [Category("btn")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("btn")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("btn")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Category("Icono")]
        public IconChar IconChar
        {
            get => iconChar;
            set { iconChar = value; this.Invalidate(); }
        }

        [Category("Icono")]
        public Color IconColor
        {
            get => iconColor;
            set { iconColor = value; this.Invalidate(); }
        }

        [Category("Icono")] 
        public int IconSize
        {
            get => iconSize;
            set { iconSize = value; this.Invalidate(); }
        }

        [Category("Icono")]
        public ContentAlignment IconAlignment
        {
            get => iconAlignment;
            set { iconAlignment = value; this.Invalidate(); }
        }

        [Category("Icono")]
        public int IconPadding
        {
            get => iconPadding;
            set { iconPadding = value; this.Invalidate(); }
        }

        // Constructor
        public ClassBtnPersonalizado()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 1.6F, this.Height - 1.6F);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);

                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // Dibuja el icono si se ha asignado
            if (iconChar != IconChar.None)
            {
                using (var iconImage = iconChar.ToBitmap(iconColor, iconSize))
                {
                    Point iconPoint = CalculateIconPosition();
                    pevent.Graphics.DrawImage(iconImage, iconPoint);
                }
            }
        }

        private Point CalculateIconPosition()
        {
            int x = 0, y = (this.Height - iconSize) / 2;

            // Alinea el ícono a la izquierda o derecha según la propiedad `IconAlignment`
            if (iconAlignment == ContentAlignment.MiddleLeft)
            {
                x = iconPadding; // A la izquierda con padding
            }
            else if (iconAlignment == ContentAlignment.MiddleRight)
            {
                x = this.Width - iconSize - iconPadding; // A la derecha con padding
            }

            return new Point(x, y);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += Container_BackColorChanged;
            }
        }

        private void Container_BackColorChanged(object? sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
    }
}

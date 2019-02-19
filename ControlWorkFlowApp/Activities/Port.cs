﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkFlowApp
{
    public abstract class Port
    {
        public Guid Id { get; }

        public Guid NextNodeId { get; set; }

        public Rect Bounds { get; set; }

        public abstract Point GetOffset(Rect r);

        public abstract Brush GetBackBrush();

        public Port()
        {
            this.Id = Guid.NewGuid();
        }

        internal void UpdateBounds(Rectangle r)
        {
            var portPoint = this.GetOffset(r);
            var portSize = new Size(PageRenderOptions.GridSize, PageRenderOptions.GridSize);
            portPoint.Offset(-portSize.Width / 2, -portSize.Height / 2);
            var portBounds = new Rectangle(portPoint, portSize);
            this.Bounds = portBounds;
        }

        public GraphicsPath Render(Graphics g, Rectangle r, NodeStyle o)
        {
            this.UpdateBounds(r);
            g.FillEllipse(this.GetBackBrush(), this.Bounds);
            var portPath = new GraphicsPath();
            portPath.StartFigure();
            portPath.AddEllipse(this.Bounds);
            portPath.CloseFigure();
            return portPath;
        }
    }

    public sealed class NextPort : Port
    {
        public override Point GetOffset(Rect r) => r.CenterBottom;

        public override Brush GetBackBrush() => new SolidBrush(Color.FromArgb(100, Color.Blue));
    }

    public sealed class TruePort : Port
    {
        public override Point GetOffset(Rect r) => r.CenterBottom;

        public override Brush GetBackBrush() => new SolidBrush(Color.FromArgb(100, Color.Green));
    }

    public sealed class FalsePort : Port
    {
        public override Point GetOffset(Rect r) => r.CenterRight;

        public override Brush GetBackBrush() => new SolidBrush(Color.FromArgb(100, Color.Red));
    }
}

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RandomImageViewer.Controls
{
    public class ScrollablePanel : Panel
    {
        private enum ScrollDirection
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest,
            None
        }

        private const int MIN_RADIAL_MOVEMENT = 30; // the minimum change in order to start the scrolling 

        private Point StartLocation;
        private bool Started;
        private System.Threading.Thread ScrollThread;
        private Point MouseLocation;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Middle)
            {
                MiddleMouseClicked(e.Location);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.Button == MouseButtons.Middle)
            {
                MiddleMouseClicked(e.Location);
            }
        }

        public void MiddleMouseClicked(Point location)
        {
            if (Started)
            {
                Started = false;
                this.Cursor = Cursors.Default;
            }
            else
            {
                Started = true;
                Cursor = Cursors.NoMove2D;
                StartLocation = GetRelativeLocation(location);
                MouseLocation = GetRelativeLocation(location);
                ScrollThread = new System.Threading.Thread(Scroller);
                ScrollThread.Start();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            MouseMoved(e.Location);
        }

        public void MouseMoved(Point location)
        {
            if (Started)
            {
                MouseLocation = GetRelativeLocation(location);
            }
        }

        private Point GetRelativeLocation(Point location)
        {
            return new Point(location.X - HorizontalScroll.Value, location.Y - VerticalScroll.Value);
        }

        private double Distance(Point location1, Point location2)
        {
            return Math.Sqrt(Math.Pow(location1.X - location2.X, 2) + Math.Pow(location1.Y - location2.Y, 2));
        }

        private delegate void SetScrollValuesDelegate(int verticalScroll, int horizontalScroll);
        private void SetScrollValues(int verticalScroll, int horizontalScroll)
        {
            if (InvokeRequired)
            {
                Invoke(new SetScrollValuesDelegate(SetScrollValues), new object[] { verticalScroll, horizontalScroll });
            }
            else
            { 
                VerticalScroll.Value = Math.Min(VerticalScroll.Maximum, Math.Max(VerticalScroll.Minimum, verticalScroll));
                HorizontalScroll.Value = Math.Min(HorizontalScroll.Maximum, Math.Max(HorizontalScroll.Minimum, horizontalScroll));
            }
        }

        private delegate void SetCursorDelegate(Cursor cursor);
        private void SetCursor(Cursor cursor)
        {
            if (InvokeRequired)
            {
                Invoke(new SetCursorDelegate(SetCursor), new object[] { cursor });
            }
            else
            {
                this.Cursor = cursor;
            }
        }

        private void Scroller()
        {
            while (Started)
            {
                var scrollDirection = FindScrollDirection(StartLocation, MouseLocation);
                SetCursor(GetCursorForScrollDirection(scrollDirection));
                if (scrollDirection != ScrollDirection.None)
                {
                    SetScroll(scrollDirection);
                }

                System.Threading.Thread.Sleep(10);
            }
        }

        private void SetScroll(ScrollDirection scrollDirection)
        {
            int horizontalDistance = MouseLocation.X - StartLocation.X;
            int verticalDistance = MouseLocation.Y - StartLocation.Y;

            int horizontalMovement = 0;
            int verticalMovement = 0;

            if (!(new ScrollDirection[] { ScrollDirection.West, ScrollDirection.East}).Contains(scrollDirection))
            {
                verticalMovement = verticalDistance / 4;
            }
            if (!(new ScrollDirection[] { ScrollDirection.North, ScrollDirection.South }).Contains(scrollDirection))
            {
                horizontalMovement = horizontalDistance / 4;
            }

            SetScrollValues(VerticalScroll.Value + verticalMovement, HorizontalScroll.Value + horizontalMovement);
        }

        private Cursor GetCursorForScrollDirection(ScrollDirection scrollDirection)
        {
            switch (scrollDirection)
            {
                case ScrollDirection.North:
                    return Cursors.PanNorth;
                case ScrollDirection.NorthEast:
                    return Cursors.PanNE;
                case ScrollDirection.East:
                    return Cursors.PanEast;
                case ScrollDirection.SouthEast:
                    return Cursors.PanSE;
                case ScrollDirection.South:
                    return Cursors.PanSouth;
                case ScrollDirection.SouthWest:
                    return Cursors.PanSW;
                case ScrollDirection.West:
                    return Cursors.PanWest;
                case ScrollDirection.NorthWest:
                    return Cursors.PanNW;
                default:
                    return Cursors.NoMove2D;
            }
        }

        private ScrollDirection FindScrollDirection(Point start, Point current)
        {
            int distance = (int)Distance(StartLocation, MouseLocation);
            if (distance > MIN_RADIAL_MOVEMENT)
            {
                int horizontalDistance = current.X - start.X;
                int verticalDistance = current.Y - start.Y;

                if (horizontalDistance > MIN_RADIAL_MOVEMENT && verticalDistance > MIN_RADIAL_MOVEMENT) return ScrollDirection.SouthEast;
                if (horizontalDistance > MIN_RADIAL_MOVEMENT && verticalDistance <= -1 * MIN_RADIAL_MOVEMENT) return ScrollDirection.NorthEast;
                if (horizontalDistance <= -1 * MIN_RADIAL_MOVEMENT && verticalDistance > MIN_RADIAL_MOVEMENT) return ScrollDirection.SouthWest;
                if (horizontalDistance <= -1 * MIN_RADIAL_MOVEMENT && verticalDistance <= -1 * MIN_RADIAL_MOVEMENT) return ScrollDirection.NorthWest;
                if (horizontalDistance > MIN_RADIAL_MOVEMENT) return ScrollDirection.East;
                if (horizontalDistance <= -1 * MIN_RADIAL_MOVEMENT) return ScrollDirection.West;
                if (verticalDistance > MIN_RADIAL_MOVEMENT) return ScrollDirection.South;
                if (verticalDistance <= -1 * MIN_RADIAL_MOVEMENT) return ScrollDirection.North;
            }
            return ScrollDirection.None;
        }
    }
}

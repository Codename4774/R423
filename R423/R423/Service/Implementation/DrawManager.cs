using R423.Service.Interface;
using StatesDataLibrary.Classes.Controllers;
using StatesDataLibrary.Classes.Models.SignalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace R423.Service.Implementation
{
    public class DrawManager : IDrawManager
    {
        private const int _ellipseRadius = 9;

        private Duration _animationDuration;

        private Storyboard _storyboard;

        private DrawContextProvider _drawContextProvider;

        private List<List<Ellipse>> _lastDrawedEllipses;

        private Direction _prevDirection;

        public DrawContextProvider DrawContextProvider
        {
            set
            {
                _drawContextProvider = value;
            }
        }

        private readonly ICoordsConverter _coordsConverter;

        private readonly IResourceManager _resourceManager;


        public DrawManager(ICoordsConverter coordsConverter, IResourceManager resourceManager)
        {
            _coordsConverter = coordsConverter;
            _resourceManager = resourceManager;
            _animationDuration = TimeSpan.FromSeconds(_resourceManager.GetInt("animationDurationSeconds"));
            _storyboard = new Storyboard();
            _lastDrawedEllipses = new List<List<Ellipse>>();
            _prevDirection = Direction.Forward;
        }

        public void DrawSignalPath(int signalPathIndex)
        {
            SignalPath signalPath = SignalPathsController.GetSignalPath(signalPathIndex);

            for (int i = 0; i < signalPath.States.Count; i++)
            {
                DrawState(i, signalPathIndex, Direction.Forward);
            }
        }

        public void DrawState(int ordinalStateIndex, int signalPathIndex, Direction direction)
        {
            try
            {
                SignalPath signalPath = SignalPathsController.GetSignalPath(signalPathIndex);

                if ((ordinalStateIndex < 0))
                {
                    return; //todo: implement 
                }

                if ((ordinalStateIndex > signalPath.States.Count - 1))
                {
                    return; //todo: implement 
                }

                int stateIndex = signalPath.States[ordinalStateIndex];

                List<Polyline> polylines = SignalPathStatesController.GetCachedDrawableStateForDrawing(stateIndex);

                DrawLinesWithAnimation(polylines, direction);
            }
            catch (Exception ex)
            {

            }
        }

        private void DrawLinesWithAnimation(List<Polyline> polylines, Direction direction)
        {
            _storyboard.Children.Clear();

            ClearPreviousDrawedEllipses(direction);

            var drawedEllipses = new List<Ellipse>();

            for (int i = 0; i < polylines.Count; i++)
            {
                DrawLineWithAnimation(polylines[i], direction, drawedEllipses);
            }

            _lastDrawedEllipses.Add(drawedEllipses);

            _prevDirection = direction;

            _storyboard.Begin();
        }

        private void ClearPreviousDrawedEllipses(Direction direction)
        {
            if ((direction == Direction.Forward) && (_lastDrawedEllipses.Count == 1) && (_prevDirection == Direction.Back))
            {
                RemoveLastDrawedEllipses();
            }
            if ((direction == Direction.Back) && (_prevDirection == Direction.Forward))
            {
                RemoveLastDrawedEllipses();
            }
            if ((direction == Direction.Back) && (_prevDirection == Direction.Back))
            {
                RemoveLastDrawedEllipses();
                RemoveLastDrawedEllipses();
            }
        }

        private void DrawLineWithAnimation(Polyline polyline, Direction direction, List<Ellipse> drawedEllipses)
        {
            var polylineForDrawing = GetPolylineForPathState(polyline, direction);

            polylineForDrawing.Stroke = polyline.Stroke;

            var ellipse = GetEllipse(polylineForDrawing.Points[0], polyline.Stroke);

            DrawLineObjects(polylineForDrawing, ellipse);

            drawedEllipses.Add(ellipse);

            SetAnimationPath(polylineForDrawing.Points, ellipse, polylineForDrawing);
        }

        private void DrawLineObjects(Polyline polyline, Ellipse ellipse)
        {
            if (!_drawContextProvider.DrawContext.Children.Contains(polyline))
            {
                _drawContextProvider.DrawContext.Children.Add(polyline);
            }
            _drawContextProvider.DrawContext.Children.Add(ellipse);
        }

        private Polyline GetPolylineForPathState(Polyline polyline, Direction direction)
        {
            var points = polyline.Points.Clone();

            _coordsConverter.Convert(ref points);

            if (direction == Direction.Back)
            {
                points = new PointCollection(points.Reverse());
            }

            return new Polyline() { Points = points };
        }

        private void SetAnimationPath(PointCollection points, Ellipse ellipse, Polyline polyline)
        {
            var pathGeometry = GetPathGeometryFromPoints(points);

            var animations = GetAnimationPathForEllipse(pathGeometry, ellipse);

            animations.Add(GetAnimationForLineProperty(_animationDuration, polyline, new PropertyPath(Polyline.OpacityProperty), 0, 1));

            foreach (var animation in animations)
            {
                _storyboard.Children.Add(animation);
            }
        }

        private void RemoveLastDrawedEllipses()
        {
            try
            {
                var lastDrawedState = _lastDrawedEllipses.Last();
                foreach (var ellipse in lastDrawedState)
                {
                    _drawContextProvider.DrawContext.Children.Remove(ellipse);
                }
                _lastDrawedEllipses.Remove(lastDrawedState);
            }
            catch (Exception exception)
            {
                return;
            }
        }

        private List<DoubleAnimationBase> GetAnimationPathForEllipse(PathGeometry pathGeometry, DependencyObject dependencyObject)
        {
            var result = new List<DoubleAnimationBase>();

            result.Add(GetAnimationForLineProperty(pathGeometry, _animationDuration, PathAnimationSource.X, dependencyObject, new PropertyPath(Canvas.LeftProperty)));

            result.Add(GetAnimationForLineProperty(pathGeometry, _animationDuration, PathAnimationSource.Y, dependencyObject, new PropertyPath(Canvas.TopProperty)));

            return result;
        }

        private PathGeometry GetPathGeometryFromPolyline(Polyline polyline, Direction direction)
        {
            PathSegmentCollection segments = new PathSegmentCollection();
            var points = polyline.Points.Clone();
            if (direction == Direction.Back)
            {
                points.Reverse();
            }
            _coordsConverter.AddValueToPoints(ref points, -_ellipseRadius / 2, -_ellipseRadius / 2);
            segments.Add(new PolyLineSegment(points, false));

            var result = new PathGeometry(new[] { new PathFigure(points[0], segments, false) });

            return result;
        }

        private PathGeometry GetPathGeometryFromPoints(PointCollection points)
        {
            PathSegmentCollection segments = new PathSegmentCollection();

            _coordsConverter.AddValueToPoints(ref points, -_ellipseRadius / 2, -_ellipseRadius / 2);
            segments.Add(new PolyLineSegment(points, false));

            var result = new PathGeometry(new[] { new PathFigure(points[0], segments, false) });

            return result;
        }

        private DoubleAnimationUsingPath GetAnimationForLineProperty(PathGeometry pathGeometry, Duration duration, PathAnimationSource pathAnimationSource, DependencyObject dependencyObject, PropertyPath targetPropertyPath)
        {
            var result = new DoubleAnimationUsingPath();

            result.PathGeometry = pathGeometry;
            result.Duration = duration;

            result.Source = pathAnimationSource;

            Storyboard.SetTarget(result, dependencyObject);
            Storyboard.SetTargetProperty(result, targetPropertyPath);

            return result;
        }

        private DoubleAnimation GetAnimationForLineProperty(Duration duration, DependencyObject dependencyObject, PropertyPath targetPropertyPath, int from, int to)
        {
            var result = new DoubleAnimation();

            result.Duration = duration;
            result.From = from;
            result.To = to;

            Storyboard.SetTarget(result, dependencyObject);
            Storyboard.SetTargetProperty(result, targetPropertyPath);

            return result;
        }

        public void DrawStateRevertDirection(int stateIndex, int signalPathIndex)
        {
            throw new NotImplementedException();
        }

        public Ellipse GetEllipse(Point coordinate, System.Windows.Media.Brush brush)
        {
            Ellipse ellipse = new Ellipse() { Width = _ellipseRadius, Height = _ellipseRadius, Fill = brush, Stroke = brush };

            Canvas.SetLeft(ellipse, coordinate.X + (_ellipseRadius / 2 ) );
            Canvas.SetTop(ellipse, coordinate.Y + (_ellipseRadius / 2) );

            return ellipse;
        }
    }
}

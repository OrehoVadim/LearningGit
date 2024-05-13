using System;

namespace LearningScripts
{
    public class CalculationFigureVolume
    {
        /// <summary>
        /// Усовершенствовать задачу 1.1.
        /// Написать метод для подсчета обьема фигуры,
        /// в зависимости от ее типа (конус, цилиндр, шар, квадрат).
        /// Добавить всевозможные проверки.
        /// Входные данные: конус (радиус, высота), цилиндр(), шар(), квадрат()
        /// Алгоритм: создать метод с формулами для подсчета объёма указанных фигур
        /// Результат: объём указанных фигур
        /// </summary>

        public double CalculateConeVolume(double Radius, double Height)
        {
            return 1.0 / 3.0 * Math.PI * (Radius * Radius) * Height;
        }

        public double CalculateCylinderVolume(double Radius, double Height)
        {
            return Math.PI * (Radius * Radius) * Height;
        }

        public double CalculateLayerVolume(double Radius, double Height)
        {
            return (3.0 / 4.0 * Math.PI * (Radius * Radius * Radius));
        }

        public double CalculateCubeVolume(double Length)
        {
            return Length * Length * Length;
        }

    }

    public class ConeFigure
    {
        public double Radius;
        public double Height;

        public ConeFigure(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
    }

    public class CylinderFigure
    {
        public double Radius { get; private set; }
        public double Height { get; private set; }

        public CylinderFigure(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
    }

    public class LayerFigure
    {
        public double Radius { get; private set; }
        public double Height { get; private set; }

        public LayerFigure(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
    }

    public class CubeFigure
    {
        public double Length { get; private set; }

        public CubeFigure(double length)
        {
            Length = length;
        }
    }
    
}
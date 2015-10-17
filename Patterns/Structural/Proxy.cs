﻿using System;

namespace Patterns.Structural.Proxy
{
    // "Subject"
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    // "RealSubject"
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    // "Proxy Object"
    class MathProxy : IMath
    {
        Math math;

        public MathProxy()
        {
            math = new Math();
        }

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return math.Div(x, y);
        }
    }
}

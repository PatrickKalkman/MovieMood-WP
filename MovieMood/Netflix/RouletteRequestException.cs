using System;

namespace MovieMood.Netflix
{
    public class RouletteRequestException : Exception
    {
        public RouletteRequestException()
        { }

        public RouletteRequestException(string message)
            : base(message)
        { }

        public RouletteRequestException(string format, params object[] arguments)
            : this(string.Format(format, arguments))
        { }

        public RouletteRequestException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}

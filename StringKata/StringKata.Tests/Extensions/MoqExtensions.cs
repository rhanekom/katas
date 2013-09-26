﻿namespace StringKata.Tests.Extensions
{
    using System.Collections.Generic;
    using Moq.Language.Flow;

    public static class MoqExtensions
    {
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup, params TResult[] results) where T : class
        {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }
    }
}
